using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using BLL;

namespace WEB.BLL
{
    public class ProductPlanFunctions : BLLBasicFunctions<ProductPlan, ProductPlanViewModel>
    {
        public ProductPlanFunctions(Insurance_HomologContext context)
            : base(context, "ProductPlanId")
        {
        }

        public override int Create(ProductPlanViewModel model)
        {
            var productPlan = new ProductPlan
            {
                PlanId = model.PlanId,
                ProductId = model.ProductId
            };

            this.dbSet.Add(productPlan);
            this.context.SaveChanges();

            return productPlan.ProductPlanId;
        }

        public int? Create(int productId, List<int> planIds)
        {
            if (planIds.Count == 0) return null;

            ProductPlan productPlan = new ProductPlan();
            foreach (var planId in planIds)
            {
                productPlan = new ProductPlan
                {
                    ProductId = productId,
                    PlanId = planId
                };

                this.dbSet.Add(productPlan);
            }
            context.SaveChanges();

            return productPlan.ProductPlanId;
        }

        public override void Delete(object id)
        {
            var productPlan = GetDataByID(id);

            this.dbSet.Remove(productPlan);
            this.context.SaveChanges();
        }

        public void DeleteByProductId(int id)
        {
            foreach (var item in this.GetData().Where(x => x.ProductId == id))
                this.dbSet.Remove(item);

            this.context.SaveChanges();
        }

        public override List<ProductPlanViewModel> GetDataViewModel(IEnumerable<ProductPlan> data)
        {
            return (from y in data
                    select new ProductPlanViewModel
                    {
                        PlanId = y.PlanId,
                        ProductId = y.ProductId,
                        ProductPlanId = y.ProductPlanId
                    }).ToList();
        }

        public override ProductPlanViewModel GetDataViewModel(ProductPlan data)
        {
            return new ProductPlanViewModel
            {
                PlanId = data.PlanId,
                ProductId = data.ProductId,
                ProductPlanId = data.ProductPlanId
            };
        }

        public ProductPlanManageViewModel GetDataManageViewModel(int productId)
        {
            return (from y in this.context.Product
                    join pp in this.dbSet on y.ProductId equals pp.ProductId into _pp
                    from __pp in _pp.DefaultIfEmpty()
                    join p in this.context.Plan on __pp.PlanId equals p.PlanId into _p
                    from __p in _p.DefaultIfEmpty()
                    group new { y, __p } by new { y.ProductId, y.Name, y.Description } into _y
                    where _y.Key.ProductId == productId
                    select new ProductPlanManageViewModel
                    {
                        Product = new Product { Name = _y.Key.Name, ProductId = _y.Key.ProductId, Description = _y.Key.Description },
                        PlanIds = _y.Count(x => x.__p != null) > 0 ? _y.Select(x => x.__p.PlanId).ToList() : new List<int>()
                    }).FirstOrDefault();
        }

        public override void Update(ProductPlanViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ProductPlan;
        }
    }
}
