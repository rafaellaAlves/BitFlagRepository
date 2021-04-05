using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ServiceClientCollectionAddressServices : Shared.BaseServices<ServiceClientCollectionAddress, ServiceClientCollectionAddress, int>
    {
        public ServiceClientCollectionAddressServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ServiceClientCollectionAddressId")
        {
        }

        public async Task CreateRangeAsync(IEnumerable<ServiceClientCollectionAddress> datas)
        {
            if (datas.Count() == 0) return;

            await this.dbSet.AddRangeAsync(datas);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDefinitivelyByServiceId(int serviceId)
        {
            this.dbSet.RemoveRange(await GetDataAsync(x => x.ServiceId == serviceId));
            await this.context.SaveChangesAsync();
        }

        public async Task<List<ServiceClientCollectionAddress>> GetDataByServiceIdAsync(int? serviceId) => serviceId.HasValue ? await GetDataAsNoTrackingAsync(x => x.ServiceId == serviceId) : new List<ServiceClientCollectionAddress>();
    }
}
