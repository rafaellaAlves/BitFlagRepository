using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Residue
{
    public class ResidueFamilyClassService : Shared.BaseListServices<ResidueFamilyClass, ResidueFamilyClass, int>
    {
        public ResidueFamilyClassService(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ResidueFamilyClassId")
        {
        }
    }
}
