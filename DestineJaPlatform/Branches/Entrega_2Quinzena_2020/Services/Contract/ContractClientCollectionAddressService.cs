using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public class ContractClientCollectionAddressService : Shared.BaseServices<ContractClientCollectionAddress, ContractClientCollectionAddress, int>
    {
        public ContractClientCollectionAddressService(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ContractClientCollectionAddressId")
        {
        }

        public async Task CreateRangeAsync(IEnumerable<ContractClientCollectionAddress> datas)
        {
            if (datas.Count() == 0) return;

            await this.dbSet.AddRangeAsync(datas);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDefinitivelyByContractId(int contractId)
        {
            this.dbSet.RemoveRange(await GetDataAsync(x => x.ContractId == contractId));
            await this.context.SaveChangesAsync();
        }

        public async Task<List<ContractClientCollectionAddress>> GetDataByContractIdAsync(int? contractId) => contractId.HasValue ? await GetDataAsNoTrackingAsync(x => x.ContractId == contractId) : new List<ContractClientCollectionAddress>();
    }
}
