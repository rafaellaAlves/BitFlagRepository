using DB.Models;
using WEB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.BLL
{
    public class PlanCoverageFunctions : BLLBasicFunctions<PlanCoverage, PlanCoverageViewModel>
    {
        public PlanCoverageFunctions(Insurance_HomologContext context)
            : base(context, "PlanCoverageId")
        {
        }

        public override int Create(PlanCoverageViewModel model)
        {
            var planCoverage = new PlanCoverage
            {
                Garantia = model.Garantia,
                PlanId = model.PlanId.Value,
                ProductCoverageId = model.ProductCoverageId.Value,
                Used = model.Used
            };

            this.dbSet.Add(planCoverage);
            this.context.SaveChanges();

            return planCoverage.PlanCoverageId;
        }


        public void CreateRange(IEnumerable<PlanCoverage> model)
        {
            this.dbSet.AddRange(model);
            this.context.SaveChanges();
        }

        public override void Delete(object id)
        {
            var planCoverage = GetDataByID(id);

            this.dbSet.Remove(planCoverage);
            this.context.SaveChanges();
        }

        public void DeleteByPlanId(int planId)
        {
            var planCoverages = GetData().Where(x => x.PlanId == planId);

            foreach(var item in planCoverages)
                this.dbSet.Remove(item);

            this.context.SaveChanges();
        }

        public override List<PlanCoverageViewModel> GetDataViewModel(IEnumerable<PlanCoverage> data)
        {
            return (from y in data
                    select new PlanCoverageViewModel {
                        Garantia = y.Garantia,
                        PlanCoverageId = y.PlanCoverageId,
                        PlanId = y.PlanId,
                        ProductCoverageId = y.ProductCoverageId,
                        Used = y.Used
                    }).ToList();
        }

        public override PlanCoverageViewModel GetDataViewModel(PlanCoverage data)
        {
            return new PlanCoverageViewModel
            {
                Garantia = data.Garantia,
                PlanCoverageId = data.PlanCoverageId,
                PlanId = data.PlanId,
                ProductCoverageId = data.ProductCoverageId,
                Used = data.Used
            };
        }

        public List<PlanCoverageListViewModel> GetPlanCoverageListViewModel(IEnumerable<ProductCoverage> data, int? planId, int productId)
        {
            var planCoverage = this.dbSet.Where(x => x.PlanId == planId);

            var basic = context.ProductCoverage.SingleOrDefault(x => x.IsBasic && x.ProductId == productId);

            double? garantiaBase = null;
            if (basic != null && planId.HasValue)
            {
                var planoBase = this.dbSet.SingleOrDefault(x => x.ProductCoverageId == basic.ProductCoverageId && x.PlanId == planId);
                if (planoBase != null) garantiaBase = planoBase.Garantia;

            }
            return (from y in data
                    join pc in planCoverage on y.ProductCoverageId equals pc.ProductCoverageId into _pc
                    from __pc in _pc.DefaultIfEmpty()
                    select new PlanCoverageListViewModel
                    {
                        Name = y.Name,
                        ProductId = y.ProductId,
                        ProductCoverageId = y.ProductCoverageId,
                        Description = y.Description,
                        Taxes = y.Taxes,
                        Minimum = y.Minimum,
                        RealMinimum = y.Minimum??0,
                        Maximum = y.Maximum,
                        RealMaximum = garantiaBase.HasValue? y.Maximum > garantiaBase * y.BasicLimit / 100? (garantiaBase * y.BasicLimit / 100) : y.Maximum : y.Maximum,
                        BasicLimit = y.BasicLimit,
                        IsBasic = y.IsBasic,
                        IsOptional = y.IsOptional,
                        Franquias = y.Franquias,
                        Garantia = __pc != null ? __pc.Garantia : null,
                        Used = __pc != null ? (bool?)__pc.Used : null
                    }).ToList();
        }

        public override void Update(PlanCoverageViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.PlanCoverage;
        }
    }
}
