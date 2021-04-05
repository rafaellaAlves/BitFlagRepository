using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OptionPresence
{
    public class OptionPresenceService
    {
        private readonly ApplicationDbContext.ApplicationDbContext context;
        IMemoryCache memoryCache;

        public OptionPresenceService(ApplicationDbContext.ApplicationDbContext context, IMemoryCache memoryCache)
        {
            this.context = context;
            this.memoryCache = memoryCache;
        }

        public async Task<List<ApplicationDbContext.OptionPresence>> List()
        {
            if (!memoryCache.TryGetValue("Services.OptionPresence.List", out List<ApplicationDbContext.OptionPresence> r))
            {
                r = await this.context.OptionPresence.ToListAsync();
                memoryCache.Set("Services.OptionPresence.List", r, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            }

            return r;
        }
    }
}
