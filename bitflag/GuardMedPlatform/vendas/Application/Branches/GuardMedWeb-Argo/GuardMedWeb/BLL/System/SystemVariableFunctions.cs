using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL;
namespace GuardMedWeb.BLL.System
{
    public class SystemVariableFunctions : BLLBasicFunctions<DAL.SystemVariable, DAL.SystemVariable>
    {
        public SystemVariableFunctions(GuardMedWebContext context) 
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

        public override List<SystemVariable> GetDataViewModel(IQueryable<SystemVariable> data)
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
            var systemVariable = new DAL.SystemVariable()
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
