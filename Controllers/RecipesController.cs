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
        ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
        return View("AddRecipe");
    }

    [HttpPost]
    public async Task<IActionResult> SaveRecipe(Recipe recipe, string? newCategory)
    {
        // populate categories for the form in case of validation errors
        ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");

        if (!ModelState.IsValid)
        {
            return View("AddRecipe", recipe); // return form with validation messages
        }

        // handle new category creation
        if (!string.IsNullOrWhiteSpace(newCategory))
        {
            var category = new Category { Name = newCategory };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            recipe.CategoryId = category.Id;
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
