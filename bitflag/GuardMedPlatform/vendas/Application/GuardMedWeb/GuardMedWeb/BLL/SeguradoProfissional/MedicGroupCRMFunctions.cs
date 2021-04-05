using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using GuardMedWeb.DAL;
using GuardMedWeb.Models;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class MedicGroupCRMFunctions : BLLBasicFunctions<DAL.MedicGroupCRM, Models.MedicGroupCRMViewModel>
    {
        public MedicGroupCRMFunctions(GuardMedWebContext context)
            : base(context, "MedicGroupCRMId")
        {
        }

        public override int Create(MedicGroupCRMViewModel model)
        {
            var medicGroupCRM = new DAL.MedicGroupCRM
            {
                CRM = model.CRM,
                MedicGroupId = model.MedicGroupId.Value,
                CRMEstado = model.CRMEstado,
                Nome = model.Nome,
                CPF = model.CPF
                
            };

            this.dbSet.Add(medicGroupCRM);
            context.SaveChanges();

            return medicGroupCRM.MedicGroupCRMId;
        }

        public override void Delete(object id)
        {
            var medicGroupCRM = GetDataByID(id);

            this.dbSet.Remove(medicGroupCRM);

            context.SaveChanges();
        }

        public override List<MedicGroupCRMViewModel> GetDataViewModel(IQueryable<MedicGroupCRM> data)
        {
            return (from y in data
                    select new Models.MedicGroupCRMViewModel
                    {
                        CRM = y.CRM,
                        MedicGroupCRMId = y.MedicGroupCRMId,
                        MedicGroupId = y.MedicGroupId,
                        CRMEstado = y.CRMEstado,
                        Nome = y.Nome,
                        CPF = y.CPF
                    }).ToList();
        }

        public override MedicGroupCRMViewModel GetDataViewModel(MedicGroupCRM data)
        {
            return new Models.MedicGroupCRMViewModel
            {
                CRM = data.CRM,
                MedicGroupCRMId = data.MedicGroupCRMId,
                MedicGroupId = data.MedicGroupId,
                CRMEstado = data.CRMEstado,
                CPF = data.CPF,
                Nome = data.Nome
            };
        }

        public override void Update(MedicGroupCRMViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool ExiteCRM(string crm, string crmEstado, int medicGroupId)
        {
            return this.dbSet.Any(x => x.CRM == crm && x.CRMEstado == crmEstado && x.MedicGroupId == medicGroupId);
        }

        public void DeleteByMedicGroupId(int medicGroupId)
        {
            var crms = GetData().Where(x => x.MedicGroupId == medicGroupId);

            foreach (var crm in crms)
                this.dbSet.Remove(crm);

            context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.MedicGroupCRM;
        }
    }
}
