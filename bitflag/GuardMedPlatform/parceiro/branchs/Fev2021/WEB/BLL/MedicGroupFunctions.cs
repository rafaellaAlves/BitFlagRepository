using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;
using WEB.Models;
using WEB.Utils;

namespace WEB.BLL
{
    public class MedicGroupFunctions : BLLBasicVendasFunctions<MedicGroup, MedicGroupViewModel>
    {
        private readonly MedicGroupCRMFunctions medicGroupCRMFunctions;

        public MedicGroupFunctions(VendasContext context, MedicGroupCRMFunctions medicGroupCRMFunctions) : base(context, "MedicGroupId")
        {
            this.medicGroupCRMFunctions = medicGroupCRMFunctions;
        }

        public override int Create(MedicGroupViewModel model)
        {
            var medicGroup = model.CopyToEntity<MedicGroup>();

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

        public override List<MedicGroupViewModel> GetDataViewModel(IEnumerable<MedicGroup> data) => data.Select(x => x.CopyToEntity<MedicGroupViewModel>()).ToList();

        public override MedicGroupViewModel GetDataViewModel(MedicGroup data) => data.CopyToEntity<MedicGroupViewModel>();

        public override void Update(MedicGroupViewModel model)
        {
            var medicGroup = GetDataByID(model.MedicGroupId);

            medicGroup.MedicGroupName = model.MedicGroupName;
            medicGroup.IsActive = model.IsActive.Value;
            medicGroup.ExternalCode = model.ExternalCode;
            medicGroup.Cnpj = model.CNPJ;
            medicGroup.Discount = model.Discount ?? 0;

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
