using System.Collections.Generic;
using System.ComponentModel;

namespace HandmadeItemMarket.Models
{
    public class Product
    {
        public Product()
        {
            this.ImageUrls=new List<string>();
            this.Coments=new List<Comment>();
        }
        public int Id { get; set; }
        public ApplicationUser Seller { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public string Category { get; set; }
        public IEnumerable<string> ImageUrls { get; set; }
        public IEnumerable<Comment> Coments { get; set; }
    }
}