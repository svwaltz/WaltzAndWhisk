namespace WaltzAndWhisk.Models
{
    // this model exists only for the homepage to group different sets of data we want to display
    public class HomeViewModel
    {
        // list of highlighted recipes for the "featured" section
        public List<Recipe> FeaturedRecipes { get; set; } = new();

        // list of most recent recipes for the "latest creations" section
        public List<Recipe> LatestRecipes { get; set; } = new();
    }
}
