using System;

namespace WaltzAndWhisk.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsFeatured { get; set; } = false; // indicates if this recipe should be highlighted on the homepage

    public string? Description { get; set; }
    public string? ImageUrl { get; set; } // URL to an image of the recipe
}