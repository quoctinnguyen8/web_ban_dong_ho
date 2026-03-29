using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDongHo.Web.Data;
using WebBanDongHo.Web.Models;

namespace WebBanDongHo.Web.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var watches = _dbContext.AppWatches
            .AsNoTracking()
            .Where(x => x.DeletedDate == null)
            .OrderByDescending(x => x.CreatedDate)
            .Take(12)
            .ToList();

        return View((IReadOnlyList<AppWatch>)watches);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
