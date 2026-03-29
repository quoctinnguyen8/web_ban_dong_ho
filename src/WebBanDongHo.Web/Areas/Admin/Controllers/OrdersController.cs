using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDongHo.Web.Data;
using WebBanDongHo.Web.Models;
using WebBanDongHo.Web.ViewModels;

namespace WebBanDongHo.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Policy = "AdminOnly")]
public class OrdersController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public OrdersController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Index(string? keyword, string? status)
    {
        var query = _dbContext.AppOrders
            .AsNoTracking()
            .Where(x => x.DeletedDate == null);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(x =>
                x.OrderCode.Contains(keyword) ||
                x.CustomerName.Contains(keyword) ||
                x.CustomerPhone.Contains(keyword));
        }

        if (!string.IsNullOrWhiteSpace(status) && AppOrderStatus.All.Contains(status))
        {
            query = query.Where(x => x.Status == status);
        }

        var orders = query
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

        ViewData["Keyword"] = keyword;
        ViewData["Status"] = status;
        ViewData["Statuses"] = AppOrderStatus.All;

        return View(orders);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var order = _dbContext.AppOrders
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id && x.DeletedDate == null);

        if (order is null)
        {
            return NotFound();
        }

        var items = _dbContext.AppOrderItems
            .AsNoTracking()
            .Where(x => x.OrderId == id && x.DeletedDate == null)
            .OrderBy(x => x.Id)
            .ToList();

        ViewData["Statuses"] = AppOrderStatus.All;

        return View(new AdminOrderDetailViewModel
        {
            Order = order,
            Items = items
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateStatus(int id, string status)
    {
        if (!AppOrderStatus.All.Contains(status))
        {
            TempData["Error"] = "Trạng thái đơn hàng không hợp lệ.";
            return RedirectToAction(nameof(Details), new { id });
        }

        var order = _dbContext.AppOrders
            .FirstOrDefault(x => x.Id == id && x.DeletedDate == null);

        if (order is null)
        {
            return NotFound();
        }

        var currentUserId = int.TryParse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value, out var userId)
            ? userId
            : 1;

        order.Status = status;
        order.LastModifiedDate = DateTime.UtcNow;
        order.ModifiedBy = currentUserId;

        _dbContext.SaveChanges();

        TempData["Success"] = "Đã cập nhật trạng thái đơn hàng.";
        return RedirectToAction(nameof(Details), new { id });
    }
}
