using DB;
using DTO.Client;
using DTO.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FUNCTIONS.Client
{
    public class ClientDependentFunctions : BasicFunctions<ClientDependent, ClientDependentViewModel>
    {
        public ClientDependentFunctions(TerraNostraContext context) 
            : base(context, "ClientDependentId")
        {
        }

        public override int Create(ClientDependentViewModel model)
        {
            var clientDependent = model.CopyToEntity<ClientDependent>();

            this.dbSet.Add(clientDependent);
            this.context.SaveChanges();

            return clientDependent.ClientDependentId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id, int userId)
        {
            var clientDependent = GetDataByID(id);

            clientDependent.IsDeleted = true;
            clientDependent.DeletedDate = DateTime.Now;
            clientDependent.DeletedBy = userId;

            this.dbSet.Update(clientDependent);
            this.context.SaveChanges();
        }

        public override List<ClientDependentViewModel> GetDataViewModel(IEnumerable<ClientDependent> data)
        {
            return data.Select(x => x.CopyToEntity<ClientDependentViewModel>()).ToList();
        }

        public override ClientDependentViewModel GetDataViewModel(ClientDependent data)
        {
            return data.CopyToEntity<ClientDependentViewModel>();
        }

        public override void Update(ClientDependentViewModel model)
        {
            var clientDependent = GetDataByID(model.ClientDependentId);

            clientDependent.Bairro = model.Bairro;
            clientDependent.Celular = model.Celular;
            clientDependent.Cep = model.Cep;
            clientDependent.Cidade = model.Cidade;
            clientDependent.ClientDependentTypeId = model.ClientDependentTypeId;
            clientDependent.Complemento = model.Complemento;
            clientDependent.Cpf = model.Cpf;
            clientDependent.Email = model.Email;
            clientDependent.Endereco = model.Endereco;
            clientDependent.Family = model.Family;
            clientDependent.FirstName = model.FirstName;
            clientDependent.LastName = model.LastName;
            clientDependent.LastHandler = model.LastHandler;
            clientDependent.Numero = model.Numero;
            clientDependent.Observation = model.Observation;
            clientDependent.Rg = model.Rg;
            clientDependent.Telefone = model.Telefone;
            clientDependent.Uf = model.Uf;
            clientDependent.Occupation = model.Occupation;

            this.dbSet.Update(clientDependent);
            this.context.SaveChanges();
        }

        public List<ClientDependent> GetDataByClient(int clientId)
        {
            return this.dbSet.Where(x => x.ClientId == clientId && !x.IsDeleted).ToList();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientDependent;
        }

        public bool ExistCPF(string cpf, int? clientDependentId)
        {
            return this.dbSet.Any(x => x.Cpf == cpf && x.IsDeleted == false && x.ClientDependentId != clientDependentId);
        }

        public bool ExistEmail(string email, int? clientDependentId = null)
        {
            return this.dbSet.Any(x => x.Email == email && x.IsDeleted == false && x.ClientDependentId != clientDependentId);
        }
    }
}
