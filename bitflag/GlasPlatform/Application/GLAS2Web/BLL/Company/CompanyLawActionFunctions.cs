using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;
using DTO.Company;
using Utils;

namespace BLL.Company
{
    public class CompanyLawActionFunctions : BLLBasicFunctions<DAL.CompanyLawAction, DTO.Company.CompanyLawActionViewModel>
    {
        public CompanyLawActionFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyLawActionId")
        {
        }

        public override int Create(CompanyLawActionViewModel model)
        {
            var companyLawAction = new DAL.CompanyLawAction();

            companyLawAction.CompanyLawId = model.CompanyLawId;
            companyLawAction.Name = model.Name;
            companyLawAction.RegistrationDate = model.RegistrationDate.FromBrazilianDateFormat();
            companyLawAction.TargetDate = model.TargetDate.FromBrazilianDateFormat();
            companyLawAction.CompanyLawActionStatusId = model.CompanyLawActionStatusId;
            companyLawAction.CompanyLawActionTypeId = model.CompanyLawActionTypeId;
            companyLawAction.ResponsibleId = model.ResponsibleId;
            companyLawAction.SupervisorId = model.SupervisorId;
            companyLawAction.FinalProjectCost = Convert.ToDouble(model.FinalProjectCost);
            companyLawAction.RenewDate = model.RenewDate.FromBrazilianDateFormatNullable();
            companyLawAction.WarningDate = model.WarningDate.FromBrazilianDateFormatNullable();
            companyLawAction.Evidence = model.Evidence;
            companyLawAction.IsActive = true;
            companyLawAction.IsDeleted = false;

            this.dbSet.Add(companyLawAction);
            this.context.SaveChanges();

            return companyLawAction.CompanyLawActionId;
        }

        public override void Delete(object id)
        {
            var law = this.GetDataByID(id);

            law.IsDeleted = true;
            law.LastHandler = -1;
            law.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public override List<CompanyLawActionViewModel> GetDataViewModel(IQueryable<DAL.CompanyLawAction> data)
        {
            var r = (from y in data
                     from supervisor in this.context.User.Where( x=> x.Id.Equals(y.ResponsibleId)).DefaultIfEmpty()
                     from responsible in this.context.User.Where(x => x.Id.Equals(y.SupervisorId)).DefaultIfEmpty()
                     from clas in this.context.CompanyLawActionStatus.Where(x => x.CompanyLawActionStatusId.Equals(y.CompanyLawActionStatusId)).DefaultIfEmpty()
                     from clat in this.context.CompanyLawActionType.Where(x => x.CompanyLawActionTypeId.Equals(y.CompanyLawActionTypeId)).DefaultIfEmpty()
                     select new CompanyLawActionViewModel()
                     {
                         CompanyLawActionId = y.CompanyLawActionId,
                         CompanyLawId = y.CompanyLawId,
                         Name = y.Name,
                         RegistrationDate = y.RegistrationDate.ToBrazilianDateFormat(),
                         TargetDate = y.TargetDate.ToBrazilianDateFormat(),
                         CompanyLawActionStatusName = (clas == null ? null : clas.Name),
                         CompanyLawActionStatusId = y.CompanyLawActionStatusId,
                         CompanyLawActionTypeName = (clat == null ? null : clat.Name),
                         CompanyLawActionTypeId = y.CompanyLawActionTypeId,
                         ResponsibleName = (responsible == null ? null : responsible.FirstName + " " + responsible.LastName),
                         ResponsibleId = y.ResponsibleId,
                         SupervisorName = (supervisor == null ? null : supervisor.FirstName + " " + supervisor.LastName),
                         SupervisorId = y.SupervisorId,
                         FinalProjectCost = (y.FinalProjectCost.HasValue ? y.FinalProjectCost.Value.ToString("0.00") : string.Empty),
                         RenewDate = y.RenewDate.ToBrazilianDateFormat(),
                         WarningDate = y.WarningDate.ToBrazilianDateFormat(),
                         Evidence = y.Evidence,
                         IsActive = y.IsActive
                     }).ToList();

            return r;
        }

        public override CompanyLawActionViewModel GetDataViewModel(DAL.CompanyLawAction data)
        {
            var supervisor = this.context.User.SingleOrDefault(x => x.Id == data.SupervisorId);
            var responsible = this.context.User.SingleOrDefault(x => x.Id == data.ResponsibleId);
            var clas = this.context.CompanyLawActionStatus.SingleOrDefault(x => x.CompanyLawActionStatusId == data.CompanyLawActionStatusId);
            var clat = this.context.CompanyLawActionType.SingleOrDefault(x => x.CompanyLawActionTypeId == data.CompanyLawActionTypeId);

            return new CompanyLawActionViewModel()
            {
                CompanyLawActionId = data.CompanyLawActionId,
                CompanyLawId = data.CompanyLawId,
                Name = data.Name,
                RegistrationDate = data.RegistrationDate.ToBrazilianDateFormat(),
                TargetDate = data.TargetDate.ToBrazilianDateFormat(),
                CompanyLawActionStatusName = (clas == null ? null : clas.Name),
                CompanyLawActionStatusId = data.CompanyLawActionStatusId,
                CompanyLawActionTypeName = (clat == null ? null : clat.Name),
                CompanyLawActionTypeId = data.CompanyLawActionTypeId,
                SupervisorName = supervisor == null ? null : supervisor.FirstName + " " + supervisor.LastName,
                SupervisorId = data.SupervisorId,
                ResponsibleName = responsible == null ? null : responsible.FirstName + " " + responsible.LastName,
                ResponsibleId = data.ResponsibleId,
                FinalProjectCost = (data.FinalProjectCost.HasValue ? data.FinalProjectCost.Value.ToString("0.00") : null),
                RenewDate = data.RenewDate.ToBrazilianDateFormat(),
                WarningDate = data.WarningDate.ToBrazilianDateFormat(),
                Evidence = data.Evidence,
                IsActive = data.IsActive
            };
        }

        public override void Update(CompanyLawActionViewModel model)
        {
            var companyLawAction = this.GetDataByID(model.CompanyLawActionId);

            companyLawAction.CompanyLawId = model.CompanyLawId;
            companyLawAction.Name = model.Name;
            companyLawAction.RegistrationDate = model.RegistrationDate.FromBrazilianDateFormatNullable();
            companyLawAction.TargetDate = model.TargetDate.FromBrazilianDateFormatNullable();
            companyLawAction.CompanyLawActionStatusId = model.CompanyLawActionStatusId;
            companyLawAction.CompanyLawActionTypeId = model.CompanyLawActionTypeId;
            companyLawAction.SupervisorId = model.SupervisorId;
            companyLawAction.ResponsibleId = model.ResponsibleId;
            companyLawAction.FinalProjectCost = Convert.ToDouble(model.FinalProjectCost);
            companyLawAction.RenewDate = model.RenewDate.FromBrazilianDateFormatNullable();
            companyLawAction.WarningDate = model.WarningDate.FromBrazilianDateFormatNullable();
            companyLawAction.Evidence = model.Evidence;
            companyLawAction.IsActive = model.IsActive;

            this.context.SaveChanges();
        }

        public CompanyLawAction GetCompanyLawActionByCompanyLawId(int companyLawId)
        {
            return this.dbSet.SingleOrDefault(x => x.CompanyLawId.Equals(companyLawId));
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawAction;
        }
    }
}
