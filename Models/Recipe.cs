using System;

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

    // Optional category for the recipe (Dessert, Breakfast, etc)
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    // Optional nutritional info
    public Macros? Macros { get; set; }

    // **single Ingredients section with multiple subsections**
    public IngredientsSection Ingredients { get; set; } = new IngredientsSection();

    // **single Instructions section with multiple subsections**
    public InstructionsSection Instructions { get; set; } = new InstructionsSection();

    // Multiple images for the recipe
    public ICollection<RecipeImage> Images { get; set; } = new List<RecipeImage>();

    public bool IsFeatured { get; set; } = false; // Highlight on homepage if true
}


// Represents a recipe category (Dessert, Breakfast, etc.)
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } // Category name
    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}


// Ingredients section contains multiple subsections (for complex recipes)
public class IngredientsSection
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }

    public ICollection<IngredientSubsection> Subsections { get; set; } = new List<IngredientSubsection>();
}


public class IngredientSubsection
{
    public int Id { get; set; }
    public int IngredientsSectionId { get; set; }
    public IngredientsSection IngredientsSection { get; set; }

    public string Title { get; set; } // e.g., "Cake," "Frosting"
    public ICollection<Ingredient> Items { get; set; } = new List<Ingredient>();
    public int Order { get; set; } // display order
}


public class Ingredient
{
    public int Id { get; set; }
    public int IngredientSubsectionId { get; set; }
    public IngredientSubsection IngredientSubsection { get; set; }

    public string Name { get; set; }
    public decimal Quantity { get; set; }
    public string? Unit { get; set; }
    public string? Notes { get; set; }
    public int Order { get; set; }
}


// Instructions section contains multiple subsections
public class InstructionsSection
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }

    public ICollection<InstructionSubsection> Subsections { get; set; } = new List<InstructionSubsection>();
}


public class InstructionSubsection
{
    public int Id { get; set; }
    public int InstructionsSectionId { get; set; }
    public InstructionsSection InstructionsSection { get; set; }

    public string Title { get; set; } // e.g., "Cake," "Frosting"
    public ICollection<Instruction> Steps { get; set; } = new List<Instruction>();
    public int Order { get; set; }
}


public class Instruction
{
    public int Id { get; set; }
    public int InstructionSubsectionId { get; set; }
    public InstructionSubsection InstructionSubsection { get; set; }

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


public class Macros
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }

    public int Calories { get; set; }
    public decimal Protein { get; set; }
    public decimal Carbs { get; set; }
    public decimal Fat { get; set; }
}