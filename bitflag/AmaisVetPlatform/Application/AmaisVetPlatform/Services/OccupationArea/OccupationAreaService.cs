using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DTO.OccupationArea;
using Microsoft.EntityFrameworkCore;

namespace Services.OccupationArea
{
    public class OccupationAreaService
    {
        private ApplicationDbContext.Context.ApplicationDbContext context;
        public OccupationAreaService(ApplicationDbContext.Context.ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<OccupationAreaViewModel>> GetActiveAsync()
        {
            return await (from oa in context.OccupationArea
                          where oa.IsActive
                          orderby oa.Name ascending
                          select new OccupationAreaViewModel
                          {
                              OccupationAreaId = oa.OccupationAreaId,
                              Name = oa.Name
                          }).ToListAsync();
        }
    }
}
