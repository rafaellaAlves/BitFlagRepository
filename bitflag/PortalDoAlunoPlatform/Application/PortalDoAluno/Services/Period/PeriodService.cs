using DTO.Period;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Period
{
   public class PeriodService
    {
        ApplicationDbContext.ApplicationDbContext context;
        IMemoryCache memoryCache;

        public PeriodService(ApplicationDbContext.ApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
        {
            this.context = applicationDbContext;
            this.memoryCache = memoryCache;
        }

        public async Task<List<PeriodViewModel>> List()
        {
            if (!memoryCache.TryGetValue("Services.Period.List", out List<PeriodViewModel> periodViewModels))
            {
               periodViewModels = await this.context.Period.Select(x => new PeriodViewModel() { PeriodId = x.PeriodId, Description = x.Description }).ToListAsync();
                memoryCache.Set("Services.Period.List", periodViewModels, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            }

            return periodViewModels;
        }
       
    }
}
