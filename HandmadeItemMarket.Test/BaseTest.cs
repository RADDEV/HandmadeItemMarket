using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandmadeItemMarket.Test
{
    using Data;
    using Data.Mocks;
    using Models.EntityModels;

    public class BaseTest
    {
        protected MockedHandmadeItemMarketContext dbContext;

        public BaseTest()
        {
             this.dbContext = new MockedHandmadeItemMarketContext();
            //this.SeedData();
        }

        //private void SeedData()
        //{
        //    this.dbContext.Users.Add(new ApplicationUser()
        //    {
        //        UserName = "kircata@picha.com",
        //        HomeTown = "Sofia",
        //        Neighbourhood = "Slatina",
        //         Name= "Kiril",
        //        RegisterDate = new DateTime(1998, 01, 06),
        //        Id = "asdasds234234yd",
        //        PasswordHash = "asdhasdgahsdghas"
        //    });
        //    this.dbContext.Users.Add(new ApplicationUser()
        //    {
        //        UserName = "bojkata@picha.com",
        //        HomeTown = "Sofia",
        //        Name = "Bojidar",
        //        Neighbourhood = "Slatina",
        //        RegisterDate = new DateTime(1996, 06, 01),
        //        Id = "asdagus234234ab",
        //        PasswordHash = "asdhasdgahsdghas"
        //    });
        //    this.dbContext.Users.Add(new ApplicationUser()
        //    {
        //        UserName = "slav@picha.com",
        //        HomeTown = "Sliven",
        //        Name = "Slav",
        //        Neighbourhood = "ruski",
        //        RegisterDate = new DateTime(1997, 06, 01),
        //        Id = "andagds234734ad",
        //        PasswordHash = "asdhasdgahsdghas"
        //    });

        //    this.dbContext.Users.Add(new ApplicationUser()
        //    {
        //        UserName = "jicata@picha.com",
        //        HomeTown = "Sofia",
        //        Name = "Svetlin",
        //        Neighbourhood = "Centar",
        //        RegisterDate = new DateTime(1957, 06, 01),
        //        Id = "asdagds2345348d",
        //        PasswordHash = "asdhasdgahsdghas"
        //    });
        //    this.dbContext.Users.Add(new ApplicationUser()
        //    {
        //        UserName = "duci@picha.com",
        //        HomeTown = "Sofia",
        //        Name = "Niki",
        //        Neighbourhood = "Slatina",
        //        RegisterDate = new DateTime(1957, 06, 01),
        //        Id = "asdfgds2342348d",
        //        PasswordHash = "asdhasdgahsdghas"
        //    });
        //    this.dbContext.Products.Add(new Product()
        //    {
        //      Name  = "grivna",
        //      Price = 11,
        //      Image = "/images/snimka.jpg",
        //      Description = "Mnogo qka",
        //      Rating = 4,
        //      Seller = dbContext.Users.FirstOrDefault(),
        //      Category = "Weddings"
        //    });
        //    this.dbContext.Products.Add(new Product()
        //    {
        //        Name = "Roklq",
        //        Price = 17,
        //        Image = "/images/snimka.jpg",
        //        Description = "Mnogo mn qka",
        //        Rating = 4,
        //        Seller = dbContext.Users.FirstOrDefault(),
        //        Category = "Weddings"
        //    });
        //    this.dbContext.Products.Add(new Product()
        //    {
        //        Name = "neshto",
        //        Price = 11,
        //        Image = "/images/snimka.jpg",
        //        Description = "qkoo",
        //        Rating = 4,
        //        Seller = dbContext.Users.FirstOrDefault(),
        //        Category = "nesto"
        //    });
        //    this.dbContext.Products.Add(new Product()
        //    {
        //        Name = "kartina",
        //        Price = 144,
        //        Image = "/images/snimka.jpg",
        //        Description = "BOMBA!!",
        //        Rating = 4,
        //        Seller = dbContext.Users.FirstOrDefault(),
        //        Category = "Art"
        //    });
        //    this.dbContext.BlogPosts.Add(new BlogPost()
        //    {
        //        Title = "novina",
        //        Content = "mnogo qko",
        //        DatePosted = new DateTime(1997, 06, 01),
        //        Image = "/images/snimka2.jpg"
        //    });
        //    this.dbContext.BlogPosts.Add(new BlogPost()
        //    {
        //        Title = "novina2",
        //        Content = "mnogo qko2",
        //        DatePosted = new DateTime(1998, 06, 01),
        //        Image = "/images/snimka4.jpg"
        //    });
        //}
    }
}
