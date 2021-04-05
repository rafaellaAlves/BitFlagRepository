using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class ProductCoverageFunctions : BLLBasicFunctions<ProductCoverage, ProductCoverageViewModel>
    {
        public ProductCoverageFunctions(AMaisImob_HomologContext context)
            : base(context, "ProductCoverageId")
        {
        }

        public override int Create(ProductCoverageViewModel model)
        {
            var ProductCoverage = new ProductCoverage
            {
                Name = model.Name,
                ProductId = model.ProductId,
                Taxes = model.Taxes.Value,
                BasicLimit = model.BasicLimit,
                IsBasic = model.IsBasic,
                IsOptional = model.IsOptional,
                Minimum = model.Minimum,
                Maximum = model.Maximum,
                Description = model.Description,
                Franquias = model.Franquias
            };

            this.dbSet.Add(ProductCoverage);
            this.context.SaveChanges();

            return ProductCoverage.ProductCoverageId;
        }

        public override void Delete(object id)
        {
            var ProductCoverage = GetDataByID(id);

            ProductCoverage.IsDeleted = true;
            this.dbSet.Update(ProductCoverage);
            this.context.SaveChanges();
        }

        public override List<ProductCoverageViewModel> GetDataViewModel(IEnumerable<ProductCoverage> data)
        {
            return (from y in data
                    select new ProductCoverageViewModel
                    {
                        Name = y.Name,
                        ProductId = y.ProductId,
                        ProductCoverageId = y.ProductCoverageId,
                        Description = y.Description,
                        Taxes = y.Taxes,
                        Minimum = y.Minimum,
                        Maximum = y.Maximum,
                        BasicLimit = y.BasicLimit,
                        IsBasic = y.IsBasic,
                        IsOptional = y.IsOptional,
                        Franquias = y.Franquias
                    }).ToList();
        }

        public override ProductCoverageViewModel GetDataViewModel(ProductCoverage data)
        {
            return new ProductCoverageViewModel
            {
                Name = data.Name,
                ProductId = data.ProductId,
                ProductCoverageId = data.ProductCoverageId,
                Description = data.Description,
                Taxes = data.Taxes,
                Minimum = data.Minimum,
                Maximum = data.Maximum,
                BasicLimit = data.BasicLimit,
                IsBasic = data.IsBasic,
                IsOptional = data.IsOptional,
                Franquias = data.Franquias
            };
        }

        public override void Update(ProductCoverageViewModel model)
        {
            var ProductCoverage = GetDataByID(model.ProductCoverageId);

            ProductCoverage.Name = model.Name;
            ProductCoverage.Description = model.Description;
            ProductCoverage.Taxes = model.Taxes.Value;
            ProductCoverage.BasicLimit = model.BasicLimit;
            ProductCoverage.IsBasic = model.IsBasic;
            ProductCoverage.IsOptional = model.IsOptional;
            ProductCoverage.Maximum = model.Maximum;
            ProductCoverage.Minimum = model.Minimum;
            ProductCoverage.Franquias = model.Franquias;

            this.dbSet.Update(ProductCoverage);
            this.context.SaveChanges();
        }

        public List<Models.ProductPlanCoverageViewModel> GetProductPlanCoverageViewModel(int planId)
        {
            var planCoverages = this.context.PlanCoverage.Where(c => c.PlanId == planId).ToList();
            var productCoverages = this.context.ProductCoverage.ToList();

            return (from y in planCoverages
                    join p in productCoverages on y.ProductCoverageId equals p.ProductCoverageId
                    select new ProductPlanCoverageViewModel
                    {
                        PlanId = y.PlanId,
                        BasicLimit = p.BasicLimit,
                        Description = p.Description,
                        Garantia = y.Garantia,
                        IsBasic = p.IsBasic,
                        IsDeleted = p.IsDeleted,
                        IsOptional = p.IsOptional,
                        Maximum = p.Maximum,
                        Minimum = p.Minimum,
                        Name = p.Name,
                        PlanCoverageId = y.PlanCoverageId,
                        ProductCoverageId = y.ProductCoverageId,
                        ProductId = p.ProductId,
                        Taxes = p.Taxes,
                        Used = y.Used,
                        Franquias = p.Franquias
                    }).ToList();
        }

        //public void GetProductPlanCoverageInfoForExport(ref List<CertificateExportViewModel> model)
        //{
        //    var planCoverages = this.context.PlanCoverage.ToList();
        //    var productCoverages = this.context.ProductCoverage.ToList();

        //    for (int i = 0; i < model.Count(); i++)
        //    {
        //        var planId = model[i].PlanId;
        //        model[i].Coverages = string.Join("; ", (from y in planCoverages.Where(x => x.PlanId == planId)
        //                                                  join p in productCoverages on y.ProductCoverageId equals p.ProductCoverageId
        //                                                  where !p.IsDeleted && (y.Used || !p.IsOptional)
        //                                                  select new
        //                                                  {
        //                                                      Garantia = y.Garantia,
        //                                                      Name = p.Name,
        //                                                  }).Select(x => x.Name + " - R$ " + x.Garantia.Value.ToString("#,##0.00")));
        //    }
        //}

        protected override void SetDbSet()
        {
            this.dbSet = context.ProductCoverage;
        }
    }
}
