using System.Collections.Generic;

namespace WaltzAndWhisk.Models
{
    public class RecipeSection
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public string SectionType { get; set; } // "Ingredients", "Instructions", "Notes", etc
        public string Title { get; set; }       // e.g. "Dough", "Filling"

        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<InstructionStep> InstructionSteps { get; set; }
        public string TextContent { get; set; } // for notes, calories, etc.
    }
}
