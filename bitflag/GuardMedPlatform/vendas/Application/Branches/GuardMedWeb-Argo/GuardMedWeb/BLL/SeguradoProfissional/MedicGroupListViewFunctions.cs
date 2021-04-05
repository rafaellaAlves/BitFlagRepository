using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using GuardMedWeb.Models;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class MedicGroupListViewFunctions : BLLBasicFunctions<DAL.MedicGroupListView, GroupMedicListViewModel>
    {
        public MedicGroupListViewFunctions(GuardMedWebContext context) 
            : base(context, "MedicGroupId")
        {
        }

        public override int Create(GroupMedicListViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<GroupMedicListViewModel> GetDataViewModel(IQueryable<MedicGroupListView> data)
        {
            return (from y in data
                    select new GroupMedicListViewModel {
                        Discount = y.Discount.ToString("0.00"),
                        ExternalCode = y.ExternalCode,
                        IsActive = y.IsActive,
                        MedicGroupId = y.MedicGroupId,
                        MedicGroupName = y.MedicGroupName,
                        QtdCRM = y.QtdCRM,
                        CNPJ = y.CNPJ
                    }).ToList();
        }

        public override GroupMedicListViewModel GetDataViewModel(MedicGroupListView data)
        {
            return new GroupMedicListViewModel
            {
                Discount = data.Discount.ToString("0.00"),
                ExternalCode = data.ExternalCode,
                IsActive = data.IsActive,
                MedicGroupId = data.MedicGroupId,
                MedicGroupName = data.MedicGroupName,
                QtdCRM = data.QtdCRM,
                CNPJ = data.CNPJ
            };
        }

        public override void Update(GroupMedicListViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.MedicGroupListView;
        }
    }
}
