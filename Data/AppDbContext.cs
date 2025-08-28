using Microsoft.EntityFrameworkCore;
using WaltzAndWhisk.Models;

namespace WaltzAndWhisk.Data;

public class AppDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Instruction> Instructions { get; set; }
    public DbSet<RecipeImage> RecipeImages { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}