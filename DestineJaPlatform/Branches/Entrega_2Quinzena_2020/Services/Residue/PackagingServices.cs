using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Residue
{
    public class PackagingServices : Shared.BaseListServices<Packaging, Packaging, int>
    {
        public PackagingServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "PackagingId")
        {
        }
    }
}
