using AMaisImob_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class ResidenceTypeFunctions : BLL.Shared.BLLBasicListFunctions<ResidenceType, ResidenceType>
    {
        public ResidenceTypeFunctions(AMaisImob_HomologContext context) : base(context, "ResidenceTypeId")
        {
        }

        public override List<ResidenceType> GetDataViewModel(IEnumerable<ResidenceType> data)
        {
            return data.ToList();
        }

        public override ResidenceType GetDataViewModel(ResidenceType data)
        {
            return data;
        }
        public ResidenceType GetByExternalCode(string externalCode)
        {
            return this.dbSet.SingleOrDefault(x => x.ExternalCode == externalCode);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ResidenceType;
        }
    }
}
