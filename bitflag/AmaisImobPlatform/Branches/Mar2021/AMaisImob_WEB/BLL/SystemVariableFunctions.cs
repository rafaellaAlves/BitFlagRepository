using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB;
using AMaisImob_DB.Models;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class SystemVariableFunctions : BLLBasicFunctions<SystemVariable, SystemVariable>
    {
        public SystemVariableFunctions(AMaisImob_HomologContext context)
            : base(context, "Key")
        {
        }

        public override int Create(SystemVariable model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SystemVariable> GetDataViewModel(IEnumerable<SystemVariable> data)
        {
            throw new NotImplementedException();
        }

        public override SystemVariable GetDataViewModel(SystemVariable data)
        {
            throw new NotImplementedException();
        }

        public override void Update(SystemVariable model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SystemVariable;
        }

        public void SetSystemVariable(string key, string value)
        {
            var systemVariable = new SystemVariable()
            {
                Key = key,
                Value = value
            };

            if (!string.IsNullOrWhiteSpace(key) && SystemVariableExists(key))
                this.dbSet.Update(systemVariable);
            else
                this.dbSet.Add(systemVariable);
            context.SaveChanges();
        }

        public string GetSystemVariable(string key)
        {
            if (SystemVariableExists(key))
                return this.dbSet.Single(x => x.Key.ToUpper() == key.ToUpper()).Value;
            else
                return null;
        }

        public bool SystemVariableExists(string key)
        {
            return this.dbSet.Any(x => x.Key.ToUpper() == key.ToUpper());
        }
    }
}
