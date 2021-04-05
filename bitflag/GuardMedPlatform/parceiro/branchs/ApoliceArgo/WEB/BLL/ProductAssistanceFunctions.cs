using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using BLL;

namespace WEB.BLL
{
    public class ProductAssistanceFunctions : BLLBasicFunctions<DB.Models.ProductAssistance, WEB.Models.ProductAssistanceViewModel>
    {
        public ProductAssistanceFunctions(Insurance_HomologContext context)
            : base(context, "ProductAssistanceId")
        {
        }

        public override int Create(ProductAssistanceViewModel model)
        {
            ProductAssistance productAssistance = new ProductAssistance
            {
                ProductId = model.ProductId,
                AssistanceId = model.AssistanceId
            };

            this.dbSet.Add(productAssistance);
            context.SaveChanges();

            return productAssistance.ProductAssistanceId;
        }

        public int? Create(ProductAssistanceManageViewModel model)
        {
            if (model.AssistanceIds.Count == 0) return null;

            ProductAssistance productAssistance = new ProductAssistance();
            foreach (var assistanceId in model.AssistanceIds)
            {
                productAssistance = new ProductAssistance
                {
                    ProductId = model.Product.ProductId.Value,
                    AssistanceId = assistanceId
                };

                this.dbSet.Add(productAssistance);
            }
            context.SaveChanges();

            return productAssistance.ProductAssistanceId;
        }

        public int? Create(int productId, List<int> assistanceIds)
        {
            if (assistanceIds.Count == 0) return null;

            ProductAssistance productAssistance = new ProductAssistance();
            foreach (var assistanceId in assistanceIds)
            {
                productAssistance = new ProductAssistance
                {
                    ProductId = productId,
                    AssistanceId = assistanceId
                };

                this.dbSet.Add(productAssistance);
            }
            context.SaveChanges();

            return productAssistance.ProductAssistanceId;
        }

        public override void Delete(object id)
        {
            var productAssistance = GetDataByID(id);

            this.dbSet.Remove(productAssistance);
            context.SaveChanges();
        }

        public void DeleteByProductId(int productId)
        {
            var assistanceCompanies = GetData().Where(x => x.ProductId == productId);

            foreach (var productAssistance in assistanceCompanies)
                this.dbSet.Remove(productAssistance);

            context.SaveChanges();
        }

        public override List<ProductAssistanceViewModel> GetDataViewModel(IEnumerable<ProductAssistance> data)
        {
            return (from y in data
                    select new ProductAssistanceViewModel
                    {
                        ProductAssistanceId = y.ProductAssistanceId,
                        ProductId = y.ProductId,
                        AssistanceId = y.AssistanceId
                    }).ToList();
        }

        public ProductAssistanceManageViewModel GetDataManageViewModel(int productId)
        {
            return (from c in this.context.Product
                    join p in this.dbSet on c.ProductId equals p.ProductId into __p
                    from _p in __p.DefaultIfEmpty()
                    join a in this.context.Assistance on _p.AssistanceId equals a.AssistanceId into __a
                    from _a in __a.DefaultIfEmpty()
                    group new { c, _a } by new { c.ProductId, c.Name, c.Description, c.ExternalCode } into _y
                    where _y.Key.ProductId == productId
                    select new ProductAssistanceManageViewModel
                    {
                        Product = new ProductViewModel { Name = _y.Key.Name, ProductId = _y.Key.ProductId, Description = _y.Key.Description, ExternalCode = _y.Key.ExternalCode },
                        AssistanceIds = _y.Count(x => x._a != null) > 0 ? _y.Select(x => x._a.AssistanceId).ToList() : new List<int>()
                    }).FirstOrDefault();
        }

        public override ProductAssistanceViewModel GetDataViewModel(ProductAssistance data)
        {
            return new ProductAssistanceViewModel
            {
                ProductId = data.ProductId,
                ProductAssistanceId = data.ProductAssistanceId,
                AssistanceId = data.AssistanceId
            };
        }

        public IQueryable<ProductAssistance> GetDataByProductId(int productId)
        {
            return this.dbSet.Where(x => x.ProductId == productId);
        }

        public IEnumerable<ProductAssistance> GetDataByAssistanceId(int assistanceId)
        {
            return this.dbSet.Where(x => x.AssistanceId == assistanceId);
        }

        public override void Update(ProductAssistanceViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ProductAssistance;
        }
    }
}
