using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO.Audit;
using Utils;
namespace BLL.Audit
{
    public class AuditStatusFunctions : BLLBasicListFunctions<DAL.AuditStatus>
    {
        public AuditStatusFunctions(DAL.GLAS2Context context)
            : base(context, "AuditStatusId")
        {
            this.context = context;
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.AuditStatus;
        }
    }
}
