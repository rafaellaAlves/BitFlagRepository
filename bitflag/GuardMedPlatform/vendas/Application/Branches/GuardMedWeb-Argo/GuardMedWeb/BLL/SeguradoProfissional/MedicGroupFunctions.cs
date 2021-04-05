using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using GuardMedWeb.Models;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class MedicGroupFunctions : BLLBasicFunctions<DAL.MedicGroup, Models.MedicGroupViewModel>
    {
        private readonly BLL.SeguradoProfissional.MedicGroupCRMFunctions medicGroupCRMFunctions;

        public MedicGroupFunctions(GuardMedWebContext context)
            : base(context, "MedicGroupId")
        {
            medicGroupCRMFunctions = new MedicGroupCRMFunctions(context);
        }

        public override int Create(MedicGroupViewModel model)
        {
            var medicGroup = new MedicGroup
            {
                MedicGroupName = model.MedicGroupName,
                Cnpj = model.CNPJ,
                Discount = double.Parse(model.Discount),
                ExternalCode = model.ExternalCode,
                IsActive = model.IsActive.Value
            };

            this.dbSet.Add(medicGroup);
            context.SaveChanges();

            return medicGroup.MedicGroupId;
        }

        public override void Delete(object id)
        {
            var medicGroup = GetDataByID(id);

            this.dbSet.Remove(medicGroup);
            context.SaveChanges();
        }

        public override List<MedicGroupViewModel> GetDataViewModel(IQueryable<MedicGroup> data)
        {
            return (from y in data
                    select new MedicGroupViewModel
                    {
                        MedicGroupName = y.MedicGroupName,
                        DiscountNumber = y.Discount,
                        Discount = y.Discount.ToString("0.00"),
                        ExternalCode = y.ExternalCode,
                        IsActive = y.IsActive,
                        MedicGroupId = y.MedicGroupId,
                        CNPJ = y.Cnpj,
                        RevenuesFormId = y.RevenuesFormId,
                        CompanyPlatformId = y.CompanyPlatformId,
                        PlatformAgency = y.PlatformAgency,
                        PlatformLife = y.PlatformLife,
                        PlatformComission = y.PlatformComission,
                        CompanyOfficeId = y.CompanyOfficeId,
                        OfficeAgency = y.OfficeAgency,
                        OfficeLife = y.OfficeLife,
                        OfficeComission = y.OfficeComission
                    }).ToList();
        }

        public override MedicGroupViewModel GetDataViewModel(MedicGroup data)
        {
            return new MedicGroupViewModel
            {
                Discount = data.Discount.ToString("0.00"),
                DiscountNumber = data.Discount,
                MedicGroupName = data.MedicGroupName,
                ExternalCode = data.ExternalCode,
                IsActive = data.IsActive,
                MedicGroupId = data.MedicGroupId,
                CNPJ = data.Cnpj,
                RevenuesFormId = data.RevenuesFormId,
                CompanyPlatformId = data.CompanyPlatformId,
                PlatformAgency = data.PlatformAgency,
                PlatformLife = data.PlatformLife,
                PlatformComission = data.PlatformComission,
                CompanyOfficeId = data.CompanyOfficeId,
                OfficeAgency = data.OfficeAgency,
                OfficeLife = data.OfficeLife,
                OfficeComission = data.OfficeComission
            };
        }

        public override void Update(MedicGroupViewModel model)
        {
            var medicGroup = GetDataByID(model.MedicGroupId);

            medicGroup.MedicGroupName = model.MedicGroupName;
            medicGroup.IsActive = model.IsActive.Value;
            medicGroup.ExternalCode = model.ExternalCode;
            medicGroup.Cnpj = model.CNPJ;
            medicGroup.Discount = double.Parse(model.Discount);
            medicGroup.RevenuesFormId = model.RevenuesFormId;
            medicGroup.CompanyPlatformId = model.CompanyPlatformId;
            medicGroup.PlatformLife = model.PlatformLife;
            medicGroup.PlatformAgency = model.PlatformAgency;
            medicGroup.PlatformComission = model.PlatformComission;
            medicGroup.CompanyOfficeId = model.CompanyOfficeId;
            medicGroup.OfficeAgency = model.OfficeAgency;
            medicGroup.OfficeLife = model.OfficeLife;
            medicGroup.OfficeComission = model.OfficeComission;

            this.dbSet.Update(medicGroup);
            context.SaveChanges();
        }

        public bool ExiteCodigo(string externalCode, int? medicGroupId)
        {
            if (medicGroupId.HasValue)
                return this.dbSet.Any(x => x.ExternalCode == externalCode && x.MedicGroupId != medicGroupId);

            else
                return this.dbSet.Any(x => x.ExternalCode == externalCode);
        }

        public bool ExiteCNPJ(string cnpj, int? medicGroupId)
        {
            if (medicGroupId.HasValue)
                return this.dbSet.Any(x => x.Cnpj == cnpj && x.MedicGroupId != medicGroupId);

            else
                return this.dbSet.Any(x => x.Cnpj == cnpj);
        }

        public bool ExiteName(string medicGroupName, int? medicGroupId)
        {
            if (medicGroupId.HasValue)
                return this.dbSet.Any(x => x.MedicGroupName.ToUpper() == medicGroupName.ToUpper() && x.MedicGroupId != medicGroupId);

            else
                return this.dbSet.Any(x => x.MedicGroupName.ToUpper() == medicGroupName.ToUpper());
        }

        public List<MedicGroup> GetMedicGroupsByCRM(string crm, string crmEstado)
        {
            var medicGroupIds = medicGroupCRMFunctions.GetData().Where(x => x.Crm == crm && x.Crmestado == crmEstado).Select(x => x.MedicGroupId);
            var retorno = medicGroupIds.Count() == 0 ? null : this.dbSet.Where(x => medicGroupIds.Contains(x.MedicGroupId)).OrderByDescending(x => x.Discount).ToList();
            return retorno;
        }

        public MedicGroup GetDataByName(string medicGroupName)
        {
            return GetData().SingleOrDefault(x => x.MedicGroupName.ToUpper() == medicGroupName.ToUpper());
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.MedicGroup;
        }

        public MedicGroup GetMedicGroupByInsurance(int seguradoProfissionalId)
        {
            var insurance = this.context.SeguradoProfissional.Single(x => x.SeguradoProfissionalId == seguradoProfissionalId);

            var medicGroups = GetMedicGroupsByCRM(insurance.Crm, insurance.EstadoCrm);
            return (medicGroups != null && medicGroups.Count > 0) ? medicGroups.OrderByDescending(x => x.Discount).First() : null;
        }
    }
}
