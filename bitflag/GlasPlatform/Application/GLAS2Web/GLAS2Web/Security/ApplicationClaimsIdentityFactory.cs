using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GLAS2Web.Security
{
    public class ApplicationClaimsIdentityFactory : UserClaimsPrincipalFactory<DAL.Identity.User, DAL.Identity.Role>
    {
        public ApplicationClaimsIdentityFactory(UserManager<User> userManager, RoleManager<DAL.Identity.Role> roleManager, IOptions<IdentityOptions> optionsAccessor) 
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(DAL.Identity.User user)
        {
            var principal = await base.CreateAsync(user);
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] { new Claim("CultureInfo", user.CultureInfo ?? "pt-BR") });

            return principal;
        }
    }
}
