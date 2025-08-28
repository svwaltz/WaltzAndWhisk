using Microsoft.AspNetCore.Mvc; // base namespace for MVC controllers/views
using WaltzAndWhisk.Models;
using WaltzAndWhisk.ViewModels; // access to our model classes (Recipe, etc.)
using WaltzAndWhisk.Data; // access to our AppDbContext
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WaltzAndWhisk.Controllers;

// RecipesController – for listing recipes, showing details, search, filtering, etc.
public class RecipesController : Controller
{
    private readonly ILogger<HomeController> _logger; // logger for writing info/warnings/errors to app logs

    private readonly AppDbContext _context; // db context for querying/saving data

    // constructor injection for logger and db context
    public RecipesController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        return View(id);
    }

    public IActionResult AddRecipe()
    {
        PopulateViewBagData();

        return View("AddRecipe");
    }

    private void PopulateViewBagData()
    {
        ViewBag.Categories = new List<SelectListItem>
        {
            new() { Value = "1", Text = "Breakfast" },
            new() { Value = "2", Text = "Lunch" },
            new() { Value = "3", Text = "Dinner" },
            new() { Value = "4", Text = "Salad" },
            new() { Value = "5", Text = "Snack" },
            new() { Value = "6", Text = "Dessert" },
            new() { Value = "7", Text = "Beverage" },
            new() { Value = "8", Text = "Other" }
        };

        ViewBag.Units = new List<SelectListItem>
        {
            new() { Value = "cup", Text = "cup" },
            new() { Value = "tablespoon", Text = "tablespoon" },
            new() { Value = "teaspoon", Text = "teaspoon" },
            new() { Value = "gram", Text = "gram" },
            new() { Value = "kilogram", Text = "kilogram" },
            new() { Value = "ounce", Text = "ounce" },
            new() { Value = "pound", Text = "pound" },
            new() { Value = "milliliter", Text = "milliliter" },
            new() { Value = "liter", Text = "liter" },
            new() { Value = "pinch", Text = "pinch" },
            new() { Value = "dash", Text = "dash" },
            new() { Value = "piece", Text = "piece" }
        };
    }

    [HttpPost]
    public async Task<IActionResult> SaveRecipe(Recipe recipe)
    {
        if (!ModelState.IsValid)
        {
            return View("AddRecipe", recipe); // return form with validation messages
        }

        // set timestamps
        recipe.CreatedDate = DateTime.UtcNow;
        recipe.UpdatedDate = DateTime.UtcNow;

        // add recipe to database
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // redirect to recipe details or list page
        return RedirectToAction("Details", new { id = recipe.Id });

        /* Form binding
            your <form> in cshtml posts a Recipe object.
            simple properties (Title, Description, PrepTimeMinutes, etc.) bind automatically.
            for more complex nested objects (IngredientsSection, InstructionsSection), you either:
            accept them as JSON in a hidden field and deserialize in the controller, or
            use JavaScript to dynamically add/remove subsections and steps, 
            giving each input a name like Ingredients.Subsections[0].Items[0].Name so EF can bind automatically.*/
    }
}
