using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace HandmadeItemMarket.Models.EntityModels
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
     public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }

        public ApplicationUser()
        {
            this.Comments=new HashSet<Comment>();
            this.BlogPosts=new HashSet<BlogPost>();
            this.ProductsBought = new HashSet<Product>();
            this.ProductsOffered = new HashSet<Product>();
            this.ProductsLiked = new HashSet<Product>();
            this.OrdersPlaced = new HashSet<Order>();
            this.OrdersReceived = new HashSet<Order>();
        }
        [Required, MinLength(3)]
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
        [Required,MinLength(3)]
        public string HomeTown { get; set; }
        [Required,MinLength(3)]
        public string Neighbourhood { get; set; }
        public virtual ICollection<Product> ProductsOffered { get; set; }
        public virtual ICollection<Product> ProductsLiked { get; set; }
        public virtual ICollection<Product> ProductsBought { get; set; }
        public virtual ICollection<Order> OrdersPlaced { get; set; }
        public virtual ICollection<Order> OrdersReceived { get; set; }

    }
}