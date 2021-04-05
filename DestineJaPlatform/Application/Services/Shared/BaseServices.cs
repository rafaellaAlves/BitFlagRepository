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
    public abstract class BaseServices<TEntity, TModel, Key> : BaseListServices<TEntity, TModel, Key>
        where TEntity : class
        where TModel : class
    {
        public BaseServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, string keyName) : base(context, identityContext, keyName)
        {
        }

        public BaseServices(ApplicationDbContext.Context.ApplicationDbContext context, string keyName) : base(context, keyName)
        {
        }

        #region [CREATE OR UPDATE]

        public Key CreateOrUpdate(TModel model)
        {
            if (typeof(TModel).GetProperty(keyName).GetValue(model, null) == null) return Create(model);
            else Update(model);

            return (Key)typeof(TModel).GetProperty(keyName).GetValue(model);
        }
        public async Task<Key> CreateOrUpdateAsync(TModel model)
        {
            if (typeof(TModel).GetProperty(keyName).GetValue(model, null) == null) return await CreateAsync(model);
            else await UpdateAsync(model);

            return (Key)typeof(TModel).GetProperty(keyName).GetValue(model);
        }

        #region [CREATE]
        public virtual Key Create(TModel model)
        {
            var entity = model.CopyToEntity<TEntity>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return (Key)typeof(TEntity).GetProperty(keyName).GetValue(entity);
        }
        public virtual async Task<Key> CreateAsync(TModel model)
        {
            var entity = model.CopyToEntity<TEntity>();

            await this.dbSet.AddAsync(entity);
            await this.context.SaveChangesAsync();

            return (Key)typeof(TEntity).GetProperty(keyName).GetValue(entity);
        }
        #endregion

        #region [UPDATE]
        /// <summary>
        /// Update only proprierties that are setted with Update Attribute (if no proprierty has update attribute all will be update).
        /// </summary>
        /// <param name="model"></param>
        public void Update(TModel model)
        {
            var id = (Key)typeof(TModel).GetProperty(keyName).GetValue(model);

            var entity = GetDataById(id);
            model.CopyToEntity<TEntity>(ref entity);

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
        /// <summary>
        /// Update only proprierties that are setted with Update Attribute (if no proprierty has update attribute all will be update).
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TModel model)
        {
            var id = (Key)typeof(TModel).GetProperty(keyName).GetValue(model);

            var entity = GetDataById(id);
            model.CopyToEntity<TEntity>(ref entity);

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public void Update(TEntity data)
        {
            var id = (Key)typeof(TEntity).GetProperty(keyName).GetValue(data);

            var entity = GetDataById(id);
            data.CopyToEntity<TEntity>(ref entity, false);

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
        /// <summary>
        /// Update only proprierties that are setted with Update Attribute (if no proprierty has update attribute all will be update).
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TEntity data)
        {
            var id = (Key)typeof(TEntity).GetProperty(keyName).GetValue(data);

            var entity = GetDataById(id);
            data.CopyToEntity<TEntity>(ref entity, false);

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        #endregion

        #endregion

        #region [DELETE]
        public void Delete(Key id, int? userId = null)
        {
            var data = GetDataById(id);

            var isDel = typeof(TEntity).GetProperties().SingleOrDefault(x => x.Name.ToUpper() == "ISDELETED");
            if (isDel != null) isDel.SetValue(data, true);

            var delBy = typeof(TEntity).GetProperties().SingleOrDefault(x => x.Name.ToUpper() == "DELETEDBY");
            if (delBy != null && userId.HasValue) delBy.SetValue(data, userId);

            var delDate = typeof(TEntity).GetProperties().SingleOrDefault(x => x.Name.ToUpper() == "DELETEDDATE");
            if (delDate != null) delDate.SetValue(data, DateTime.Now);

            this.dbSet.Update(data);
            this.context.SaveChanges();
            this.identityContext?.SaveChanges();
        }
        public async Task DeleteAsync(Key id, int? userId = null)
        {
            var data = await GetDataByIdAsync(id);

            var isDel = typeof(TEntity).GetProperties().SingleOrDefault(x => x.Name.ToUpper() == "ISDELETED");
            if (isDel != null) isDel.SetValue(data, true);

            var delBy = typeof(TEntity).GetProperties().SingleOrDefault(x => x.Name.ToUpper() == "DELETEDBY");
            if (delBy != null && userId.HasValue) delBy.SetValue(data, userId);

            var delDate = typeof(TEntity).GetProperties().SingleOrDefault(x => x.Name.ToUpper() == "DELETEDDATE");
            if (delDate != null) delDate.SetValue(data, DateTime.Now);

            this.dbSet.Update(data);
            await this.context.SaveChangesAsync();
            await this.identityContext?.SaveChangesAsync();
        }
        public void DeleteDefinitively(Key id)
        {
            this.dbSet.Remove(GetDataById(id));
            this.context.SaveChanges();
        }
        public async Task DeleteDefinitivelyAsync(Key id)
        {
            this.dbSet.Remove(GetDataById(id));
            await this.context.SaveChangesAsync();
        }
        #endregion
    }
}
