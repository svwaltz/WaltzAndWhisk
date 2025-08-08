using System.Collections.Generic;

namespace WaltzAndWhisk.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string MacrosPerServing { get; set; }
        public string ImageUrl { get; set; }
        public int ActiveTimeMinutes { get; set; }
        public int InactiveTimeMinutes { get; set; }
        public int Servings { get; set; }
        public ICollection<RecipeSection> Sections { get; set; }

    }
}
