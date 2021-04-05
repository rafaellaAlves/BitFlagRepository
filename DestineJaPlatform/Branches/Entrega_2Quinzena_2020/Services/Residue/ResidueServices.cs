using DTO.Residue;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Residue
{
    public class ResidueServices : Shared.BaseServices<ApplicationDbContext.Models.Residue, ResidueViewModel, int>
    {
        public ResidueServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ResidueId")
        {
        }

        public async Task DeleteByFamilyIdAsync(int familyId, int userId)
        {
            foreach (var item in await GetDataAsNoTrackingAsync(x => x.ResidueFamilyId == familyId))
                await DeleteAsync(item.ResidueId, userId);
        }

        public async Task<bool> ExistResidue(ResidueViewModel model)
        {
            return await this.dbSet.AnyAsync(x => !model.ResidueId.HasValue && x.IBAMACode == model.IBAMACode && x.ResidueFamilyId == model.ResidueFamilyId);
        }
    }
}
