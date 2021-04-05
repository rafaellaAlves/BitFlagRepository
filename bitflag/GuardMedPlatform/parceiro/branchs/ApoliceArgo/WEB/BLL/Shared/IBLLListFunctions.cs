using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLLListFunctions<TEntity>
        where TEntity : class
    {
        TEntity GetDataByID(object id);
        IQueryable<TEntity> GetData();
        IQueryable<TEntity> GetDataFiltered(WEB.Models.DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered, string whereSQL, SqlParameter[] whereParameters);
    }
}
