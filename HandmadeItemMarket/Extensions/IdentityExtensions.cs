using System.Security.Claims;
using System.Security.Principal;

namespace HandmadeItemMarket.Extensions
{
    public static class IdentityExtensions
    {
        public static string ProfilePictureUrl(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("ProfilePictureUrl");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string RegisterDate(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("RegisterDate");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string ProductsOffered(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("ProductsOffered");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string ProductsLiked(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("ProductsLiked");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string ProductsBought(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("ProductsBought");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}