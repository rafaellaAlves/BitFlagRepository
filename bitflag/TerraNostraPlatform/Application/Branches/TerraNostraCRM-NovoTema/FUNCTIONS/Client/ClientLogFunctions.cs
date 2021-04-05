using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using DTO.Client;

namespace FUNCTIONS.Client
{
    public class ClientLogFunctions : BasicFunctions<DB.ClientLog, DTO.Client.ClientLogViewModel>
    {
        public ClientLogFunctions(TerraNostraContext context)
            : base(context, "ClientLogId")
        {
        }

        public override int Create(ClientLogViewModel model)
        {
            var clientLog = new DB.ClientLog
            {
                ClientId = model.ClientId,
                Message = model.Message,
                UserId = model.UserId,
                Title = model.Title,
                PlainText = model.PlainText,
                //CreatedDate = DateTime.Now
            };

            this.dbSet.Add(clientLog);
            this.context.SaveChanges();

            return clientLog.ClientLogId;
        }

        public override void Delete(object id)
        {
            var clientLog = this.GetDataByID(id);

            clientLog.IsDeleted = true;
            clientLog.DeletedDate = DateTime.Now;

            this.dbSet.Update(clientLog);
            this.context.SaveChanges();
        }

        public override List<ClientLogViewModel> GetDataViewModel(IEnumerable<ClientLog> data)
        {
            var user = this.context.User.ToList();

            return (from y in data
                    select new ClientLogViewModel
                    {
                        ClientId = y.ClientId,
                        ClientLogId = y.ClientLogId,
                        CreatedDate = y.CreatedDate,
                        DeletedDate = y.DeletedDate,
                        IsDeleted = y.IsDeleted,
                        Message = y.Message,
                        ModificatedDate = y.ModificatedDate,
                        UserId = y.UserId,
                        Title = y.Title,
                        PlainText = y.PlainText,
                        UserFullName = user.Any(x => x.UserId == y.UserId)? user.Single(x => x.UserId == y.UserId).FirstName + " " + user.Single(x => x.UserId == y.UserId).LastName : ""
                    }).ToList();
        }

        public override ClientLogViewModel GetDataViewModel(ClientLog data)
        {
            var user = this.context.User.SingleOrDefault(x => x.UserId == data.UserId);

            return new ClientLogViewModel
            {
                ClientId = data.ClientId,
                ClientLogId = data.ClientLogId,
                CreatedDate = data.CreatedDate,
                DeletedDate = data.DeletedDate,
                IsDeleted = data.IsDeleted,
                Message = data.Message,
                ModificatedDate = data.ModificatedDate,
                UserId = data.UserId,
                Title = data.Title,
                PlainText = data.PlainText,
                UserFullName = user == null? "" : user.FirstName + " " + user.LastName
            };
        }

        public List<ClientLog> GetDataByClientId(int clientId)
        {
            return this.context.ClientLog.Where(x => x.ClientId == clientId).ToList();
        }

        public ClientLogDetalhadoViewModel GetDataDetalhada(int clientId, bool noDeleted = false)
        {
            var client = this.context.Client.Single(x => x.ClientId == clientId);
            var clientLogs = GetDataByClientId(clientId);
            if (noDeleted)
            {
                clientLogs = clientLogs.Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedDate).ToList();
            }

            return new ClientLogDetalhadoViewModel
            {
                Client = new DTO.Client.ClientViewModel()
                {
                    ClientId = client.ClientId,
                    Cnpj = client.Cnpj,
                    Ie = client.Ie,
                    RazaoSocial = client.RazaoSocial,
                    NomeFantasia = client.NomeFantasia,
                    Email = client.Email,
                    Telefone = client.Telefone,
                    Cep = client.Cep,
                    Endereco = client.Endereco,
                    Numero = client.Numero,
                    Complemento = client.Complemento,
                    Bairro = client.Bairro,
                    Uf = client.Uf,
                    Cidade = client.Cidade,
                    IsActive = client.IsActive,
                    Observation = client.Observation,
                    Cpf = client.Cpf,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    ClientTypeId = client.ClientTypeId,
                    //Contact = client.Contact,
                },
                ClientLogs = GetDataViewModel(clientLogs)
            };
        }

        public override void Update(ClientLogViewModel model)
        {
            var clientLog = this.GetDataByID(model.ClientLogId);

            clientLog.Title = model.Title;
            clientLog.Message = model.Message;
            clientLog.PlainText = model.PlainText;
            clientLog.UserId = model.UserId;

            this.dbSet.Update(clientLog);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientLog;
        }
    }
}
