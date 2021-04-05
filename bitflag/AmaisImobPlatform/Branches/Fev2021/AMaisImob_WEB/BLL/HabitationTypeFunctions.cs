using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class HabitationTypeFunctions : BLLBasicFunctions<AMaisImob_DB.Models.HabitationType, AMaisImob_DB.Models.HabitationType>
    {
        public HabitationTypeFunctions(AMaisImob_HomologContext context) 
            : base(context, "HabitationTypeId")
        {
        }

        public override int Create(HabitationType model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<HabitationType> GetDataViewModel(IEnumerable<HabitationType> data)
        {
            return data.ToList();
        }

        public override HabitationType GetDataViewModel(HabitationType data)
        {
            return data;
        }

        public override void Update(HabitationType model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.HabitationType;
        }
    }
}
