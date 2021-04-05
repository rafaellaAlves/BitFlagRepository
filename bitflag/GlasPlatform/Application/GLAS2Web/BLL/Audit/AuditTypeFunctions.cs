using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO.Audit;
using Utils;
namespace BLL.Audit
{
    public class AuditTypeFunctions : BLLBasicListFunctions<DAL.AuditType>
    {
        public AuditTypeFunctions(DAL.GLAS2Context context)
            : base(context, "AuditTypeId")
        {
            this.context = context;
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.AuditType;
        }
    }
}
