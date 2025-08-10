using WaltzAndWhisk.Models; // access to our model classes (Recipe, etc.)

namespace WaltzAndWhisk.ViewModels;

// this model exists only for the recipes
public class RecipeViewModel
{
    public Recipe Recipe { get; set; } // single recipe details
    public List<Recipe> RelatedRecipes { get; set; } = new(); // list of related recipes to show on the details page
}