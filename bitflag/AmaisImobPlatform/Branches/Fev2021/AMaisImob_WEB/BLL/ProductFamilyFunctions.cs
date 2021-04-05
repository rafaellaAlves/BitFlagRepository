using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class ProductFamilyFunctions : BLLBasicFunctions<ProductFamily, ProductFamilyViewModel>
    {
        public ProductFamilyFunctions(AMaisImob_HomologContext context) : base(context, "ProductFamilyId")
        {
        }

        public override int Create(ProductFamilyViewModel model)
        {
            var entity = model.CopyToEntity<ProductFamily>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.ProductFamilyId;
        }

        public override void Delete(object id)
        {
            var entity = GetDataByID(id);

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
        public void Delete(object id, int userId)
        {
            var entity = GetDataByID(id);

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = userId;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public override List<ProductFamilyViewModel> GetDataViewModel(IEnumerable<ProductFamily> data)
        {
            return data.Select(x => x.CopyToEntity<ProductFamilyViewModel>()).ToList();
        }

        public override ProductFamilyViewModel GetDataViewModel(ProductFamily data)
        {
            return data.CopyToEntity<ProductFamilyViewModel>();
        }

        public override void Update(ProductFamilyViewModel model)
        {
            var entity = GetDataByID(model.ProductFamilyId);

            entity.Name = model.Name;
            entity.Description = model.Description;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ProductFamily;
        }

        public async Task<bool> IsInProduct(int productFamilyId) => await this.context.Product.AnyAsync(x => x.ProductFamilyId == productFamilyId);
    }
}
