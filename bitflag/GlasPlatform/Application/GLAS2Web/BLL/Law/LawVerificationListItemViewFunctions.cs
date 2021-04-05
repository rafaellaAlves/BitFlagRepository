using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Law
{
    public class LawVerificationListItemViewFunctions : BLLBasicListFunctions<LawVerificationListItemView>
    {
        public LawVerificationListItemViewFunctions(GLAS2Context context) : base(context, "LawVerificationListItemId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.LawVerificationListItemView;
        }
    }
}
