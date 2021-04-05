using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class InsurancePolicyFunctions : BLLBasicFunctions<InsurancePolicy, InsurancePolicyViewModel>
    {
        public InsurancePolicyFunctions(AMaisImob_HomologContext context)
            : base(context, "InsurancePolicyId")
        {
        }

        public override int Create(InsurancePolicyViewModel model)
        {
            var insurancePolicy = new InsurancePolicy
            {
                EndDate = model.EndDate.Value,
                StartDate = model.StartDate.Value,
                InsurancePolicyNumber = model.InsurancePolicyNumber,
                CompanyId = model.CompanyId.Value,
                ProductId = model.ProductId.Value,
                EndRegisteredDate = model.EndRegisteredDate,
                StartRegisteredDate = model.StartRegisteredDate
            };

            this.dbSet.Add(insurancePolicy);
            this.context.SaveChanges();

            return insurancePolicy.InsurancePolicyId;
        }

        public override void Delete(object id)
        {
            var insurancePolicy = GetDataByID(id);

            insurancePolicy.IsDeleted = true;

            this.dbSet.Update(insurancePolicy);
            this.context.SaveChanges();
        }

        public override List<InsurancePolicyViewModel> GetDataViewModel(IEnumerable<InsurancePolicy> data)
        {
            return (from y in data
                    select new InsurancePolicyViewModel
                    {
                        CreatedDate = y.CreatedDate,
                        EndDate = y.EndDate,
                        InsurancePolicyId = y.InsurancePolicyId,
                        InsurancePolicyNumber = y.InsurancePolicyNumber,
                        IsDeleted = y.IsDeleted,
                        ModifiedDate = y.ModifiedDate,
                        StartDate = y.StartDate,
                        CompanyId = y.CompanyId,
                        ProductId = y.ProductId,
                        EndRegisteredDate = y.EndRegisteredDate,
                        StartRegisteredDate = y.StartRegisteredDate
                    }).ToList();
        }

        public override InsurancePolicyViewModel GetDataViewModel(InsurancePolicy data)
        {
            return new InsurancePolicyViewModel
            {
                CreatedDate = data.CreatedDate,
                EndDate = data.EndDate,
                InsurancePolicyId = data.InsurancePolicyId,
                InsurancePolicyNumber = data.InsurancePolicyNumber,
                IsDeleted = data.IsDeleted,
                ModifiedDate = data.ModifiedDate,
                StartDate = data.StartDate,
                CompanyId = data.CompanyId,
                ProductId = data.ProductId,
                EndRegisteredDate = data.EndRegisteredDate,
                StartRegisteredDate = data.StartRegisteredDate
            };
        }

        public List<_InsurancePolicyViewModel> _GetDataViewModel(IEnumerable<InsurancePolicy> data)
        {
            var products = this.context.Product.Where(x => !x.IsDeleted);
            var companies = this.context.Company.Where(x => !x.IsDeleted);

            return (from y in data
                    join p in products on y.ProductId equals p.ProductId
                    join c in companies on y.CompanyId equals c.CompanyId
                    select new _InsurancePolicyViewModel
                    {
                        CreatedDate = y.CreatedDate,
                        EndDate = y.EndDate,
                        InsurancePolicyId = y.InsurancePolicyId,
                        InsurancePolicyNumber = y.InsurancePolicyNumber,
                        IsDeleted = y.IsDeleted,
                        ModifiedDate = y.ModifiedDate,
                        StartDate = y.StartDate,
                        CompanyId = y.CompanyId,
                        CompanyName = string.IsNullOrWhiteSpace(c.RazaoSocial) ? c.FirstName + " " + c.LastName : c.RazaoSocial,
                        ProductName = p.Name,
                        ProductId = y.ProductId,
                        EndRegisteredDate = y.EndRegisteredDate,
                        StartRegisteredDate = y.StartRegisteredDate,
                        ProductExternalCode = p.ExternalCode
                    }).ToList();
        }

        public _InsurancePolicyViewModel _GetDataViewModel(InsurancePolicy data)
        {
            var product = this.context.Product.Single(x => !x.IsDeleted && x.ProductId == data.ProductId);
            var company = this.context.Company.Single(x => !x.IsDeleted && x.CompanyId == data.CompanyId);

            return  new _InsurancePolicyViewModel
                    {
                        CreatedDate = data.CreatedDate,
                        EndDate = data.EndDate,
                        InsurancePolicyId = data.InsurancePolicyId,
                        InsurancePolicyNumber = data.InsurancePolicyNumber,
                        IsDeleted = data.IsDeleted,
                        ModifiedDate = data.ModifiedDate,
                        StartDate = data.StartDate,
                        CompanyId = data.CompanyId,
                        CompanyName = string.IsNullOrWhiteSpace(company.RazaoSocial) ? company.FirstName + " " + company.LastName : company.RazaoSocial,
                        ProductName = product.Name,
                        ProductId = data.ProductId,
                        EndRegisteredDate = data.EndRegisteredDate,
                        StartRegisteredDate = data.StartRegisteredDate
                    };
        }

        public override void Update(InsurancePolicyViewModel model)
        {
            var insurancePolicy = GetDataByID(model.InsurancePolicyId);

            insurancePolicy.InsurancePolicyNumber = model.InsurancePolicyNumber;
            insurancePolicy.ModifiedDate = DateTime.Now;
            insurancePolicy.StartDate = model.StartDate.Value;
            insurancePolicy.EndDate = model.EndDate.Value;
            insurancePolicy.CompanyId = model.CompanyId.Value;
            insurancePolicy.ProductId = model.ProductId.Value;
            insurancePolicy.EndRegisteredDate = model.EndRegisteredDate;
            insurancePolicy.StartRegisteredDate = model.StartRegisteredDate;

            this.dbSet.Update(insurancePolicy);
            this.context.SaveChanges();
        }

        public List<InsurancePolicyListViewModel> GetDataListViewModel(IEnumerable<InsurancePolicy> data)
        {
            var corretoraTypeId = this.context.CompanyType.Single(x => x.ExternalCode == "CORRETORA").CompanyTypeId;
            var corretoras = this.context.Company.Where(c => c.CompanyTypeId == corretoraTypeId && !c.IsDeleted);
            var personTypeId = this.context.CompanyOwnerType.Single(x => x.ExternalCode == "PERSON").CompanyOwnerTypeId;
            var products = this.context.Product.Where(x => !x.IsDeleted);

            return (from y in data
                    join co in corretoras on y.CompanyId equals co.CompanyId
                    join p in products on y.ProductId equals p.ProductId
                    select new Models.InsurancePolicyListViewModel
                    {
                        ProductId = y.ProductId,
                        CompanyId = y.CompanyId,
                        CreatedDate = y.CreatedDate,
                        EndDate = y.EndDate,
                        InsurancePolicyId = y.InsurancePolicyId,
                        InsurancePolicyNumber = y.InsurancePolicyNumber,
                        IsDeleted = y.IsDeleted,
                        ModifiedDate = y.ModifiedDate,
                        StartDate = y.StartDate,
                        EndRegisteredDate = y.EndRegisteredDate,
                        StartRegisteredDate = y.StartRegisteredDate,
                        ProductName = p.Name,
                        CorretoraName = co.CompanyOwnerTypeId == personTypeId ? co.FirstName + " " + co.LastName : co.NomeFantasia
                    }).ToList();
        }

        public List<_InsurancePolicyViewModel> GetInsurancePoliciesByRealEstateAgencyId(int id, bool showExpired)
        {
            return showExpired ? _GetDataViewModel(this.dbSet.Where(x => !x.IsDeleted && x.CompanyId == id)) : _GetDataViewModel(this.dbSet.Where(x => !x.IsDeleted && x.CompanyId == id && x.EndDate > DateTime.Now));
        }

        public bool ExistInsurancePolicyNumber(string insurancePolicyNumber)
        {
            return this.dbSet.Any(x => x.InsurancePolicyNumber == insurancePolicyNumber);
        }

        public bool IsInCertificate(int id)
        {
            return this.context.Certificate.Any(x => x.InsurancePolicyId == id && !x.IsDeleted);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.InsurancePolicy;
        }

        public int GetInfoByRealState(int companyId)
        {
            return 1;
        }
    }
}
