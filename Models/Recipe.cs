using System;
using System.ComponentModel.DataAnnotations;

namespace WaltzAndWhisk.Models;

// Represents a single recipe
public class Recipe
{
    public int Id { get; set; } // Primary key
    public string Title { get; set; } // Recipe title
    public string? Description { get; set; } // Optional description
    public int PrepTimeMinutes { get; set; } // Preparation time
    public int CookTimeMinutes { get; set; } // Cooking time
    public int InactiveTimeMinutes { get; set; } // Inactive/Rest time
    public int NumServings { get; set; } // Number of servings
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Creation timestamp
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow; // Last update timestamp
    public string Category { get; set; } // Category name (Dessert, Breakfast, etc)

    // **Nutritional info**
    public int Calories { get; set; }
    public decimal Protein { get; set; }
    public decimal Carbs { get; set; }
    public decimal Fat { get; set; }

    // **Ingredient and Instruction Sections**
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();

    public ICollection<RecipeImage> Images { get; set; } = new List<RecipeImage>(); // Multiple images for the recipe
    public bool IsFeatured { get; set; } = false; // Highlight on homepage if true
}

public class Ingredient
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public string Section { get; set; } // e.g., "Cake," "Frosting"
    public string IngredientName { get; set; }
    public decimal Quantity { get; set; }
    public string? Unit { get; set; }
}


public class Instruction
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public string Section { get; set; } // e.g., "Cake," "Frosting"
    public string StepText { get; set; }
    public int Order { get; set; }
}


public class RecipeImage
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public string ImageUrl { get; set; }
    public int Order { get; set; }
}