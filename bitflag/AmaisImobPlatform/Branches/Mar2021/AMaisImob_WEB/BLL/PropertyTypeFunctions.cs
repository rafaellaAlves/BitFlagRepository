using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class PropertyTypeFunctions : BLLBasicFunctions<AMaisImob_DB.Models.PropertyType, AMaisImob_DB.Models.PropertyType>
    {
        public PropertyTypeFunctions(AMaisImob_HomologContext context) 
            : base(context, "PropertyTypeId")
        {
        }

        public override int Create(PropertyType model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<PropertyType> GetDataViewModel(IEnumerable<PropertyType> data)
        {
            return data.ToList();
        }

        public override PropertyType GetDataViewModel(PropertyType data)
        {
            return data;
        }

        public override void Update(PropertyType model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.PropertyType;
        }
    }
}
