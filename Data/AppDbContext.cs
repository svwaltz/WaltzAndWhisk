using Microsoft.EntityFrameworkCore;
using WaltzAndWhisk.Models;

namespace WaltzAndWhisk.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeSection> RecipeSections { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<InstructionStep> InstructionSteps { get; set; }
    }
}
