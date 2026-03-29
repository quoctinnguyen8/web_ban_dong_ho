using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDongHo.Web.Data;
using WebBanDongHo.Web.Models;
using WebBanDongHo.Web.ViewModels;

namespace WebBanDongHo.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Policy = "AdminOnly")]
public class AccountsController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHasher<AppAccount> _passwordHasher;

    public AccountsController(
        ApplicationDbContext dbContext,
        IPasswordHasher<AppAccount> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var accounts = _dbContext.AppAccounts
            .AsNoTracking()
            .Where(x => x.DeletedDate == null)
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

        return View(accounts);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new AccountCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AccountCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var duplicated = _dbContext.AppAccounts
            .Any(x => x.Username == model.Username && x.DeletedDate == null);

        if (duplicated)
        {
            ModelState.AddModelError(nameof(model.Username), "Tên đăng nhập đã tồn tại.");
            return View(model);
        }

        var now = DateTime.UtcNow;
        var currentUserId = int.TryParse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value, out var id)
            ? id
            : 1;

        var account = new AppAccount
        {
            Username = model.Username.Trim(),
            FullName = model.FullName.Trim(),
            IsAdmin = model.IsAdmin,
            IsActive = model.IsActive,
            CreatedDate = now,
            LastModifiedDate = now,
            CreatedBy = currentUserId,
            ModifiedBy = currentUserId
        };

        account.PasswordHash = _passwordHasher.HashPassword(account, model.Password);

        _dbContext.AppAccounts.Add(account);
        _dbContext.SaveChanges();

        TempData["Success"] = "Đã tạo tài khoản mới.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ToggleStatus(int id)
    {
        var account = _dbContext.AppAccounts
            .FirstOrDefault(x => x.Id == id && x.DeletedDate == null);

        if (account is null)
        {
            return NotFound();
        }

        if (account.Username == "admin" && account.IsActive)
        {
            TempData["Error"] = "Không thể khóa tài khoản admin mặc định.";
            return RedirectToAction(nameof(Index));
        }

        var currentUserId = int.TryParse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value, out var userId)
            ? userId
            : 1;

        account.IsActive = !account.IsActive;
        account.LastModifiedDate = DateTime.UtcNow;
        account.ModifiedBy = currentUserId;

        _dbContext.SaveChanges();

        TempData["Success"] = account.IsActive
            ? "Đã mở khóa tài khoản."
            : "Đã khóa tài khoản.";

        return RedirectToAction(nameof(Index));
    }
}
