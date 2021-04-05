using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public class EsferaFunctions : BLLBasicListFunctions<DAL.Esfera>
    {
        public EsferaFunctions(DAL.GLAS2Context context)
            : base(context, "EsferaId")
        {
        }

        public DAL.Esfera GetByExternalCode(string externalCode)
        {
            return this.dbSet.SingleOrDefault(x => x.ExternalCode == externalCode);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Esfera;
        }
    }
}
