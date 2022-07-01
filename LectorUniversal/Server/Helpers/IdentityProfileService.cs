using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
<<<<<<< HEAD
=======
using LectorUniversal.Server.Models;
>>>>>>> RoleAdmin added
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LectorUniversal.Server.Helpers
{
    public class IdentityProfileService : IProfileService
    {
<<<<<<< HEAD
        private readonly IUserClaimsPrincipalFactory<IdentityUser> claimsFactory;
        private readonly UserManager<IdentityUser> userManager;

        public IdentityProfileService(IUserClaimsPrincipalFactory<IdentityUser> claimsFactory,
            UserManager<IdentityUser> userManager)
=======
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory;
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityProfileService(IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            UserManager<ApplicationUser> userManager)
>>>>>>> RoleAdmin added
        {
            this.claimsFactory = claimsFactory;
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
<<<<<<< HEAD
            var userId = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(userId);
            var claimsPrincipal = await claimsFactory.CreateAsync(user);
            var claims = claimsPrincipal.Claims.ToList();

            var claimsMapped = new List<Claim>();
=======
            var userioId = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(userioId);
            var claimsPrincipal = await claimsFactory.CreateAsync(user);
            var claims = claimsPrincipal.Claims.ToList();

            var claimsMapeados = new List<Claim>();
>>>>>>> RoleAdmin added

            foreach (var claim in claims)
            {
                if (claim.Type == JwtClaimTypes.Role)
                {
<<<<<<< HEAD
                    claimsMapped.Add(new Claim(ClaimTypes.Role, claim.Value));
                }
            }

            claims.AddRange(claimsMapped);
=======
                    claimsMapeados.Add(new Claim(ClaimTypes.Role, claim.Value));
                }
            }

            claims.AddRange(claimsMapeados);
>>>>>>> RoleAdmin added

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
