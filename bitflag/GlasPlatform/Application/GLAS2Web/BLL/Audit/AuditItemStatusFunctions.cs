using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO.Audit;
using Utils;
namespace BLL.Audit
{
    public class AuditItemStatusFunctions : BLLBasicListFunctions<DAL.AuditItemStatus>
    {
        public AuditItemStatusFunctions(DAL.GLAS2Context context)
            : base(context, "AuditItemStatusId")
        {
            this.context = context;
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.AuditItemStatus;
        }
    }
}
