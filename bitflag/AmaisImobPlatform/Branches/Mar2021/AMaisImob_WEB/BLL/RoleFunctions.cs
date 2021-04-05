using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using AMaisImob_DB.Models;

namespace AMaisImob_WEB.BLL
{
    public class RoleFunctions : BLLBasicFunctions<AMaisImob_DB.Models.Role, AMaisImob_DB.Models.Role>
    {
        public RoleFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
            : base(context, "Id")
        {
        }

        public override int Create(AMaisImob_DB.Models.Role model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<AMaisImob_DB.Models.Role> GetDataViewModel(IEnumerable<AMaisImob_DB.Models.Role> data)
        {
            return data.ToList();
        }

        public override AMaisImob_DB.Models.Role GetDataViewModel(AMaisImob_DB.Models.Role data)
        {
            return data;
        }

        public override void Update(AMaisImob_DB.Models.Role model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Role;
        }
    }
}
