using System.Diagnostics; // lets us use Activity for tracking request IDs
using Microsoft.AspNetCore.Mvc; // base namespace for MVC controllers/views
using WaltzAndWhisk.ViewModels; // access to our model classes (Recipe, etc.)
using WaltzAndWhisk.Data; // access to our AppDbContext
using WaltzAndWhisk.Models; // access to our model classes (Recipe, etc.)
using Microsoft.EntityFrameworkCore; // for async LINQ queries to the database
 
namespace WaltzAndWhisk.Controllers;

// HomeController – for the homepage, about page, contact, etc.
public class HomeController : Controller
{
    // GET TEST RECIPES -- DUMMY DATA 
    private List<Recipe> GetTestRecipes()
    {
        return new List<Recipe>
        {
            new Recipe
            {
                Id = 1,
                Title = "Browned Butter Chocolate Chip Cookies",
                Ingredients = "Flour, Sugar, Butter, Chocolate chips, Eggs",
                Instructions = "Mix ingredients, bake at 350°F for 12 minutes.",
                CreatedAt = DateTime.Now.AddDays(-10),
                Description = "Crispy on the outside, chewy on the inside.",
                ImageUrl = "/images/desserts/chocolatechipcookies.jpeg",
                IsFeatured = true
            },
            new Recipe
            {
                Id = 2,
                Title = "Spaghetti Carbonara",
                Ingredients = "Spaghetti, Eggs, Pancetta, Parmesan cheese, Black pepper",
                Instructions = "Cook pasta, mix eggs and cheese, add pancetta, combine all.",
                CreatedAt = DateTime.Now.AddDays(-7),
                Description = "Creamy and savory classic Italian pasta.",
                ImageUrl = "/images/meals/carbonara.jpeg",
                IsFeatured = false
            },
            // add more recipes as needed
        };
    }


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
        /*var featuredRecipes = await _context.Recipes
            .Where(r => r.IsFeatured)  // if you have this property, otherwise filter as needed
            .ToListAsync();

        var latestRecipes = await _context.Recipes
            .OrderByDescending(r => r.CreatedAt)
            .Take(5)
            .ToListAsync();*/

        var recipes = GetTestRecipes();
        var featuredRecipes = recipes.Take(2).ToList();
        var latestRecipes = recipes.OrderByDescending(r => r.CreatedAt).Take(5).ToList();

        var viewModel = new HomeViewModel
        {
            FeaturedRecipes = featuredRecipes,
            LatestRecipes = latestRecipes
        };

        return View(viewModel);
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
