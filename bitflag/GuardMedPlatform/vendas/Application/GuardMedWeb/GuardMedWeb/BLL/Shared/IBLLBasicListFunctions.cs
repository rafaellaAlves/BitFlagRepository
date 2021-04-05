using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLLBasicListFunctions<TEntity>
        where TEntity : class
    {
        TEntity GetDataByID(object id);
        IEnumerable<TEntity> GetData();
        IEnumerable<TEntity> GetDataFiltered(Func<TEntity, bool> f);
    }
}
