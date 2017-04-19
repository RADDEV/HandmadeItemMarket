using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HandmadeItemMarket.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("ProfilePictureUrl", this.ProfilePictureUrl.ToString()));
            userIdentity.AddClaim(new Claim("RegisterDate", this.RegisterDate.ToString()));
            userIdentity.AddClaim(new Claim("ProductsOffered", this.ProductsOffered.ToString()));
            userIdentity.AddClaim(new Claim("ProductsLiked", this.ProductsLiked.ToString()));
            userIdentity.AddClaim(new Claim("ProductsBought", this.ProductsBought.ToString()));
           
            return userIdentity;
        }

        public string ProfilePictureUrl { get; set; }
        public DateTime RegisterDate { get; set; }
        public IEnumerable<Product> ProductsOffered { get; set; }
        public IEnumerable<Product> ProductsLiked { get; set; }
        public IEnumerable<Product> ProductsBought { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<Comment> Comments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}