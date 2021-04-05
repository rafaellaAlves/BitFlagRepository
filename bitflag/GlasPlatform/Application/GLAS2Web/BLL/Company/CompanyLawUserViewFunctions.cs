using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using System.Configuration;

namespace BLL.Company
{
    public class CompanyLawUserViewFunctions : BLLBasicFunctions<DAL.CompanyLawUserView, DAL.CompanyLawUserView>
    {
        private readonly BLL.Company.CompanyLawFunctions companyLawFunctions;
        public CompanyLawUserViewFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyLawUserId")
        {
            this.companyLawFunctions = new BLL.Company.CompanyLawFunctions(context);
        }

        public override int Create(CompanyLawUserView model)
        {
            var companyLawActionUser = new DAL.CompanyLawUserView
            {
                CompanyId = model.CompanyId,
                UserId = model.UserId,
                LastView = DateTime.Now
            };

            this.dbSet.Add(companyLawActionUser);
            this.context.SaveChanges();

            return companyLawActionUser.CompanyId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyLawUserView> GetDataViewModel(IQueryable<CompanyLawUserView> data)
        {
            return (from y in data.ToList()
                     select new DAL.CompanyLawUserView()
                     {
                         CompanyLawUserId = y.CompanyLawUserId,
                         CompanyId = y.CompanyId,
                         UserId = y.UserId,
                         LastView = y.LastView
                     }).ToList();
        }

        public override CompanyLawUserView GetDataViewModel(CompanyLawUserView data)
        {
            return new DAL.CompanyLawUserView()
            {
                CompanyLawUserId = data.CompanyLawUserId,
                CompanyId = data.CompanyId,
                UserId = data.UserId,
                LastView = data.LastView
            };
        }

        public override void Update(CompanyLawUserView model)
        {
            var companyLawUser = this.GetDataByID(model.CompanyLawUserId);

            companyLawUser.LastView = DateTime.Now;
            
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawUserView;
        }

        public int GetCompanyLawUserId(int companyId, int userId)
        {
            var model = new DAL.CompanyLawUserView();
            model = this.GetData().FirstOrDefault(x => x.CompanyId == companyId && x.UserId == userId);
            if (model == null)
                return -1;

            return model.CompanyLawUserId.Value;
        }

        public int UnseenLaw (int companyLawUserId, int companyId)
        {
            var companyLawUser = new DAL.CompanyLawUserView();
            companyLawUser = this.GetDataByID(companyLawUserId);
            if (companyLawUser == null) return 0;

            if (companyLawUser.LastView == null) return companyLawFunctions.GetDataViewModel(companyLawFunctions.GetData().Where(x => x.CompanyId == companyId && x.IsDeleted == false)).Where(x => x.Law.RevokedDate == null).Count();

            return companyLawFunctions.GetDataViewModel(companyLawFunctions.GetData().Where(x => x.CreatedDate > companyLawUser.LastView && x.CompanyId == companyId && x.IsDeleted == false)).Where(x => x.Law.RevokedDate == null).Count();
        }

    }
}
