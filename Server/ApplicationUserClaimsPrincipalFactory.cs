using Microsoft.AspNetCore.Identity;
using PWA_Project.Server.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PWA_Project.Server
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("email", user.Email ?? ""));
            return identity;
        }
    }
}
