using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace Services.Client
{
    public class ClientUserServices : Shared.BaseServices<ClientUser, ClientUser, int>
    {
        private readonly UserManager<AspNetIdentityDbContext.User> userManager;

        public ClientUserServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, UserManager<AspNetIdentityDbContext.User> userManager) : base(context, identityContext, "ClientUserId")
        {
            this.userManager = userManager;
        }

        public async Task<bool> TryDelete(int clientId, int userId)
        {
            var entity = await this.dbSet.SingleOrDefaultAsync(x => x.ClientId == clientId && x.UserId == userId);

            if (entity == null) return false;

            this.dbSet.Remove(entity);
            await this.context.SaveChangesAsync();

            return true;
        }
        public async Task Create(int clientId, List<int> userIds)
        {
            await this.dbSet.AddRangeAsync(userIds.Select(x => new ClientUser
            {
                ClientId = clientId,
                UserId = x
            }));
            await this.context.SaveChangesAsync();
        }
        public async Task<ApplicationDbContext.Models.Client> GetClientByUser(int? userId)
        {
            if (!userId.HasValue) return null;

            var clientUser = await this.dbSet.FirstOrDefaultAsync(x => x.UserId == userId);
            if (clientUser == null) return null;

            return await this.context.Client.SingleAsync(x => x.ClientId == clientUser.ClientId);
        }
        public async Task<int> GetTotalUsersByClient(int clientId)
        {
            var clientUsers = await GetDataAsNoTrackingAsync(x => x.ClientId == clientId);

            return (from y in clientUsers
                    join u in this.identityContext.Users on y.UserId equals u.Id
                    where !u.IsDeleted
                    select y).Count();
        }
        public async Task<int> GetTotalUsersByLoggedUser(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);
            var clientId = (await GetClientByUser(user.Id)).ClientId;

            return await GetTotalUsersByClient(clientId);
        }

        public async Task<bool> ClientHasUser(int userId) => await dbSet.AnyAsync(x => x.UserId == userId);
    }
}
