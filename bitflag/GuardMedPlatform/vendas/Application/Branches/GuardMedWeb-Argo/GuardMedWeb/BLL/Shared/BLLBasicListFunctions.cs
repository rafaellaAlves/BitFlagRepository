using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BLL
{
    public abstract class BLLBasicListFunctions<TEntity> : IBLLBasicListFunctions<TEntity>
        where TEntity : class

    {
        protected DAL.GuardMedWebContext context;
        protected DbSet<TEntity> dbSet;
        protected string entityIdPropertyName;

        public BLLBasicListFunctions(DAL.GuardMedWebContext context, string entityIdPropertyName)
        {
            this.context = context;
            SetDbSet();
            this.entityIdPropertyName = entityIdPropertyName;
        }
        public TEntity GetDataByID(object id)
        {
            return this.dbSet.SingleOrDefault(x => x.GetType().GetProperty(this.entityIdPropertyName).GetValue(x, null).Equals(id));
        }
        public IEnumerable<TEntity> GetData()
        {
            return (from x in this.dbSet select x);
        }
        public IEnumerable<TEntity> GetDataFiltered(Func<TEntity, bool> where)
        {
            return GetData().Where(where);
        }
        protected abstract void SetDbSet();
    }
}
