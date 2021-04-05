using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class ProductFunctions : BLLBasicFunctions<Product, ProductViewModel>
    {
        public ProductFunctions(AMaisImob_HomologContext context)
            : base(context, "ProductId")
        {
        }

        public override int Create(ProductViewModel model)
        {
            var product = new Product
            {
                ExternalCode = model.ExternalCode,
                Name = model.Name,
                Description = model.Description,
                Discontinue = model.Discontinue.Value,
                ProductFamilyId = model.ProductFamilyId

            };

            this.dbSet.Add(product);
            this.context.SaveChanges();

            return product.ProductId;
        }

        public override void Delete(object id)
        {
            var product = this.GetDataByID(id);

            product.IsDeleted = true;
            this.dbSet.Update(product);
            this.context.SaveChanges();
        }

        public override List<ProductViewModel> GetDataViewModel(IEnumerable<Product> data)
        {
            return (from y in data select y.CopyToEntity<ProductViewModel>()).ToList();
        }

        public override ProductViewModel GetDataViewModel(Product data)
        {
            return data.CopyToEntity<ProductViewModel>();
        }

        public override void Update(ProductViewModel model)
        {
            var product = GetDataByID(model.ProductId);

            product.Name = model.Name;
            product.ExternalCode = model.ExternalCode;
            product.Description = model.Description;
            product.Discontinue = model.Discontinue.Value;
            product.ProductFamilyId = model.ProductFamilyId;

            this.dbSet.Update(product);
            this.context.SaveChanges();
        }


        public bool IsInInsurancePolicy(int id)
        {
            return this.context.InsurancePolicy.Any(x => x.ProductId == id && !x.IsDeleted);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Product;
        }

        public async Task<IEnumerable<Product>> GetDataByExternalCode(params string[] externalCodes) => await Task.Run(() => this.dbSet.Where(x => externalCodes.Contains(x.ExternalCode)));
    }
}
