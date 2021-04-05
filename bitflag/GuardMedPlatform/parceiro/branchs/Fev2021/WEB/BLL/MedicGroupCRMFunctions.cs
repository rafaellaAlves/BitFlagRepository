using BLL;
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
    public class MedicGroupCRMFunctions : BLLBasicVendasFunctions<MedicGroupCrm, MedicGroupCRMViewModel>
    {
        public MedicGroupCRMFunctions(VendasContext context) : base(context, "MedicGroupCRMId")
        {
        }

        public override int Create(MedicGroupCRMViewModel model)
        {
            var medicGroupCRM = model.CopyToEntity<MedicGroupCrm>();

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

        public override List<MedicGroupCRMViewModel> GetDataViewModel(IEnumerable<MedicGroupCrm> data) => data.Select(x => x.CopyToEntity<MedicGroupCRMViewModel>()).ToList();


        public override MedicGroupCRMViewModel GetDataViewModel(MedicGroupCrm data) => data.CopyToEntity<MedicGroupCRMViewModel>();

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
