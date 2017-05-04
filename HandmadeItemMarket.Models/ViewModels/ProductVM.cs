

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HandmadeItemMarket.Models.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; }
        [Required, Range(0,int.MaxValue)]
        public decimal Price { get; set; }
        [Required, MinLength(3)]
        public string Description { get; set; }
        public string Seller { get; set; }
        public int Rating { get; set; }
        [Required, MinLength(3)]
        public string Category { get; set; }
        public string Image { get; set; }
    }
}