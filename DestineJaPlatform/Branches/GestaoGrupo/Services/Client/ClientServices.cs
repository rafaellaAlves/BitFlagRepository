using DTO.Client;
using DTO.Contract;
using DTO.Shared;
using DTO.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Client
{
    public class ClientServices : BaseServices<ApplicationDbContext.Models.Client, ClientViewModel, int>
    {
        private readonly UserManager<AspNetIdentityDbContext.User> userManager;
        private readonly ClientUserServices clientUserServices;

        public ClientServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, UserManager<AspNetIdentityDbContext.User> userManager, ClientUserServices clientUserServices) : base(context, identityContext, "ClientId")
        {
            this.userManager = userManager;
            this.clientUserServices = clientUserServices;
        }

        public async Task<bool> ExistClient(ClientViewModel model)
        {
            return await Task.Run(async () => await this.dbSet.AnyAsync(x => ((!string.IsNullOrWhiteSpace(model.CPF) && x.CPF == model.CPF) || (!string.IsNullOrWhiteSpace(model.CNPJ) && x.CNPJ == model.CNPJ)) && x.ClientId != model.ClientId && !x.IsDeleted));
        }

        public async Task<int> GetClientIdByLoggedUser(HttpContext context)
        {
            int? clientId = context.Session.GetInt32(Constants.UserClientSessionKey);

            if (clientId.HasValue) return clientId.Value;

            if (context.User.IsInRole("Cliente"))
            {
                var user = await userManager.GetUserAsync(context.User);
                clientId = (await clientUserServices.GetClientByUser(user.Id)).ClientId;

                context.Session.SetInt32(Constants.UserClientSessionKey, clientId.Value);

                return clientId.Value;
            }

            return -1;
        }

        public int GetClientIdByLoggedUser(HttpContext context, out int userId)
        {
            var user = userManager.GetUserAsync(context.User).Result;
            userId = user.Id;

            int? clientId = context.Session.GetInt32(Constants.UserClientSessionKey);

            if (clientId.HasValue) return clientId.Value;

            if (context.User.IsInRole("Cliente"))
            {
                clientId = clientUserServices.GetClientByUser(user.Id).Result.ClientId;

                context.Session.SetInt32(Constants.UserClientSessionKey, clientId.Value);

                return clientId.Value;
            }

            return -1;
        }

        public async Task<bool> IsSolicitation(int? clientId) => !clientId.HasValue ? false : (await GetDataByIdAsync(clientId.Value)).Solicitation;

        public async Task UpdateDemandFeedbackEmailSendedDate(int clientId)
        {
            var client = await GetDataByIdAsync(clientId);

            client.DemandFeedbackEmailSendedDate = DateTime.Now;

            this.dbSet.Update(client);
            await this.context.SaveChangesAsync();
        }

        public async Task<ClientNewContractViewModel> GetClientForNewContractViewModel(int clientId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetClientForNewContract @ClientId = @_ClientId";

            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));

            await context.Database.OpenConnectionAsync();

            var viewModel = new ClientNewContractViewModel();
            using var result = await command.ExecuteReaderAsync();

            await result.ReadAsync();
            viewModel = new ClientNewContractViewModel { Client = result.CopyToEntity<ClientViewModel>(), MainContact = result.CopyToEntity<ClientContactViewModel>("ClientContact"), MainAddress = result.CopyToEntity<ClientCollectionAddressViewModel>("ClientCollectionAddress"), FirstContract = result["FirstContract"].GetBoolFromDbDataReader().Value };

            await result.NextResultAsync();

            while (await result.ReadAsync())
                viewModel.Contacts.Add(result.CopyToEntity<ClientContactViewModel>());

            return viewModel;
        }
    }
}
