using ApplicationDbContext.Models;
using DTO.Residue;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Services.Residue
{
    public class ResiduePriceListServices : Shared.BaseListServices<ResiduePriceList, ResiduePriceListViewModel, int>
    {
        public ResiduePriceListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ResiduePriceId")
        {
        }
    }
}
