using Microsoft.EntityFrameworkCore;
using WaltzAndWhisk.Models;

namespace WaltzAndWhisk.Data;
public class AppDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}