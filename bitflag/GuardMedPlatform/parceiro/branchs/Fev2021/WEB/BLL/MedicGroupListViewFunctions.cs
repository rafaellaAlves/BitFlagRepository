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

    public class MedicGroupListViewFunctions : BLLBasicVendasFunctions<MedicGroupListView, GroupMedicListViewModel>
    {
        public MedicGroupListViewFunctions(VendasContext context) : base(context, "MedicGroupId")
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


        public override GroupMedicListViewModel GetDataViewModel(MedicGroupListView data) => data.CopyToEntity<GroupMedicListViewModel>();

        public override List<GroupMedicListViewModel> GetDataViewModel(IEnumerable<MedicGroupListView> data) => data.Select(x => x.CopyToEntity<GroupMedicListViewModel>()).ToList();

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
