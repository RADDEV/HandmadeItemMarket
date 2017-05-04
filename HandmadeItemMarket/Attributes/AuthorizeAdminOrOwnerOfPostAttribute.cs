using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HandmadeItemMarket.Data;

namespace HandmadeItemMarket.Attributes
{
    public class AuthorizeAdminOrOwnerOfPostAttribute : AuthorizeAttribute
    {
        private HandmadeItemMarketContext db = new HandmadeItemMarketContext();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // The user is not authenticated
                return false;
            }

            var user = httpContext.User;
            if (user.IsInRole("Admin"))
            {
                // Administrator => let him in
                return true;
            }

            var rd = httpContext.Request.RequestContext.RouteData;
            int id = int.Parse(rd.Values["id"] as string) ;
            if (id==0)
            {
                // No id was specified => we do not allow access
                return false;
            }

            return IsOwnerOfPost(user.Identity.Name, id);
        }

        private bool IsOwnerOfPost(string username, int postId)
        {
            if (db.Products.FirstOrDefault(p=>p.Id==postId).Seller.UserName==username)
            {
                return true;
            }
            return false;
        }
    }
}