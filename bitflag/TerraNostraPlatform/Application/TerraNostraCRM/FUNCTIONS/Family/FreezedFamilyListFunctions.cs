using DB;
using DTO.FreezedFamily;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Family
{
    public class FreezedFamilyListFunctions : BasicListFunctions<FreezedFamilyList, FreezedFamilyListViewModel>
    {
        public FreezedFamilyListFunctions(TerraNostraContext context) 
            : base(context, "FreezedFamilyId")
        {
        }

        public override List<FreezedFamilyListViewModel> GetDataViewModel(IEnumerable<FreezedFamilyList> data)
        {
            return data.Select(x => x.CopyToEntity<FreezedFamilyListViewModel>()).ToList();
        }

        public override FreezedFamilyListViewModel GetDataViewModel(FreezedFamilyList data)
        {
            return data.CopyToEntity<FreezedFamilyListViewModel>();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.FreezedFamilyList;
        }
    }
}
