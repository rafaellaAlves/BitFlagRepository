using ApplicationDbContext.Models;
using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DTO.Shared;
using System.Linq;

namespace Services.Client
{
    public class ClientCollectionAddressServices : Shared.BaseServices<ClientCollectionAddress, ClientCollectionAddressViewModel, int>
    {
        public ClientCollectionAddressServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientCollectionAddressId")
        {
        }
        public async Task<bool> ExistMainAddress(int clientId, int? clientCollectionAddressId) => await this.dbSet.AnyAsync(x => x.Main && x.ClientId == clientId && (!clientCollectionAddressId.HasValue || x.ClientCollectionAddressId != clientCollectionAddressId));

        public async Task<ClientCollectionAddress> GetMainAddress(int clientId) => await this.dbSet.FirstOrDefaultAsync(x => x.Main && x.ClientId == clientId);

        public async Task RemoveMainAddressFromClient(int clientId)
        {
            var entities = await GetDataAsync(x => x.Main && x.ClientId == clientId);
            entities.ForEach(x => x.Main = false);

            this.dbSet.UpdateRange(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<AddressBaseViewModel>> GetAllCities() => await Task.Run(() => this.dbSet.Select(x => new AddressBaseViewModel { State = x.State, City = x.City }).Distinct().ToList());
    }
}
