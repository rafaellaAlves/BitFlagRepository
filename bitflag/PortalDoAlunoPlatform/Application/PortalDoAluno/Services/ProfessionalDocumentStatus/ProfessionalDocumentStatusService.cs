using DTO.ProfessionalDocumentStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfessionalDocumentStatus
{
    public class ProfessionalDocumentStatusService
    {
        ApplicationDbContext.ApplicationDbContext context;
        IMemoryCache memoryCache;
        public ProfessionalDocumentStatusService(ApplicationDbContext.ApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
        {
            this.context = applicationDbContext;
            this.memoryCache = memoryCache;
        }
        public async Task<List<ProfessionalDocumentStatusViewModel>> List()
        {
            if (!memoryCache.TryGetValue("Services.ProfessionalDocumentStatus.List", out List<ProfessionalDocumentStatusViewModel> professionalDocumentStatusViewModels))
            {
                professionalDocumentStatusViewModels = await this.context.ProfessionalDocumentStatus.Select(x => new ProfessionalDocumentStatusViewModel() { StatusId = x.StatusId, Description = x.Description }).ToListAsync();
                memoryCache.Set("Services.ProfessionalDocumentStatus.List", professionalDocumentStatusViewModels, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            }

            return professionalDocumentStatusViewModels;
        }
    }
}
