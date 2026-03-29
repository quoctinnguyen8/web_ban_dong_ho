using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDongHo.Web.Data;
using WebBanDongHo.Web.Models;
using WebBanDongHo.Web.ViewModels;

namespace WebBanDongHo.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Policy = "AdminOnly")]
public class WatchesController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public WatchesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Index(string? keyword)
    {
        var query = _dbContext.AppWatches.AsNoTracking().Where(x => x.DeletedDate == null);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(x =>
                x.Name.Contains(keyword) ||
                x.Sku.Contains(keyword) ||
                x.Brand.Contains(keyword));
        }

        var watches = query
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

        ViewData["Keyword"] = keyword;

        return View(watches);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new WatchFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(WatchFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var duplicatedSku = _dbContext.AppWatches
            .Any(x => x.Sku == model.Sku && x.DeletedDate == null);

        if (duplicatedSku)
        {
            ModelState.AddModelError(nameof(model.Sku), "SKU đã tồn tại.");
            return View(model);
        }

        var now = DateTime.UtcNow;

        var entity = new AppWatch
        {
            Brand = model.Brand.Trim(),
            Name = model.Name.Trim(),
            Sku = model.Sku.Trim(),
            ShortDescription = model.ShortDescription?.Trim(),
            LongDescription = model.LongDescription?.Trim(),
            MovementType = model.MovementType.Trim(),
            CaseSizeMm = model.CaseSizeMm,
            WaterResistanceM = model.WaterResistanceM,
            ImageUrl = model.ImageUrl?.Trim(),
            Price = model.Price,
            Stock = model.Stock,
            CreatedDate = now,
            LastModifiedDate = now,
            CreatedBy = 1,
            ModifiedBy = 1
        };

        _dbContext.AppWatches.Add(entity);
        _dbContext.SaveChanges();

        TempData["Success"] = "Đã thêm sản phẩm mới.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var entity = _dbContext.AppWatches.FirstOrDefault(x => x.Id == id && x.DeletedDate == null);
        if (entity is null)
        {
            return NotFound();
        }

        var model = new WatchFormViewModel
        {
            Id = entity.Id,
            Brand = entity.Brand,
            Name = entity.Name,
            Sku = entity.Sku,
            ShortDescription = entity.ShortDescription,
            LongDescription = entity.LongDescription,
            MovementType = entity.MovementType,
            CaseSizeMm = entity.CaseSizeMm,
            WaterResistanceM = entity.WaterResistanceM,
            ImageUrl = entity.ImageUrl,
            Price = entity.Price,
            Stock = entity.Stock
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(WatchFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var entity = _dbContext.AppWatches.FirstOrDefault(x => x.Id == model.Id && x.DeletedDate == null);
        if (entity is null)
        {
            return NotFound();
        }

        var duplicatedSku = _dbContext.AppWatches
            .Any(x => x.Id != model.Id && x.Sku == model.Sku && x.DeletedDate == null);

        if (duplicatedSku)
        {
            ModelState.AddModelError(nameof(model.Sku), "SKU đã tồn tại.");
            return View(model);
        }

        entity.Brand = model.Brand.Trim();
        entity.Name = model.Name.Trim();
        entity.Sku = model.Sku.Trim();
        entity.ShortDescription = model.ShortDescription?.Trim();
        entity.LongDescription = model.LongDescription?.Trim();
        entity.MovementType = model.MovementType.Trim();
        entity.CaseSizeMm = model.CaseSizeMm;
        entity.WaterResistanceM = model.WaterResistanceM;
        entity.ImageUrl = model.ImageUrl?.Trim();
        entity.Price = model.Price;
        entity.Stock = model.Stock;
        entity.LastModifiedDate = DateTime.UtcNow;
        entity.ModifiedBy = 1;

        _dbContext.SaveChanges();

        TempData["Success"] = "Đã cập nhật sản phẩm.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var entity = _dbContext.AppWatches.FirstOrDefault(x => x.Id == id && x.DeletedDate == null);
        if (entity is null)
        {
            return NotFound();
        }

        entity.DeletedDate = DateTime.UtcNow;
        entity.LastModifiedDate = DateTime.UtcNow;
        entity.ModifiedBy = 1;

        _dbContext.SaveChanges();

        TempData["Success"] = "Đã ẩn sản phẩm khỏi cửa hàng.";
        return RedirectToAction(nameof(Index));
    }
}
