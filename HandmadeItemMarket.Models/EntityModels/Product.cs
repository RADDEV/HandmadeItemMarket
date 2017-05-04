using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HandmadeItemMarket.Models.EntityModels
{
    public class Product
    {
        public Product()
        {
            this.Comments=new HashSet<Comment>();
            this.LikedBy=new HashSet<RegisteredUser>();
            this.Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public virtual ApplicationUser Seller { get; set; }
        [Required,MinLength(3)]
        public string Name { get; set; }
        [Required,Range(0,int.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Rating { get; set; }
        [Required, MinLength(3)]
        public string Category { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<RegisteredUser> LikedBy { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}