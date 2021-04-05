using BLL;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.BLL
{
    public class CompanyAcceptTermsFunctions : BLLBasicFunctions<CompanyAcceptTerms, CompanyAcceptTermsViewModel>
    {
        public CompanyAcceptTermsFunctions(Insurance_HomologContext context) 
            : base(context, "CompanyAcceptTermsId")
        {
        }

        public override int Create(CompanyAcceptTermsViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyAcceptTermsViewModel> GetDataViewModel(IEnumerable<CompanyAcceptTerms> data)
        {
            return (from y in data
                    select new CompanyAcceptTermsViewModel {
                        CompanyAcceptTermsId = y.CompanyAcceptTermsId,
                        CompanyId = y.CompanyId,
                        CreatedDate = y.CreatedDate,
                        Email = y.Email,
                        FileName = y.FileName,
                        SentBy = y.SentBy
                    }).ToList();
        }

        public override CompanyAcceptTermsViewModel GetDataViewModel(CompanyAcceptTerms y)
        {
            return new CompanyAcceptTermsViewModel
            {
                CompanyAcceptTermsId = y.CompanyAcceptTermsId,
                CompanyId = y.CompanyId,
                CreatedDate = y.CreatedDate,
                Email = y.Email,
                FileName = y.FileName,
                SentBy = y.SentBy
            };
        }

        public override void Update(CompanyAcceptTermsViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyAcceptTerms;
        }
    }
}
