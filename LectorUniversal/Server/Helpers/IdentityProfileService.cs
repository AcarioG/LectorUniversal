using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using LectorUniversal.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LectorUniversal.Server.Helpers
{
    public class IdentityProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory;
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityProfileService(IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            UserManager<ApplicationUser> userManager)
        {
            this.claimsFactory = claimsFactory;
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(userId);
            var role = await userManager.GetRolesAsync(user);
            var roles = await userManager.GetUsersInRoleAsync(role.ToString());
            var claimsPrincipal = await claimsFactory.CreateAsync(user);
            var claims = claimsPrincipal.Claims.ToList();


            var claimsMapped = new List<Claim>();



            foreach (var claim in claims)
            {
                if (claim.Type == JwtClaimTypes.Role)
                {
                    claimsMapped.Add(new Claim(ClaimTypes.Role, claim.Value));
                    claimsMapped.Add(new Claim("sub", userId));
                    claimsMapped.Add(new Claim("AspNet.Identity.SecurityStamp", user.SecurityStamp));
                    claimsMapped.Add(new Claim("role", claim.Value));
                    claimsMapped.Add(new Claim("name", user.UserName));
                    claimsMapped.Add(new Claim("email", user.Email));

                }
            }

            claims.Clear();
            claims.AddRange(claimsMapped);
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(userId);
            context.IsActive = user != null;
        }
    }
}
