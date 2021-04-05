using Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VendasDbContext;

namespace Web.Services.Shared
{
    public abstract class InsuranceBaseListService<TEntity, TModel, Key>
        where TEntity : class
        where TModel : class
    {
        public DbSet<TEntity> dbSet;
        internal readonly DB.Models.Insurance_HomologContext context;
        internal readonly string keyName;
        internal readonly string table;
        internal readonly string schema;
        public InsuranceBaseListService(DB.Models.Insurance_HomologContext context, string keyName)
        {
            this.context = context;
            this.dbSet = (DbSet<TEntity>)context.GetType().GetProperty(typeof(TEntity).Name).GetValue(context);
            this.keyName = keyName;


            var mapping = this.context.Model.FindEntityType(typeof(TEntity)).Relational();
            table = mapping.TableName;
            schema = mapping.Schema ?? "dbo";
        }

        public TEntity GetDataById(Key id)
        {
            string query = $"SELECT * FROM [{schema}].[{table}] WHERE [{keyName}] = @Id";

            return dbSet.FromSql(query, new SqlParameter("@Id", id)).SingleOrDefault();
        }
        public async Task<TEntity> GetDataByIdAsync(Key id)
        {
            string query = $"SELECT * FROM [{schema}].[{table}] WHERE [{keyName}] = @Id";

            return await dbSet.FromSql(query, new SqlParameter("@Id", id)).SingleOrDefaultAsync();
        }
        public List<TEntity> GetData(Expression<Func<TEntity, bool>> expr = null)
        {
            if (expr != null)
                return this.dbSet.Where(expr).ToList();

            return dbSet.ToList();
        }
        public async Task<List<TEntity>> GetDataAsync(Expression<Func<TEntity, bool>> expr = null)
        {
            if (expr != null)
                return await dbSet.Where(expr).ToListAsync();

            return await dbSet.ToListAsync();
        }
        public List<TEntity> GetDataAsNoTracking(Expression<Func<TEntity, bool>> expr = null)
        {
            if (expr != null)
                return this.dbSet.Where(expr).AsNoTracking().ToList();

            return this.dbSet.AsNoTracking().ToList();
        }
        public async Task<List<TEntity>> GetDataAsNoTrackingAsync(Expression<Func<TEntity, bool>> expr = null)
        {
            if (expr != null)
                return await dbSet.Where(expr).AsNoTracking().ToListAsync();

            return await dbSet.AsNoTracking().ToListAsync();
        }

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
            return ToViewModel(GetDataById(id));
        }
        public List<TModel> GetViewModel(Expression<Func<TEntity, bool>> expr = null)
        {
            List<TEntity> entities;

            if (expr != null) entities = GetData(expr);
            else entities = GetData();

            return ToViewModel(entities);
        }
        public async Task<TModel> GetViewModelByIdAsync(Key id)
        {
            return ToViewModel(await GetDataByIdAsync(id));
        }
        public async Task<List<TModel>> GetViewModelAsync(Expression<Func<TEntity, bool>> expr = null)
        {
            List<TEntity> entities;

            if (expr != null) entities = (await GetDataAsync(expr));
            else entities = (await GetDataAsync());

            return ToViewModel(entities);
        }
        public List<TModel> GetViewModelAsNoTracking(Expression<Func<TEntity, bool>> expr = null)
        {
            List<TEntity> entities;

            if (expr != null) entities = GetDataAsNoTracking(expr);
            else entities = GetDataAsNoTracking();

            return ToViewModel(entities);
        }
        public async Task<List<TModel>> GetViewModelAsNoTrackingAsync(Expression<Func<TEntity, bool>> expr = null)
        {
            List<TEntity> entities;

            if (expr != null)
                entities = await GetDataAsNoTrackingAsync(expr);
            else entities = await GetDataAsNoTrackingAsync();

            return ToViewModel(entities);
        }
        public async Task<bool> Exist(Expression<Func<TEntity, bool>> expr) => await this.dbSet.AnyAsync(expr);

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> expr = null) => await this.dbSet.CountAsync(expr);
    }
}
