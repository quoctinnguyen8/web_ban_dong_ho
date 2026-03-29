using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDongHo.Web.Data;

namespace WebBanDongHo.Web.Controllers;

[Route("san-pham")]
public class ProductsController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public ProductsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id:int}")]
    public IActionResult Details(int id)
    {
        var watch = _dbContext.AppWatches
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id && x.DeletedDate == null);

        if (watch is null)
        {
            return NotFound();
        }

        return View(watch);
    }
}
