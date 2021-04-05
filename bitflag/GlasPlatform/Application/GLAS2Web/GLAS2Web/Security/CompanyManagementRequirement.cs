using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.Security
{
    public class CompanyManagementRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> Roles { get; private set; }
        public CompanyManagementRequirement(IEnumerable<string> roles)
        {
            this.Roles = roles;
        }
    }
}
