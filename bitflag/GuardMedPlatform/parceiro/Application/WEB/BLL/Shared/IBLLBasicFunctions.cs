using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLLBasicFunctions<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        TEntity GetDataByID(object id);
        IQueryable<TEntity> GetData();
        IQueryable<TEntity> GetDataFiltered(WEB.Models.DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered, string whereSQL, SqlParameter[] whereParameters);
        bool Exists(object id);
        int Create(TViewModel model);
        void Update(TViewModel model);
        void Delete(object id);

        List<TViewModel> GetDataViewModel(IEnumerable<TEntity> data);
        TViewModel GetDataViewModel(TEntity data);
    }
}
