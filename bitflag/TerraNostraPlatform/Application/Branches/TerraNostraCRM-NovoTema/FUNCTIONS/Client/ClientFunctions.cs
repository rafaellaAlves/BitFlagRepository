using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using DTO.Client;
using DTO.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FUNCTIONS.Client
{
    public class ClientFunctions : BasicFunctions<DB.Client, DTO.Client.ClientViewModel>
    {
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;

        public ClientFunctions(TerraNostraContext context, UserManager<TerraNostraIdentityDbContext.User> userManager)
            : base(context, "ClientId")
        {
            this.userManager = userManager;
        }

        public override int Create(ClientViewModel model)
        {
            do
            {
                model.Token = Utils.ReferenceUtils.GetLongReference();
            } while (this.dbSet.Any(x => x.Token == model.Token));

            var Client = new DB.Client
            {
                Cnpj = model.Cnpj,
                Ie = model.Ie,
                RazaoSocial = model.RazaoSocial,
                NomeFantasia = model.NomeFantasia,
                Cpf = model.Cpf,
                Rg = model.rg,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Occupation = model.Occupation,
                ClientTypeId = model.ClientTypeId,
                Email = model.Email,
                Telefone = model.Telefone,
                Celular = model.Celular,
                Cep = model.Cep,
                Endereco = model.Endereco,
                Numero = model.Numero,
                Complemento = model.Complemento,
                Bairro = model.Bairro,
                Uf = model.Uf,
                Cidade = model.Cidade,
                IsActive = true,
                Observation = model.Observation,
                LastHandler = model.LastHandler,
                ResponsibleId = model.ResponsibleId,
                ResponsibleDate = model.ResponsibleDate,
                ContactMediumId = model.ContactMediumId,
                Token = model.Token,
                ClientStatusId = model.ClientStatusId,
                CreatorUserId = model.CreatorUserId,
                CivilStatusId = model.CivilStatusId,
                Family = model.Family,
                RDStation_uuid = model.RDStation_uuid
                //Contact = model.Contact
            };

            this.dbSet.Add(Client);
            this.context.SaveChanges();

            return Client.ClientId;
        }

        public override void Delete(object id)
        {
            var client = this.GetDataByID(id);

            client.IsDeleted = true;
            client.IsActive = false;
            client.DeletedDate = DateTime.Now;

            this.context.Update(client);
            this.context.SaveChanges();
        }

        public void Delete(object id, int userId)
        {
            var client = this.GetDataByID(id);

            client.IsDeleted = true;
            client.IsActive = false;
            client.DeletedDate = DateTime.Now;
            client.DeletedBy = userId;

            this.context.Update(client);
            this.context.SaveChanges();
        }

        public override List<ClientViewModel> GetDataViewModel(IEnumerable<DB.Client> data)
        {
            return (from y in data
                    select new DTO.Client.ClientViewModel()
                    {
                        ClientId = y.ClientId,
                        Cnpj = y.Cnpj,
                        Rg = y.Rg,
                        Ie = y.Ie,
                        RazaoSocial = y.RazaoSocial,
                        NomeFantasia = y.NomeFantasia,
                        Email = y.Email,
                        Telefone = y.Telefone,
                        Celular = y.Celular,
                        Cep = y.Cep,
                        Endereco = y.Endereco,
                        Numero = y.Numero,
                        Complemento = y.Complemento,
                        Bairro = y.Bairro,
                        Cidade = y.Cidade,
                        Uf = y.Uf,
                        IsActive = y.IsActive,
                        Observation = y.Observation,
                        Cpf = y.Cpf,
                        FirstName = y.FirstName,
                        LastName = y.LastName,
                        Occupation = y.Occupation,
                        ClientTypeId = y.ClientTypeId,
                        //Contact = y.Contact,
                        FirstContacted = y.FirstContacted,
                        FirstContactDate = y.FirstContactDate,
                        FirstContactBy = y.FirstContactBy,
                        ResponsibleId = y.ResponsibleId,
                        ResponsibleDate = y.ResponsibleDate,
                        ContactMediumId = y.ContactMediumId,
                        Token = y.Token,
                        ClientStatusId = y.ClientStatusId,
                        CreatedDate = y.CreatedDate,
                        CreatorUserId = y.CreatorUserId,
                        CivilStatusId = y.CivilStatusId,
                        Family = y.Family,
                        RDStation_uuid = y.RDStation_uuid
                    }).ToList();
        }

        public override ClientViewModel GetDataViewModel(DB.Client data)
        {
            DB.User responsible = null;
            if (data.ResponsibleId != null) responsible = context.User.SingleOrDefault(x => x.UserId == data.ResponsibleId);


            DB.CivilStatus civilStatus = null;
            if (data.CivilStatusId != null) civilStatus = context.CivilStatus.SingleOrDefault(x => x.CivilStatusId == data.CivilStatusId);

            return new DTO.Client.ClientViewModel()
            {
                ClientId = data.ClientId,
                Cnpj = data.Cnpj,
                Rg = data.Rg,
                Ie = data.Ie,
                RazaoSocial = data.RazaoSocial,
                NomeFantasia = data.NomeFantasia,
                Email = data.Email,
                Telefone = data.Telefone,
                Celular = data.Celular,
                Cep = data.Cep,
                Endereco = data.Endereco,
                Numero = data.Numero,
                Complemento = data.Complemento,
                Bairro = data.Bairro,
                Uf = data.Uf,
                Cidade = data.Cidade,
                IsActive = data.IsActive,
                Observation = data.Observation,
                Cpf = data.Cpf,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Occupation = data.Occupation,
                ClientTypeId = data.ClientTypeId,
                //Contact = data.Contact,
                FirstContacted = data.FirstContacted,
                FirstContactDate = data.FirstContactDate,
                FirstContactBy = data.FirstContactBy,
                ResponsibleId = data.ResponsibleId,
                ResponsibleDate = data.ResponsibleDate,
                ResponsibleName = responsible == null ? "" : responsible.FirstName + " " + responsible.LastName,
                ResponsiblePhone = responsible == null ? "" : responsible.PhoneNumber,
                ResponsibleMobilePhone = responsible == null ? "" : responsible.MobileNumber,
                ContactMediumId = data.ContactMediumId,
                Token = data.Token,
                ClientStatusId = data.ClientStatusId,
                CreatedDate = data.CreatedDate,
                CreatorUserId = data.CreatorUserId,
                CivilStatusId = data.CivilStatusId,
                CivilStatusName = civilStatus != null ? civilStatus.StatusDescription : "",
                Family = data.Family,
                RDStation_uuid = data.RDStation_uuid

            };
        }

        //public List<ClientListViewModel> GetClientListViewModel(IEnumerable<DB.Client> data)
        //{
        //    var users = this.context.User.ToList();
        //    var clientStatus = this.context.ClientStatus.ToList();

        //    return (from y in data

        //            join u in users on new { y.Email, y.IsDeleted } equals new { u.Email, u.IsDeleted } into _u
        //            from __u in _u.DefaultIfEmpty()

        //            join du in users on y.DeletedBy equals du.UserId into _du
        //            from __du in _du.DefaultIfEmpty()

        //            join fcb in users on y.FirstContactBy equals fcb.UserId into _fcb
        //            from __fcb in _fcb.DefaultIfEmpty()
        //            join ru in users on y.ResponsibleId equals ru.UserId into _ru
        //            from __ru in _ru.DefaultIfEmpty()
        //            join s in clientStatus on y.ClientStatusId equals s.ClientStatusId into _s
        //            from __s in _s.DefaultIfEmpty()

        //            join ft in this.context.FamilyTree on y.ClientId equals ft.ClientId into _ft
        //            from __ft in _ft.DefaultIfEmpty()

        //            select new DTO.Client.ClientListViewModel
        //            {
        //                ClientId = y.ClientId,
        //                Cnpj = y.Cnpj,
        //                Rg = y.Rg,
        //                Ie = y.Ie,
        //                RazaoSocial = y.RazaoSocial,
        //                NomeFantasia = y.NomeFantasia,
        //                Email = y.Email,
        //                Telefone = y.Telefone,
        //                Cep = y.Cep,
        //                Endereco = y.Endereco,
        //                Numero = y.Numero,
        //                Complemento = y.Complemento,
        //                Bairro = y.Bairro,
        //                Uf = y.Uf,
        //                Cidade = y.Cidade,
        //                IsActive = y.IsActive,
        //                Observation = y.Observation,
        //                Cpf = y.Cpf,
        //                Occupation = y.Occupation,
        //                ClientTypeId = y.ClientTypeId,
        //                UserId = __u != null ? (int?)__u.UserId : null,
        //                CreatedDate = y.CreatedDate,
        //                //Contact = y.Contact,
        //                DeletedBy = y.DeletedBy,
        //                DeletedDate = y.DeletedDate,
        //                IsDeleted = y.IsDeleted,
        //                DeletedName = __du != null ? __du.FirstName + " " + __du.LastName : "",
        //                FirstContacted = y.FirstContacted,
        //                FirstContactDate = y.FirstContactDate,
        //                FirstContactBy = y.FirstContactBy,
        //                FirstContactedName = __fcb != null ? __fcb.FirstName + " " + __fcb.LastName : "",
        //                Token = y.Token,
        //                ResponsibleId = y.ResponsibleId,
        //                Responsible = __ru != null ? __ru.FirstName + " " + __ru.LastName : "-",
        //                ClientStatusId = y.ClientStatusId,
        //                ClientStatusName = __s == null ? "" : __s.Name,
        //                FamilyTreeHasItem = __ft != null,
        //                CivilStatusId = y.CivilStatusId

        //            }).ToList();
        //}

        public override void Update(ClientViewModel model)
        {
            var Client = this.GetDataByID(model.ClientId);

            Client.Bairro = model.Bairro;
            Client.Cep = model.Cep;
            Client.Cnpj = model.Cnpj;
            Client.Rg = model.Rg;
            Client.Complemento = model.Complemento;
            Client.Email = model.Email;
            Client.Endereco = model.Endereco;
            Client.Numero = model.Numero;
            Client.RazaoSocial = model.RazaoSocial;
            Client.Telefone = model.Telefone;
            Client.Celular = model.Celular;
            Client.Uf = model.Uf;
            Client.Cidade = model.Cidade;
            Client.Observation = model.Observation;
            Client.IsActive = model.IsActive.Value;
            Client.LastHandler = model.LastHandler;
            Client.Ie = model.Ie;
            Client.NomeFantasia = model.NomeFantasia;
            Client.Cpf = model.Cpf;
            Client.FirstName = model.FirstName;
            Client.LastName = model.LastName;
            Client.Occupation = model.Occupation;
            Client.ClientTypeId = model.ClientTypeId;
            Client.ResponsibleId = model.ResponsibleId;
            Client.ResponsibleDate = model.ResponsibleDate;
            Client.ContactMediumId = model.ContactMediumId;
            Client.ClientStatusId = model.ClientStatusId;
            Client.CivilStatusId = model.CivilStatusId;
            Client.Family = model.Family;
            Client.RDStation_uuid = model.RDStation_uuid;
            //Client.Contact = model.Contact;

            this.context.Update(Client);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Client;
        }

        public bool ExistCNPJ(string cnpj, int? clientId)
        {
            return this.dbSet.Any(x => x.Cnpj == cnpj && x.IsDeleted == false && x.ClientId != clientId);
        }

        public bool ExistCPF(string cpf, int? clientId)
        {
            return this.dbSet.Any(x => x.Cpf == cpf && x.IsDeleted == false && x.ClientId != clientId);
        }

        public bool ExistPhone(string telefone, int? clientId)
        {
            return this.dbSet.Any(x => x.Telefone.NumbersOnly() == telefone.NumbersOnly() && x.IsDeleted == false && x.ClientId != clientId);
        }

        public bool ExistMobile(string mobile, int? clientId)
        {
            return this.dbSet.Any(x => x.Celular.NumbersOnly() == mobile.NumbersOnly() && x.IsDeleted == false && x.ClientId != clientId);
        }

        public bool ExistEmail(string email, int? clientId = null)
        {
            return this.dbSet.Any(x => x.Email == email && x.IsDeleted == false && x.ClientId != clientId);
        }

        public void SendFirstContact(int clientId, int userId)
        {
            var client = GetDataByID(clientId);

            client.FirstContacted = true;
            client.FirstContactDate = DateTime.Now;
            client.FirstContactBy = userId;

            this.dbSet.Update(client);
            this.context.SaveChanges();
        }
        public void SetResponsible(int clientId, int userId)
        {
            var client = GetDataByID(clientId);

            client.ResponsibleId = userId;
            client.ResponsibleDate = DateTime.Now;

            this.dbSet.Update(client);
            this.context.SaveChanges();
        }

        public string GetDocumentByClientId(int clientId)
        {
            var client = GetDataViewModel(GetDataByID(clientId));
            return client.ClientDocument;
        }

        public DB.Client GetByToken(string token)
        {
            return this.dbSet.SingleOrDefault(x => x.Token == token);
        }

        public void SetResponsible(int clientId, int? responsibleId)
        {
            var client = GetDataByID(clientId);
            client.ResponsibleId = responsibleId;
            client.ResponsibleDate = DateTime.Now;

            this.dbSet.Update(client);
            this.context.SaveChanges();
        }

        public void SetStatus(int clientId, int? statusId)
        {
            var client = GetDataByID(clientId);
            client.ClientStatusId = statusId;

            this.dbSet.Update(client);
            this.context.SaveChanges();
        }

        public DB.Client GetByUserId(int userId)
        {
            var user = context.User.SingleOrDefault(x => x.UserId == userId);
            if (user == null) return null;

            return this.dbSet.FirstOrDefault(x => !x.IsDeleted && x.Email == user.Email);
        }

        public async Task<IEnumerable<DB.Client>> GetByLoggedUserId(System.Security.Claims.ClaimsPrincipal userClaim)
        {
            var user = await userManager.GetUserAsync(userClaim);
            if (await userManager.IsInRoleAsync(user, "Salesman"))
            {
                return this.dbSet.Where(x => !x.IsDeleted && x.ResponsibleId == user.Id);
            }

            return this.dbSet.Where(x => !x.IsDeleted);
        }

        public void TryUpdateStatus(int clientId, int clientStatusId)
        {
            var client = GetDataByID(clientId);

            var clientStatus = context.ClientStatus.SingleOrDefault(x => x.ClientStatusId == client.ClientStatusId);

            if (clientStatus != null)
            {
                switch (clientStatusId)
                {
                    case 2:
                        if (clientStatus.ExternalCode == "GENEALOGIAAPROVADA" || clientStatus.ExternalCode == "GENEALOGIAREPROVADA") return;
                        break;
                    case 3:
                        if (clientStatus.ExternalCode != "GENEALOGIAPREENCHIDA") return;
                        break;
                    case 4:
                        if (clientStatus.ExternalCode != "GENEALOGIAPREENCHIDA") return;
                        break;
                }
            }

            client.ClientStatusId = clientStatusId;
            context.SaveChanges();
        }

        public FUNCTIONS.Shared.ReturnResult ValidateClientViewModel(DTO.Client.ClientViewModel model)
        {
            var oldClient = model.ClientId.HasValue ? GetDataByID(model.ClientId) : null;

            if (!string.IsNullOrWhiteSpace(model.Cnpj) && ExistCNPJ(model.Cnpj, model.ClientId))
                return new FUNCTIONS.Shared.ReturnResult(0, "CNPJ já utilizado", true, "Cnpj");

            if (!string.IsNullOrWhiteSpace(model.Cpf) && ExistCPF(model.Cpf, model.ClientId))
                return new FUNCTIONS.Shared.ReturnResult(0, "CPF já utilizado", true, "CPF");

            if (!string.IsNullOrWhiteSpace(model.Telefone) && (ExistPhone(model.Telefone, model.ClientId)))
                return new FUNCTIONS.Shared.ReturnResult(0, "Telefone já utilizado", true, "Telefone");

            if (!string.IsNullOrWhiteSpace(model.Celular) && ExistMobile(model.Celular, model.ClientId))
                return new FUNCTIONS.Shared.ReturnResult(0, "Celular já utilizado", true, "Celular");

            if (oldClient == null && this.context.User.Any(x => x.Email == model.Email))
                return new FUNCTIONS.Shared.ReturnResult(0, "E-mail já utilizado.", true, "Email");

            if (oldClient != null && oldClient.Email != model.Email && this.context.User.Any(x => x.Email == model.Email))
                return new FUNCTIONS.Shared.ReturnResult(0, "E-mail já utilizado.", true, "Email");

            return new Shared.ReturnResult(0, null, false);
        }

        public async Task<bool> ExistRDStationLead(string uuId) => await this.dbSet.AnyAsync(x => x.RDStation_uuid == uuId);

        public async Task<Shared.ReturnResult> CreateFromRDStationLead(DTO.RDStation.LeadViewModel lead)
        {
            if (await ExistRDStationLead(lead.uuid)) return new Shared.ReturnResult(0, "Contato já importado", true);

            lead.name.GetName(out string firstName, out string lastName);

            var model = new ClientViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = lead.email,
                RazaoSocial = lead.company,
                NomeFantasia = lead.company,
                ClientTypeId = string.IsNullOrWhiteSpace(lead.company) ? (await this.context.ClientType.SingleAsync(x => x.ExternalCode == "PERSON")).ClientTypeId : (await this.context.ClientType.SingleAsync(x => x.ExternalCode == "COMPANY")).ClientTypeId,
                Cidade = lead.city,
                Uf = lead.state?.Length == 2 ? lead.state : StatesUtils.GetEstados().Any(x => x.Description == lead.state) ? StatesUtils.GetEstados().First(x => x.Description == lead.state).StateId : null,
                RDStation_uuid = lead.uuid,
                ClientStatusId = null,
                Observation = "Oportunidade RD Station.",
                ContactMediumId = (await this.context.ContactMedium.SingleAsync(x => x.ExternalCode == "RDSTATION")).ContactMediumId,
                Telefone = lead.personal_phone,
                Celular = lead.mobile_phone
            };

            var validation = ValidateClientViewModel(model);

            if (validation.HasError) return validation;

            var id = Create(model);

            return new Shared.ReturnResult(id, null, false);
        }
    }
}
