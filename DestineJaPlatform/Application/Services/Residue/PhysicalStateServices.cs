using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Residue
{
    public class PhysicalStateServices : Shared.BaseListServices<PhysicalState, PhysicalState, int>
    {
        public PhysicalStateServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "PhysicalStateId")
        {
        }
    }
}
