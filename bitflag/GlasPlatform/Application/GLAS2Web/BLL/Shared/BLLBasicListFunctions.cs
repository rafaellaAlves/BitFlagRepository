using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Text;

namespace BLL
{
    public abstract class BLLBasicListFunctions<TEntity> : IBLLBasicListFunctions<TEntity>
        where TEntity : class

    {
        protected DAL.GLAS2Context context;
        protected DbSet<TEntity> dbSet;
        protected string entityIdPropertyName;
        protected string sqlIdPropertyName;
        protected string schema;
        protected string tableName;

        public BLLBasicListFunctions(DAL.GLAS2Context context, string entityIdPropertyName)
        {
            this.context = context;
            SetDbSet();
            this.entityIdPropertyName = entityIdPropertyName;
            tableName = this.context.Model.FindEntityType(typeof(TEntity).FullName).Relational().TableName;
            schema = this.context.Model.FindEntityType(typeof(TEntity).FullName).Relational().Schema == null ? "dbo" : this.context.Model.FindEntityType(typeof(TEntity).FullName).Relational().Schema;
            sqlIdPropertyName = this.context.Model.FindEntityType(typeof(TEntity).FullName).FindProperty(entityIdPropertyName).Relational().ColumnName;
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
        public IEnumerable<TEntity> GetDataAsNoTracking(Func<TEntity, bool> where = null) => where == null ? this.dbSet.AsNoTracking() : this.dbSet.AsNoTracking().Where(where);

        public IQueryable<TEntity> GetDataFiltered(DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered)
        {
            return GetDataFiltered(filter, out recordsTotal, out recordsFiltered, null, new SqlParameter[] { });
        }
        public IQueryable<TEntity> GetDataFiltered(DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered, string whereSQL, SqlParameter whereParameter)
        {
            if (whereParameter == null)
                return GetDataFiltered(filter, out recordsTotal, out recordsFiltered, whereSQL, whereParameters: null);
            else
                return GetDataFiltered(filter, out recordsTotal, out recordsFiltered, whereSQL, new SqlParameter[] { whereParameter });
        }
        public IQueryable<TEntity> GetDataFiltered(DataTablesAjaxPostModel filter, out int recordsTotal, out int recordsFiltered, string whereSQL, SqlParameter[] whereParameters)
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
            sql.AppendFormat("SELECT {0} FROM [{1}].[{2}](NOLOCK) ", guid, this.schema, this.tableName);
            using (var command = this.context.Database.GetDbConnection().CreateCommand())
            {
                this.context.Database.OpenConnection();
                if (string.IsNullOrWhiteSpace(whereSQL))
                {
                    command.CommandText = string.Format("SELECT COUNT(*) FROM [{0}].[{1}](NOLOCK)", this.schema, this.tableName);
                }
                else
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    command.CommandText = string.Format("SELECT COUNT(*) FROM [{0}].[{1}](NOLOCK) WHERE " + whereSQL, this.schema, this.tableName);
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

                sql.AppendFormat(" {0} {1}, ", columnName, o.dir.ToUpper());
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

            return this.dbSet.FromSql<TEntity>(sql.ToString().Replace(guid, "*"), parameters.ToArray());
        }

        protected abstract void SetDbSet();
    }
}
