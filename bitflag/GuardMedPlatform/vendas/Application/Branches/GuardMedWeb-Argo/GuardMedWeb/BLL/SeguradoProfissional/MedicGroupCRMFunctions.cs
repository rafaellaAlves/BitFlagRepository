using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using GuardMedWeb.Models;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class MedicGroupCRMFunctions : BLLBasicFunctions<DAL.MedicGroupCrm, Models.MedicGroupCRMViewModel>
    {
        public MedicGroupCRMFunctions(GuardMedWebContext context)
            : base(context, "MedicGroupCrmid")
        {
        }

        public override int Create(MedicGroupCRMViewModel model)
        {
            var medicGroupCRM = new DAL.MedicGroupCrm
            {
                Crm = model.CRM,
                MedicGroupId = model.MedicGroupId.Value,
                Crmestado = model.CRMEstado,
                Nome = model.Nome,
                Cpf = model.CPF
                
            };

            this.dbSet.Add(medicGroupCRM);
            context.SaveChanges();

            return medicGroupCRM.MedicGroupCrmid;
        }

        public override void Delete(object id)
        {
            var medicGroupCRM = GetDataByID(id);

            this.dbSet.Remove(medicGroupCRM);

            context.SaveChanges();
        }

        public override List<MedicGroupCRMViewModel> GetDataViewModel(IQueryable<MedicGroupCrm> data)
        {
            return (from y in data
                    select new Models.MedicGroupCRMViewModel
                    {
                        CRM = y.Crm,
                        MedicGroupCRMId = y.MedicGroupCrmid,
                        MedicGroupId = y.MedicGroupId,
                        CRMEstado = y.Crmestado,
                        Nome = y.Nome,
                        CPF = y.Cpf
                    }).ToList();
        }

        public override MedicGroupCRMViewModel GetDataViewModel(MedicGroupCrm data)
        {
            return new Models.MedicGroupCRMViewModel
            {
                CRM = data.Crm,
                MedicGroupCRMId = data.MedicGroupCrmid,
                MedicGroupId = data.MedicGroupId,
                CRMEstado = data.Crmestado,
                CPF = data.Cpf,
                Nome = data.Nome
            };
        }

        public override void Update(MedicGroupCRMViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool ExiteCRM(string crm, string crmEstado, int medicGroupId)
        {
            return this.dbSet.Any(x => x.Crm == crm && x.Crmestado == crmEstado && x.MedicGroupId == medicGroupId);
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
            this.dbSet = context.MedicGroupCrm;
        }
    }
}
