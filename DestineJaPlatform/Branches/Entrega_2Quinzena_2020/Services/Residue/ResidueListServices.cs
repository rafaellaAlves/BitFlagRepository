using ApplicationDbContext.Models;
using DTO.Residue;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Residue
{
    public class ResidueListServices : Shared.BaseListServices<ResidueList, ResidueListViewModel, int>
    {
        public ResidueListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ResidueId")
        {
        }
    }
}
