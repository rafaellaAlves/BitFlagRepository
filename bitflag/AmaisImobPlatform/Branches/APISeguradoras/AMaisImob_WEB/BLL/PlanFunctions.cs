using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class PlanFunctions : BLLBasicFunctions<Plan, PlanViewModel>
    {
        private readonly CertificateFunctions certificateFunctions;

        public PlanFunctions(AMaisImob_HomologContext context)
            : base(context, "PlanId")
        {
            this.certificateFunctions = new CertificateFunctions(context);
        }

        public override int Create(PlanViewModel model)
        {
            var plan = new Plan
            {
                Description = model.Description,
                Name = model.Name,
                ProductId = model.ProductId,
                CertificateId = model.CertificateId
            };

            this.dbSet.Add(plan);
            this.context.SaveChanges();

            return plan.PlanId;
        }

        public override void Delete(object id)
        {
            var plan = GetDataByID(id);
            plan.IsDeleted = true;

            this.dbSet.Update(plan);
            this.context.SaveChanges();
        }

        public void DeleteByCertificateId(int certificateId)
        {
            var plans = GetData(x => x.CertificateId == certificateId);

            foreach (var plan in plans)
            {
                plan.IsDeleted = true;
                this.dbSet.Update(plan);
            }

            this.context.SaveChanges();
        }

        public override List<PlanViewModel> GetDataViewModel(IEnumerable<Plan> data)
        {
            return (from y in data
                    select new PlanViewModel
                    {
                        Description = y.Description,
                        IsDeleted = y.IsDeleted,
                        Name = y.Name,
                        PlanId = y.PlanId,
                        ProductId = y.ProductId,
                        AssistanceId = y.AssistanceId,
                        CertificateId = y.CertificateId,
                        Certificate = y.CertificateId.HasValue? certificateFunctions.GetDataViewModel(certificateFunctions.GetDataByID(y.CertificateId)) : new CertificateViewModel()
                    }).ToList();
        }

        public override PlanViewModel GetDataViewModel(Plan data)
        {
            return new PlanViewModel
            {
                Description = data.Description,
                IsDeleted = data.IsDeleted,
                Name = data.Name,
                PlanId = data.PlanId,
                ProductId = data.ProductId,
                AssistanceId = data.AssistanceId,
                CertificateId = data.CertificateId,
                Certificate = data.CertificateId.HasValue ? certificateFunctions.GetDataViewModel(certificateFunctions.GetDataByID(data.CertificateId)) : new CertificateViewModel()
            };
        }

        public override void Update(PlanViewModel model)
        {
            var plan = GetDataByID(model.PlanId);

            plan.Name = model.Name;
            plan.Description = model.Description;

            this.dbSet.Update(plan);
            this.context.SaveChanges();
        }

        public void RemoveAssistance(int planId)
        {
            var plan = GetDataByID(planId);
            plan.AssistanceId = null;

            this.dbSet.Update(plan);
            this.context.SaveChanges();
        }

        public void SaveAssistance(int planId, int assistanceId)
        {
            var plan = GetDataByID(planId);

            plan.AssistanceId = assistanceId;

            this.dbSet.Update(plan);
            this.context.SaveChanges();
        }

        public void UpdateCertificateId(int planId, int certificateId)
        {
            var plan = GetDataByID(planId);
            plan.CertificateId = certificateId;
            plan.Description = "Plano Livre do Certificado #" + certificateId;

            this.dbSet.Update(plan);
            this.context.SaveChanges();
        }

        public bool IsInCertificate(int planId)
        {
            return this.context.Certificate.Any(x => x.PlanId == planId && !x.IsDeleted);
        }

        public double GetPlanPrice(int id)
        {
            var plan = GetDataByID(id);
            var planCoverages = this.context.PlanCoverage.Where(x => x.PlanId == id).ToList();
            var productCoverages = this.context.ProductCoverage.ToList();
            double price = 0;

            foreach (var planCoverage in planCoverages)
            {
                var productCoverage = productCoverages.SingleOrDefault(x => x.ProductCoverageId == planCoverage.ProductCoverageId);
                if (productCoverage == null) continue;

                price += (!productCoverage.IsOptional || planCoverage.Used) && planCoverage.Garantia.HasValue ? (productCoverage.Taxes / 100 * planCoverage.Garantia.Value) : 0;
            }

            return price;
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Plan;
        }
    }
}
