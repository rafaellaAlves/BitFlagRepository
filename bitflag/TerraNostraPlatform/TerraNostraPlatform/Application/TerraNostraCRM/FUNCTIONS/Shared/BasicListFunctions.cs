using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Text;
using System.Data.SqlClient;

namespace FUNCTIONS
{
    public abstract class BasicListFunctions<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        protected DB.TerraNostraContext context;
        protected DbSet<TEntity> dbSet;
        protected string entityIdPropertyName;
        protected string sqlIdPropertyName;
        protected string schema;
        protected string tableName;

        public BasicListFunctions(DB.TerraNostraContext context, string entityIdPropertyName)
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
            return this.dbSet.FromSql<TEntity>(string.Format("SELECT * FROM [{0}].[{1}](NOLOCK) WHERE {2} = @Id", this.schema, this.tableName, this.sqlIdPropertyName), new SqlParameter("@Id", id)).SingleOrDefault();
        }
        public IQueryable<TEntity> GetData()
        {
            return (from l in this.dbSet select l);
        }
        public IQueryable<TEntity> GetData(Expression<Func<TEntity, bool>> _where)
        {
            return (from l in this.dbSet select l).Where(_where);
        }

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
        public virtual bool Exists(object id)
        {
            if (id == null)
                return false;

            using (var command = this.context.Database.GetDbConnection().CreateCommand())
            {
                this.context.Database.OpenConnection();
                command.CommandText = string.Format("SELECT COUNT(*) FROM [{0}].[{1}](NOLOCK) WHERE {2} = @Id", this.schema, this.tableName, this.sqlIdPropertyName);
                command.Parameters.Add(new SqlParameter("@Id", id));

                return (int)command.ExecuteScalar() > 0;
            }
        }

        protected abstract void SetDbSet();
        public abstract List<TViewModel> GetDataViewModel(IEnumerable<TEntity> data);
        public abstract TViewModel GetDataViewModel(TEntity data);
    }
}
