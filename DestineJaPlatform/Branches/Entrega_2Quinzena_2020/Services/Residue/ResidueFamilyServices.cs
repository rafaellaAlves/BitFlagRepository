using ApplicationDbContext.Models;
using DTO.Residue;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using DTO.Shared;

namespace Services.Residue
{
    public class ResidueFamilyServices : Shared.BaseServices<ResidueFamily, ResidueFamilyViewModel, int>
    {
        public ResidueFamilyServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ResidueFamilyId")
        {
        }

        public async Task<ReturnResult> ValidateResidueFamiliesForDemand(List<int> residueFamilyIds)
        {
            var errors = new List<string>();
            var residueFamilies = await GetDataAsNoTrackingAsync(x => residueFamilyIds.Contains(x.ResidueFamilyId));

            foreach (var residueFamily in residueFamilies.Where(x => !x.AcceptDifferentFamilies))
            {
                if (!residueFamilies.Any(x => x.GroupName != residueFamily.GroupName)) continue;

                errors.Add($"A família \"{residueFamily.Name}\" deverá ser coletada em MTR próprio e sem adição de outros resíduos. Para coletar demais famílias neste cliente listado, crie outro MTR apontando as demais famílias desejadas.");
            }

            return new ReturnResult(errors, "", errors.Count > 0);
        }
    }
}
