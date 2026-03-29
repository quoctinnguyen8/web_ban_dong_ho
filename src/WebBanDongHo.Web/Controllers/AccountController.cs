using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDongHo.Web.Data;
using WebBanDongHo.Web.Models;
using WebBanDongHo.Web.ViewModels;

namespace WebBanDongHo.Web.Controllers;

[Route("tai-khoan")]
public class AccountController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHasher<AppAccount> _passwordHasher;

    public AccountController(
        ApplicationDbContext dbContext,
        IPasswordHasher<AppAccount> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    [HttpGet("dang-nhap")]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost("dang-nhap")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var account = await _dbContext.AppAccounts
            .FirstOrDefaultAsync(x => x.Username == model.Username && x.DeletedDate == null);

        if (account is null || !account.IsActive)
        {
            ModelState.AddModelError(string.Empty, "Tài khoản không tồn tại hoặc đã bị khóa.");
            return View(model);
        }

        var verifyResult = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, model.Password);

        if (verifyResult == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError(string.Empty, "Mật khẩu không chính xác.");
            return View(model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new(ClaimTypes.Name, account.FullName),
            new("Username", account.Username),
            new("IsAdmin", account.IsAdmin ? "true" : "false")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        if (!string.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
        {
            return Redirect(model.ReturnUrl);
        }

        return account.IsAdmin
            ? RedirectToAction("Index", "Watches", new { area = "Admin" })
            : RedirectToAction("Index", "Home");
    }

    [HttpPost("dang-xuat")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet("tu-choi")]
    public IActionResult AccessDenied()
    {
        return View();
    }
}
