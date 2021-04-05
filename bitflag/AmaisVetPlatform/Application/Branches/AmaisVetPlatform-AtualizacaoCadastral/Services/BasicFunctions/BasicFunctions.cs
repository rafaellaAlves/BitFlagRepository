using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationDbContext.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Services.BasicFunctions
{
    public abstract class BasicFunctions<TEntity, TViewModel, key>
        where TEntity : class
        where TViewModel : class
    {
        public DbSet<TEntity> dbSet;
        public ApplicationDbContext.Context.ApplicationDbContext context;
        public string keyName, table, schema;

        public BasicFunctions(ApplicationDbContext.Context.ApplicationDbContext context, string keyName)
        {
            this.context = context;
            this.dbSet = (DbSet<TEntity>)context.GetType().GetProperty(typeof(TEntity).Name).GetValue(context);
            this.keyName = keyName;
            table = this.context.Model.FindEntityType(typeof(TEntity)).GetTableName();
            schema = this.context.Model.FindEntityType(typeof(TEntity)).GetSchema() ?? "dbo";
        }

        public List<TEntity> GetData(Expression<Func<TEntity, bool>> expr)
        {
            return this.dbSet.Where(expr).ToList();
        }

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

        public bool Exist(Key id)
        {
            return GetDataById(id) != null;
        }

        public async Task<bool> ExistAsync(Key id)
        {
            return await GetDataByIdAsync(id) != null;
        }

        protected abstract void SetDbSet();
        public abstract int Create(TViewModel model);
        public abstract void Update(TViewModel model);
        public abstract void Delete(object id);
        public abstract List<TViewModel> GetDataViewModel(IQueryable<TEntity> data);
        public abstract TViewModel GetDataViewModel(TEntity data);


    }
}
