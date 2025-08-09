using System;

namespace WaltzAndWhisk.Models;
public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
    public DateTime CreatedAt { get; set; }
}