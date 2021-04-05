using ApplicationDbContext.Models;
using DTO.Residue;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Residue
{
    public class ResidueFamilyListService : Shared.BaseListServices<ResidueFamilyList, ResidueFamilyListViewModel, int>
    {
        public ResidueFamilyListService(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ResidueFamilyId")
        {
        }
    }
}
