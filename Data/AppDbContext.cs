using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=tcp:waltzsqlserver.database.windows.net,1433;Initial Catalog={database_name};Persist Security Info=False;User ID=svwaltz;Password=Waltz6120;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}
