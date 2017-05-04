using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandmadeItemMarket.Models.EntityModels
{
    public class RegisteredUser
    {
        public RegisteredUser()
        {
            this.ProductsBought=new HashSet<Product>();
            this.ProductsOffered = new HashSet<Product>();
            this.ProductsLiked=new HashSet<Product>();

        }
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string HomeTown { get; set; }
        [Required, MinLength(3)]
        public string Neighbourhood { get; set; }
        public virtual ICollection<Product> ProductsOffered { get; set; }
        public virtual ICollection<Product> ProductsLiked { get; set; }
        public virtual ICollection<Product> ProductsBought { get; set; }

        public string IdenityUserId { get; set; }
        [ForeignKey("IdenityUserId")]
        public virtual ApplicationUser IdentityUser { get; set; }
    }
}
