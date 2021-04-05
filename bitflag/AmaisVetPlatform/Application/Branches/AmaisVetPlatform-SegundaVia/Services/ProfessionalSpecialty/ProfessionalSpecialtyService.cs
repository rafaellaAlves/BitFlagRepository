using DTO.ProfessionalSpecialty;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.ProfessionalSpecialty
{
    public class ProfessionalSpecialtyService
    {
        private ApplicationDbContext.Context.ApplicationDbContext context;
        public ProfessionalSpecialtyService(ApplicationDbContext.Context.ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<ProfessionalSpecialtyViewModel>> GetActiveAsync()
        {
            return await (from ps in context.ProfessionalSpecialty
                          where ps.IsActive
                          orderby ps.Name ascending
                          select new ProfessionalSpecialtyViewModel
                          {
                              ProfessionalSpecialtyId = ps.ProfessionalSpecialtyId,
                              Name = ps.Name
                          }).ToListAsync();
        }
    }
}
