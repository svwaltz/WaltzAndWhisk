using System;
using System.Collections.Generic;

namespace WaltzAndWhisk.Models
{
    public class Recipe
    {
        public int Id { get; set; }               // primary key
        public string Title { get; set; }
        public string Slug { get; set; }
        public string IntroNotes { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string ExtraNotes { get; set; }
        public string ImageUrl { get; set; }
        public int ActiveTimeMinutes { get; set; }
        public int InactiveTimeMinutes { get; set; }
        public int Servings { get; set; }
        public string MacrosPerServing { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // add this navigation property:
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
