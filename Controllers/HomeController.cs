using System.Diagnostics; // lets us use Activity for tracking request IDs
using Microsoft.AspNetCore.Mvc; // base namespace for MVC controllers/views
using WaltzAndWhisk.ViewModels; // access to our model classes (Recipe, etc.)
using WaltzAndWhisk.Data; // access to our AppDbContext
using Microsoft.EntityFrameworkCore; // for async LINQ queries to the database
 
namespace WaltzAndWhisk.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger; // logger for writing info/warnings/errors to app logs

    private readonly AppDbContext _context; // db context for querying/saving data

    // constructor injection for logger and db context
    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // homepage
    public async Task<IActionResult> Index()
    {
        // pull the latest 5 recipes from database
        var latestRecipes = await _context.Recipes
            .OrderByDescending(r => r.CreatedAt)
            .Take(5)
            .ToListAsync();

        return View(latestRecipes); // pass recipes to the view
    }

    // privacy policy page 
    public IActionResult Privacy()
    {
        return View();
    }

    // error handler 
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
