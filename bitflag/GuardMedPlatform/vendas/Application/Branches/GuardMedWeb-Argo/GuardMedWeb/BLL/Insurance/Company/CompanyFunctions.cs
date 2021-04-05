using InsurenceDbContext;
using InsurenceDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.BLL.Insurance.Company
{
    public class CompanyFunctions
    {
        private readonly InsurenceContext context;

        public CompanyFunctions(InsurenceContext context)
        {
            this.context = context;
        }

        public bool TermsAreAccepted(int companyId)
        {
            var company = context.Company.SingleOrDefault(x => x.CompanyId == companyId);
            if (company == null) return false;

            return company.TermAccepted;
        }

    }
}
