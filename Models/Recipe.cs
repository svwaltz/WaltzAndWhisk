using System;

namespace WaltzAndWhisk.Models
{
    public class Recipe
    {
        public int Id { get; set; }               // primary key
        public string Title { get; set; }         // recipe title
        public string Slug { get; set; }          // url-friendly title
        public string Description { get; set; }   // short blurb
        public string Ingredients { get; set; }   // ingredients text
        public string Instructions { get; set; }  // instructions text
        public string ImageUrl { get; set; }      // optional image
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
