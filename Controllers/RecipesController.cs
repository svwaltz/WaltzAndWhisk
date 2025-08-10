using Microsoft.AspNetCore.Mvc; // base namespace for MVC controllers/views

namespace WaltzAndWhisk.Controllers;

// RecipesController – for listing recipes, showing details, search, filtering, etc.
public class RecipesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        return View(id);
    }
}
