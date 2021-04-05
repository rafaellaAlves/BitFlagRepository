using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using DTO.Indication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FUNCTIONS.Indication
{
    public class IndicationFunctions : BasicFunctions<DB.Indication, DTO.Indication.IndicationViewModel>
    {
        private readonly FUNCTIONS.User.UserFunctions userFunctions;
        private readonly FUNCTIONS.ServiceType.ServiceTypeFunctions serviceTypeFunctions;

        public IndicationFunctions(TerraNostraContext context, FUNCTIONS.User.UserFunctions userFunctions, FUNCTIONS.ServiceType.ServiceTypeFunctions serviceTypeFunctions) 
            : base(context, "IndicationId")
        {
            this.userFunctions = userFunctions;
            this.serviceTypeFunctions = serviceTypeFunctions;
        }

        public override int Create(IndicationViewModel model)
        {
            var indication = new DB.Indication
            {
                Email = model.Email,
                Name = model.Name,
                Phone = model.Phone,
                ServiceTypeId = model.ServiceTypeId.Value,
                UserId = model.UserId.Value,
            };

            this.dbSet.Add(indication);
            this.context.SaveChanges();

            return indication.IndicationId;
        }

        public override void Delete(object id)
        {
            var indication = GetDataByID(id);

            indication.IsDeleted = true;
            indication.DeleteDate = DateTime.Now;

            this.dbSet.Update(indication);
            this.context.SaveChanges();
        }

        public void Delete(object id, int userId)
        {
            var indication = GetDataByID(id);

            indication.IsDeleted = true;
            indication.DeleteDate = DateTime.Now;
            indication.DeletedBy = userId;

            this.dbSet.Update(indication);
            this.context.SaveChanges();
        }

        public override List<IndicationViewModel> GetDataViewModel(IEnumerable<DB.Indication> data)
        {
            return (from y in data
                    select new IndicationViewModel {
                        DeletedBy = y.DeletedBy,
                        DeleteDate = y.DeleteDate,
                        Email = y.Email,
                        IndicationId = y.IndicationId,
                        IsDeleted = y.IsDeleted,
                        Name = y.Name,
                        Phone = y.Phone,
                        ServiceTypeId = y.ServiceTypeId,
                        UserId = y.UserId,
                        CreatedDate = y.CreatedDate,
                        Accepted = y.Accepted,
                        AcceptedBy = y.AcceptedBy,
                        ClientId = y.ClientId,
                        AcceptedDate = y.AcceptedDate
                    }).ToList();
        }

        public override IndicationViewModel GetDataViewModel(DB.Indication data)
        {
            return new IndicationViewModel
            {
                DeletedBy = data.DeletedBy,
                DeleteDate = data.DeleteDate,
                Email = data.Email,
                IndicationId = data.IndicationId,
                IsDeleted = data.IsDeleted,
                Name = data.Name,
                Phone = data.Phone,
                ServiceTypeId = data.ServiceTypeId,
                UserId = data.UserId,
                CreatedDate = data.CreatedDate,
                Accepted = data.Accepted,
                AcceptedBy = data.AcceptedBy,
                ClientId = data.ClientId,
                AcceptedDate = data.AcceptedDate
            };
        }

        public List<IndicationListViewModel> GetDataListViewModel(IEnumerable<DB.Indication> data)
        {
            var user = this.context.User.ToList();
            var serviceType = this.context.ServiceType.ToList();

            return (from y in data
                    join u in user on y.UserId equals u.UserId
                    join s in serviceType on y.ServiceTypeId equals s.ServiceTypeId
                    join au in user on y.AcceptedBy equals au.UserId into _au
                    from __au in _au.DefaultIfEmpty()
                    join du in user on y.DeletedBy equals du.UserId into _du
                    from __du in _du.DefaultIfEmpty()
                    where (__au == null || !__au.IsDeleted) && (__du == null || !__du.IsDeleted)
                    select new IndicationListViewModel
                    {
                        DeletedBy = y.DeletedBy,
                        DeleteDate = y.DeleteDate,
                        Email = y.Email,
                        IndicationId = y.IndicationId,
                        IsDeleted = y.IsDeleted,
                        Name = y.Name,
                        Phone = y.Phone,
                        ServiceTypeId = y.ServiceTypeId,
                        ServiceTypeName = s.Name,
                        UserId = y.UserId,
                        UserName = u.FirstName + " " + u.LastName,
                        Accepted = y.Accepted,
                        CreatedDate = y.CreatedDate,
                        AcceptedBy = y.AcceptedBy,
                        AcceptedDate = y.AcceptedDate,
                        AcceptedName = __au != null? __au.FirstName + " " + __au.LastName : "",
                        DeletedName = __du != null? __du.FirstName + " " + __du.LastName : "",
                    }).ToList();
        }

        public override void Update(IndicationViewModel model)
        {
            var indication = GetDataByID(model.IndicationId);

            indication.Email = model.Email;
            indication.Name = model.Name;
            indication.Phone = model.Phone;
            indication.ServiceTypeId = model.ServiceTypeId.Value;

            this.dbSet.Update(indication);
            this.context.SaveChanges();
        }

        public void Accept(int indicationId, int? clientId, int acceptedBy)
        {
            var indication = GetDataByID(indicationId);

            indication.Accepted = true;
            indication.ClientId = clientId;
            indication.AcceptedBy = acceptedBy;
            indication.AcceptedDate = DateTime.Now;

            this.dbSet.Update(indication);
            this.context.SaveChanges();
        }

        public bool ValidateManage(string email, int? indicationId, int serviceTypeId)
        {
            var indications = this.dbSet.Where(x => x.Email == email && !x.IsDeleted);

            if (!indicationId.HasValue && indications.Count() >= 2) return false;
            if (indications.Any(x => x.ServiceTypeId == serviceTypeId && x.IndicationId != indicationId)) return false;

            return true;
        }

        public async Task<bool> CheckIfExists(string email, int serviceTypeId)
        {
            return await context.Indication.AnyAsync(x => x.Email.ToUpper().Equals(email.ToUpper()) && x.ServiceTypeId == serviceTypeId);
        }

        public async Task<bool> Add(NewIndicationViewModel model)
        {
            try
            {
                context.Indication.Add(new DB.Indication()
                {
                    Name = model.FullName,
                    Email = model.Email,
                    Phone = model.Phone,
                    ServiceTypeId = model.ServiceTypeId,
                    UserId = model.UserId,
                    CreatedDate = DateTime.Now
                });
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> IndicadoEmailMessage(NewIndicationViewModel model)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Olá <b>{model.FullName}</b>,");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Recebemos seu contato através de um de nossos parceiros.");
            stringBuilder.AppendLine("<br />");
            stringBuilder.AppendLine($"Nas próximas horas um representante Terra Nostra terá o prazer de entrar contato com você para analisar o seu caso.");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Atenciosamente,");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Equipe Terra Nostra Assessoria");

            return stringBuilder.ToString();
        }

        public async Task<string> TerraNostraEmailMessage(NewIndicationViewModel model)
        {
            var stringBuilder = new StringBuilder();

            var user = userFunctions.GetDataByID(model.UserId);

            stringBuilder.AppendLine($"Nova indicação de <b>{user.FirstName + (string.IsNullOrWhiteSpace(user.LastName) ? "" : user.LastName)}</b>!");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Dados da indicação:");
            stringBuilder.AppendLine("<br />");
            stringBuilder.AppendLine("<ul>");
            stringBuilder.AppendLine($"<li>Nome completo: <b>{model.FullName}</b></li>");
            stringBuilder.AppendLine($"<li>E-mail: <b>{model.Email}</b></li>");
            stringBuilder.AppendLine($"<li>Telefone: <b>{model.Phone}</b></li>");
            stringBuilder.AppendLine($"<li>Serviço: <b>{serviceTypeFunctions.GetServiceName(model.ServiceTypeId)}</b></li>");
            stringBuilder.AppendLine("</ul>");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Atenciosamente,");
            stringBuilder.AppendLine("<br /><br />");
            stringBuilder.AppendLine("Sistemas de Indicações Terra Nostra Assessoria");

            return stringBuilder.ToString();
        }
        protected override void SetDbSet()
        {
            this.dbSet = context.Indication;
        }
    }
}
