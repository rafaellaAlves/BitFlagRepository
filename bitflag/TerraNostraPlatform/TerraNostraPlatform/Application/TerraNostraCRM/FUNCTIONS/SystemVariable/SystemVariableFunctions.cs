using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;

namespace FUNCTIONS.SystemVariable
{
    public class SystemVariableFunctions : BasicFunctions<DB.SystemVariable, DB.SystemVariable>
    {
        public SystemVariableFunctions(TerraNostraContext context) 
            : base(context, "Key")
        {
        }

        public string Get(string key)
        {
            var systemVariable = this.dbSet.FirstOrDefault(x => x.Key.ToUpper().Equals(key.ToUpper()));
            if (systemVariable == null) return string.Empty;

            return systemVariable.Value;
        }

        public override int Create(DB.SystemVariable model)
        {
            this.context.SystemVariable.Add(model);
            this.context.SaveChanges();

            return 0;
        }

        public override void Delete(object id)
        {
            var systemVariable = this.context.SystemVariable.Find(id);
            this.context.SystemVariable.Remove(systemVariable);
            this.context.SaveChanges();
        }

        public override List<DB.SystemVariable> GetDataViewModel(IEnumerable<DB.SystemVariable> data)
        {
            return data.ToList();
        }

        public override DB.SystemVariable GetDataViewModel(DB.SystemVariable data)
        {
            return data;
        }

        public List<DB.SystemVariable> List()
        {
            var filteredResult = this.context.SystemVariable.Where(s => s.Internal == false).ToList();
            return filteredResult;
        }

        public override void Update(DB.SystemVariable model)
        {
            this.context.SystemVariable.Update(model);
            this.context.SaveChanges();
        }

        public void CreateOrUpdate(DB.SystemVariable model)
        {
            if (this.dbSet.Any(x => x.Key == model.Key)) Update(model);
            else Create(model);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SystemVariable;
        }
    }
}
