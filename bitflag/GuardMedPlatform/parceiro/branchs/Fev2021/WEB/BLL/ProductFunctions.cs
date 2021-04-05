using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using BLL;

namespace WEB.BLL
{
    public class ProductFunctions : BLLBasicFunctions<Product, ProductViewModel>
    {
        public ProductFunctions(Insurance_HomologContext context)
            : base(context, "ProductId")
        {
        }

        public override int Create(ProductViewModel model)
        {
            var product = new Product
            {
                ExternalCode = model.ExternalCode,
                Name = model.Name,
                Description = model.Description
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
            return (from y in data
                    select new ProductViewModel
                    {
                        ExternalCode = y.ExternalCode,
                        Name = y.Name,
                        ProductId = y.ProductId,
                        Description = y.Description
                    }).ToList();
        }

        public override ProductViewModel GetDataViewModel(Product data)
        {
            return new ProductViewModel
            {
                ExternalCode = data.ExternalCode,
                Name = data.Name,
                ProductId = data.ProductId,
                Description = data.Description
            };
        }

        public override void Update(ProductViewModel model)
        {
            var product = GetDataByID(model.ProductId);

            product.Name = model.Name;
            product.ExternalCode = model.ExternalCode;
            product.Description = model.Description;

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
    }
}
