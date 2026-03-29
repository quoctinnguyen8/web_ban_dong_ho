using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDongHo.Web.Data;
using WebBanDongHo.Web.Extensions;
using WebBanDongHo.Web.Models;
using WebBanDongHo.Web.ViewModels;

namespace WebBanDongHo.Web.Controllers;

public class CartController : Controller
{
    private const string CartSessionKey = "APP_CART_ITEMS";
    private readonly ApplicationDbContext _dbContext;

    public CartController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new CartPageViewModel
        {
            Items = GetCartItems(),
            CreatedOrderCode = TempData["CreatedOrderCode"] as string
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(int watchId, int quantity = 1)
    {
        if (quantity <= 0)
        {
            quantity = 1;
        }

        var watch = _dbContext.AppWatches
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == watchId && x.DeletedDate == null);

        if (watch is null)
        {
            TempData["CartError"] = "Sản phẩm không tồn tại hoặc đã bị ẩn.";
            return RedirectToAction("Index", "Home");
        }

        var cart = GetCartItems().ToList();
        var existing = cart.FirstOrDefault(x => x.WatchId == watchId);

        if (existing is null)
        {
            cart.Add(new CartItemViewModel
            {
                WatchId = watch.Id,
                Name = watch.Name,
                Sku = watch.Sku,
                UnitPrice = watch.Price,
                Quantity = Math.Min(quantity, watch.Stock),
                AvailableStock = watch.Stock
            });
        }
        else
        {
            existing.Quantity = Math.Min(existing.Quantity + quantity, watch.Stock);
            existing.AvailableStock = watch.Stock;
            existing.UnitPrice = watch.Price;
        }

        SaveCartItems(cart);
        TempData["CartSuccess"] = "Đã thêm sản phẩm vào giỏ hàng.";

        var referrer = Request.Headers.Referer.ToString();
        if (string.IsNullOrWhiteSpace(referrer))
        {
            return RedirectToAction("Index", "Home");
        }

        return Redirect(referrer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int watchId, int quantity)
    {
        var cart = GetCartItems().ToList();
        var existing = cart.FirstOrDefault(x => x.WatchId == watchId);

        if (existing is null)
        {
            return RedirectToAction(nameof(Index));
        }

        if (quantity <= 0)
        {
            cart.Remove(existing);
        }
        else
        {
            var stock = _dbContext.AppWatches
                .AsNoTracking()
                .Where(x => x.Id == watchId)
                .Select(x => x.Stock)
                .FirstOrDefault();

            existing.Quantity = Math.Min(quantity, Math.Max(stock, 0));
            existing.AvailableStock = stock;

            if (existing.Quantity <= 0)
            {
                cart.Remove(existing);
            }
        }

        SaveCartItems(cart);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int watchId)
    {
        var cart = GetCartItems().Where(x => x.WatchId != watchId).ToList();
        SaveCartItems(cart);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout(CheckoutOrderViewModel checkout)
    {
        var cartItems = GetCartItems();
        if (!cartItems.Any())
        {
            TempData["CartError"] = "Giỏ hàng đang trống, không thể đặt hàng.";
            return RedirectToAction(nameof(Index));
        }

        if (!ModelState.IsValid)
        {
            var invalidModel = new CartPageViewModel
            {
                Items = cartItems,
                Checkout = checkout
            };
            return View("Index", invalidModel);
        }

        var watchIds = cartItems.Select(x => x.WatchId).Distinct().ToList();
        var watches = _dbContext.AppWatches
            .Where(x => watchIds.Contains(x.Id) && x.DeletedDate == null)
            .ToDictionary(x => x.Id);

        foreach (var item in cartItems)
        {
            if (!watches.TryGetValue(item.WatchId, out var watch))
            {
                TempData["CartError"] = $"Sản phẩm {item.Name} không còn tồn tại.";
                return RedirectToAction(nameof(Index));
            }

            if (watch.Stock < item.Quantity)
            {
                TempData["CartError"] = $"Sản phẩm {item.Name} chỉ còn {watch.Stock} chiếc.";
                return RedirectToAction(nameof(Index));
            }
        }

        var now = DateTime.UtcNow;
        var orderCode = GenerateOrderCode();
        var order = new AppOrder
        {
            OrderCode = orderCode,
            CustomerName = checkout.CustomerName.Trim(),
            CustomerPhone = checkout.CustomerPhone.Trim(),
            CustomerAddress = checkout.CustomerAddress.Trim(),
            Note = checkout.Note?.Trim(),
            Status = AppOrderStatus.Pending,
            TotalAmount = cartItems.Sum(x => x.LineTotal),
            CreatedDate = now,
            LastModifiedDate = now,
            CreatedBy = 0,
            ModifiedBy = 0
        };

        _dbContext.AppOrders.Add(order);
        _dbContext.SaveChanges();

        var orderItems = cartItems.Select(item =>
        {
            var watch = watches[item.WatchId];
            watch.Stock -= item.Quantity;
            watch.LastModifiedDate = now;
            watch.ModifiedBy = 0;

            return new AppOrderItem
            {
                OrderId = order.Id,
                WatchId = item.WatchId,
                WatchName = item.Name,
                WatchSku = item.Sku,
                UnitPrice = item.UnitPrice,
                Quantity = item.Quantity,
                LineTotal = item.LineTotal,
                CreatedDate = now,
                LastModifiedDate = now,
                CreatedBy = 0,
                ModifiedBy = 0
            };
        }).ToList();

        _dbContext.AppOrderItems.AddRange(orderItems);
        _dbContext.SaveChanges();

        SaveCartItems([]);
        TempData["CreatedOrderCode"] = orderCode;
        TempData["CartSuccess"] = "Đặt hàng thành công.";

        return RedirectToAction(nameof(Index));
    }

    private IReadOnlyList<CartItemViewModel> GetCartItems()
    {
        return HttpContext.Session.GetObject<List<CartItemViewModel>>(CartSessionKey) ?? [];
    }

    private void SaveCartItems(IReadOnlyList<CartItemViewModel> items)
    {
        HttpContext.Session.SetObject(CartSessionKey, items);
    }

    private string GenerateOrderCode()
    {
        var today = DateTime.UtcNow.ToString("yyyyMMdd");
        var countToday = _dbContext.AppOrders.Count(x => x.CreatedDate.Date == DateTime.UtcNow.Date);
        return $"DH-{today}-{countToday + 1:0000}";
    }
}
