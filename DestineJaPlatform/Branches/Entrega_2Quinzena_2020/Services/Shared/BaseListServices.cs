using ApplicationDbContext.Context;
using DTO.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shared
{
    public abstract class BaseListServices<TEntity, TModel, Key>
        where TEntity : class
        where TModel : class
    {
        public DbSet<TEntity> dbSet;
        public ApplicationDbContext.Context.ApplicationDbContext context;
        public AspNetIdentityDbContext.ApplicationDbContext identityContext;
        public string keyName, table, schema;

        public BaseListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, string keyName)
        {
            this.identityContext = identityContext;
            this.context = context;
            this.dbSet = (DbSet<TEntity>)context.GetType().GetProperty(typeof(TEntity).Name).GetValue(context);
            this.keyName = keyName;
            table = this.context.Model.FindEntityType(typeof(TEntity)).GetTableName();
            schema = this.context.Model.FindEntityType(typeof(TEntity)).GetSchema() ?? "dbo";
        }

        public BaseListServices(ApplicationDbContext.Context.ApplicationDbContext context, string keyName)
        {
            this.context = context;
            this.dbSet = (DbSet<TEntity>)context.GetType().GetProperty(typeof(TEntity).Name).GetValue(context);
            this.keyName = keyName;
            table = this.context.Model.FindEntityType(typeof(TEntity)).GetTableName();
            schema = this.context.Model.FindEntityType(typeof(TEntity)).GetSchema() ?? "dbo";
        }

        #region [GET DATA]
        public TEntity GetDataById(Key id)
        {
            string query = $"SELECT * FROM [{schema}].[{table}] WHERE [{keyName}] = ";
            if (typeof(Key) == typeof(string)) query += $"'{id}'";
            else query += id;

            return dbSet.FromSqlRaw(query).SingleOrDefault();
        }
        public async Task<TEntity> GetDataByIdAsync(Key id)
        {
            string query = $"SELECT * FROM [{schema}].[{table}] WHERE [{keyName}] = ";
            if (typeof(Key) == typeof(string)) query += $"'{id}'";
            else query += id;

            return await dbSet.FromSqlRaw(query).SingleOrDefaultAsync();
        }
        public List<TEntity> GetData()
        {
            return dbSet.ToList();
        }
        public List<TEntity> GetData(Expression<Func<TEntity, bool>> expr)
        {
            return this.dbSet.Where(expr).ToList();
        }
        public async Task<List<TEntity>> GetDataAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<List<TEntity>> GetDataAsync(Expression<Func<TEntity, bool>> expr)
        {
            return await dbSet.Where(expr).ToListAsync();
        }
        public List<TEntity> GetDataAsNoTracking()
        {
            return this.dbSet.AsNoTracking().ToList();
        }
        public List<TEntity> GetDataAsNoTracking(Expression<Func<TEntity, bool>> expr)
        {
            return this.dbSet.Where(expr).AsNoTracking().ToList();
        }
        public async Task<List<TEntity>> GetDataAsNoTrackingAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<List<TEntity>> GetDataAsNoTrackingAsync(Expression<Func<TEntity, bool>> expr)
        {
            return await dbSet.Where(expr).AsNoTracking().ToListAsync();
        }
        public async Task<TEntity> GetFirstDataAsync(Expression<Func<TEntity, bool>> expr = null)
        {
            if(expr != null) return await dbSet.FirstOrDefaultAsync(expr);

            return await dbSet.FirstOrDefaultAsync();
        }
        public TEntity GetFirstData(Expression<Func<TEntity, bool>> expr = null)
        {
            if (expr != null) return dbSet.FirstOrDefault(expr);

            return dbSet.FirstOrDefault();
        }
        #endregion

        #region [GET VIEWMODEL]
        public virtual TModel ToViewModel(TEntity data)
        {
            return data.CopyToEntity<TModel>();
        }
        public virtual List<TModel> ToViewModel(IEnumerable<TEntity> datas)
        {
            return datas.Select(x => x.CopyToEntity<TModel>()).ToList();
        }
        public TModel GetViewModelById(Key id)
        {
            return GetDataById(id).CopyToEntity<TModel>();
        }
        public List<TModel> GetViewModel()
        {
            return GetData().Select(x => x.CopyToEntity<TModel>()).ToList();
        }
        public List<TModel> GetViewModel(Expression<Func<TEntity, bool>> expr)
        {
            return GetData(expr).Select(x => x.CopyToEntity<TModel>()).ToList();
        }
        public async Task<TModel> GetViewModelByIdAsync(Key id)
        {
            return (await GetDataByIdAsync(id)).CopyToEntity<TModel>();
        }
        public async Task<List<TModel>> GetViewModelAsync()
        {
            return (await GetDataAsync()).Select(x => x.CopyToEntity<TModel>()).ToList();
        }
        public async Task<List<TModel>> GetViewModelAsync(Expression<Func<TEntity, bool>> expr)
        {
            return (await GetDataAsync(expr)).Select(x => x.CopyToEntity<TModel>()).ToList();
        }
        public List<TModel> GetViewModelAsNoTracking()
        {
            return GetDataAsNoTracking().Select(x => x.CopyToEntity<TModel>()).ToList();
        }
        public List<TModel> GetViewModelAsNoTracking(Expression<Func<TEntity, bool>> expr)
        {
            return GetDataAsNoTracking(expr).Select(x => x.CopyToEntity<TModel>()).ToList();
        }
        public virtual async Task<List<TModel>> GetViewModelAsNoTrackingAsync()
        {
            return (await GetDataAsNoTrackingAsync()).Select(x => x.CopyToEntity<TModel>()).ToList();
        }
        public virtual async Task<List<TModel>> GetViewModelAsNoTrackingAsync(Expression<Func<TEntity, bool>> expr)
        {
            return (await GetDataAsNoTrackingAsync(expr)).Select(x => x.CopyToEntity<TModel>()).ToList();
        }
        #endregion

        #region [DATATABLES]
        public IQueryable<TEntity> GetDataFiltered(DTO.Shared.DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered)
        {
            return GetDataFiltered(filter, out recordsTotal, out recordsFiltered, null, new SqlParameter[] { });
        }
        public IQueryable<TEntity> GetDataFiltered(DTO.Shared.DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered, string whereSQL, SqlParameter whereParameter)
        {
            if (whereParameter == null)
                return GetDataFiltered(filter, out recordsTotal, out recordsFiltered, whereSQL, whereParameters: null);
            else
                return GetDataFiltered(filter, out recordsTotal, out recordsFiltered, whereSQL, new SqlParameter[] { whereParameter });
        }
        public IQueryable<TEntity> GetDataFiltered(DTO.Shared.DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered, string whereSQL, SqlParameter[] whereParameters)
        {
            var sql = new StringBuilder();
            var guid = Guid.NewGuid().ToString("D");
            var parameters = new List<SqlParameter>();

            #region [WHERE PARAMETERS]
            if (whereParameters != null)
                foreach (var whereParameter in whereParameters)
                    parameters.Add(whereParameter);
            #endregion

            #region [TOTAL COUNT]
            recordsFiltered = 1;
            sql.AppendFormat("SELECT {0} FROM [{1}].[{2}](NOLOCK) ", guid, this.schema, this.table);
            using (var command = this.context.Database.GetDbConnection().CreateCommand())
            {
                this.context.Database.OpenConnection();
                if (string.IsNullOrWhiteSpace(whereSQL))
                {
                    command.CommandText = string.Format("SELECT COUNT(*) FROM [{0}].[{1}](NOLOCK)", this.schema, this.table);
                }
                else
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    command.CommandText = string.Format("SELECT COUNT(*) FROM [{0}].[{1}](NOLOCK) WHERE " + whereSQL, this.schema, this.table);
                }
                recordsTotal = (int)command.ExecuteScalar();
                command.Parameters.Clear();
            }
            #endregion

            #region [APPLY COLUMN FILTER]
            bool hasColumnFilter = false;
            #region [CUSTOM WHERE]
            if (string.IsNullOrWhiteSpace(whereSQL))
                sql.Append("WHERE 1 = 1 AND ( ");
            else
                sql.Append("WHERE (" + whereSQL + ") AND ( ");
            #endregion

            //foreach (var c in filter.columns)
            //{
            //    if (string.IsNullOrWhiteSpace(filter.search.value)) break;
            //    if (string.IsNullOrWhiteSpace(c.data)) continue;
            //    if (typeof(TEntity).GetProperty(c.data) == null) continue;
            //    sql.Append("(");
            //    foreach (var q in filter.search.value.Split(','))
            //    {
            //        var parameterGuid = "PARAM_" + Guid.NewGuid().ToString("N");
            //        sql.Append("(" + c.data + " LIKE @" + parameterGuid + ") OR ");
            //        parameters.Add(new SqlParameter("@" + parameterGuid, "%" + q.Trim() + "%"));
            //    }
            //    sql = new StringBuilder(sql.ToString().Remove(sql.ToString().LastIndexOf("OR "), 3));
            //    sql.Append(") AND ");
            //    hasColumnFilter = true;
            //}
            if (!string.IsNullOrWhiteSpace(filter.search.value))
            {
                foreach (var q in filter.search.value.Split(','))
                {
                    sql.Append("(");
                    foreach (var c in filter.columns)
                    {
                        if (string.IsNullOrWhiteSpace(c.data)) continue;
                        if (typeof(TEntity).GetProperty(c.data) == null) continue;

                        var parameterGuid = "PARAM_" + Guid.NewGuid().ToString("N");
                        sql.Append("(" + c.data + " LIKE @" + parameterGuid + ") OR ");
                        parameters.Add(new SqlParameter("@" + parameterGuid, "%" + q.Trim() + "%"));

                    }
                    sql = new StringBuilder(sql.ToString().Remove(sql.ToString().LastIndexOf("OR "), 3));
                    sql.Append(") AND ");
                    hasColumnFilter = true;
                }
            }

            if (!hasColumnFilter)
                sql = new StringBuilder(sql.ToString().Remove(sql.ToString().LastIndexOf("AND ( "), 6));
            else
            {
                sql = new StringBuilder(sql.ToString().Remove(sql.ToString().LastIndexOf("AND "), 4));
                sql.Append(") ");
            }
            #endregion

            #region [FILTER COUNT]
            using (var command = this.context.Database.GetDbConnection().CreateCommand())
            {
                this.context.Database.OpenConnection();
                command.CommandText = sql.ToString().Replace(guid, "COUNT(*)");
                command.Parameters.AddRange(parameters.ToArray());
                recordsFiltered = (int)command.ExecuteScalar();
                command.Parameters.Clear();
            }
            #endregion

            #region [ORDER]
            sql.Append("ORDER BY ");
            bool isOrdered = false;
            foreach (var o in filter.order)
            {
                var columnName = filter.columns[o.column].data;
                if (string.IsNullOrWhiteSpace(columnName)) continue;
                if (typeof(TEntity).GetProperty(columnName) == null) continue;

                sql.AppendFormat(" [{0}] {1}, ", columnName, o.dir.ToUpper());
                isOrdered = true;
            }
            if (!isOrdered)
                sql.Append("1 ");
            else
                sql = new StringBuilder(sql.ToString().Remove(sql.ToString().LastIndexOf(","), 1));
            #endregion

            #region [PAGGING]
            if (filter.start.HasValue)
                sql.AppendFormat("OFFSET {0} ROWS ", (filter.start));
            else if (filter.length.HasValue)
                sql.Append("OFFSET 0 ROWS ");

            if (filter.length.HasValue) sql.AppendFormat("FETCH NEXT {0} ROWS ONLY ", filter.length);
            #endregion

            return this.dbSet.FromSqlRaw<TEntity>(sql.ToString().Replace(guid, "*"), parameters.ToArray());
        }
        #endregion

        public bool Exist(Key id)
        {
            return GetDataById(id) != null;
        }

        public async Task<bool> ExistAsync(Key id)
        {
            return await GetDataByIdAsync(id) != null;
        }
    }
}
