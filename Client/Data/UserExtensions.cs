using System.Security.Claims;

namespace PWA_Project.Client.Data
{
    public static class UserExtensions
    {
        public static string UserName(this ClaimsPrincipal user)
            => user.Identity.Name;

        public static string Email(this ClaimsPrincipal user)
            => user.FindFirst("email").Value;
    }
}
