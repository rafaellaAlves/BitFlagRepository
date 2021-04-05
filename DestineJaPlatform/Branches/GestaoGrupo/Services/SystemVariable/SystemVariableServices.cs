using System;
using System.Collections.Generic;
using System.Text;

namespace Services.SystemVariable
{
    public class SystemVariableServices : Shared.BaseListServices<ApplicationDbContext.Models.SystemVariable, ApplicationDbContext.Models.SystemVariable, string>
    {
        public SystemVariableServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "Key")
        {
        }
    }
}
