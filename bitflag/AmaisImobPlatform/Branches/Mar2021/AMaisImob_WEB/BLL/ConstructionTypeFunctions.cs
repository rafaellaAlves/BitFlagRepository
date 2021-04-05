using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class ConstructionTypeFunctions : BLLBasicFunctions<AMaisImob_DB.Models.ConstructionType, AMaisImob_DB.Models.ConstructionType>
    {
        public ConstructionTypeFunctions(AMaisImob_HomologContext context) 
            : base(context, "ConstructionTypeId")
        {
        }

        public override int Create(ConstructionType model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<ConstructionType> GetDataViewModel(IEnumerable<ConstructionType> data)
        {
            return data.ToList();
        }

        public override ConstructionType GetDataViewModel(ConstructionType data)
        {
            return data;
        }

        public override void Update(ConstructionType model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ConstructionType;
        }
    }
}
