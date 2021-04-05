using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using WEB.Models;

namespace WEB.BLL
{
    public class UserCompanyFunctions : BLLBasicFunctions<UserCompany, UserCompanyViewModel>
    {
        private readonly CompanyFunctions companyFunctions;
        private readonly UserFunctions userFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;
        public UserCompanyFunctions(Insurance_HomologContext context)
            : base(context, "UserCompanyId")
        {
            this.userManager = userManager;
            this.companyFunctions = new CompanyFunctions(context);
            this.userFunctions = new UserFunctions(context, userManager);
        }

        public override int Create(UserCompanyViewModel model)
        {
            UserCompany userCompany = new UserCompany
            {
                CompanyId = model.CompanyId,
                UserId = model.UserId
            };

            this.dbSet.Add(userCompany);
            context.SaveChanges();

            return userCompany.UserCompanyId;
        }

        public int? Create(UserCompanyManageViewModel model)
        {
            if (model.UserIds.Count == 0) return null;

            UserCompany userCompany = new UserCompany();
            foreach (var userId in model.UserIds)
            {
                userCompany = new UserCompany
                {
                    CompanyId = model.Company.CompanyId.Value,
                    UserId = userId
                };

                this.dbSet.Add(userCompany);
            }
            context.SaveChanges();

            return userCompany.UserCompanyId;
        }

        public int? Create(int companyId, List<int> userIds)
        {
            if (userIds.Count == 0) return null;

            UserCompany userCompany = new UserCompany();
            foreach (var userId in userIds)
            {
                userCompany = new UserCompany
                {
                    CompanyId = companyId,
                    UserId = userId
                };

                this.dbSet.Add(userCompany);
            }
            context.SaveChanges();

            return userCompany.UserCompanyId;
        }

        public int? AttachedToCompany(int companyId, int userId)
        {
            var userCompanies = this.dbSet.Where(x => x.UserId == userId);
            this.dbSet.RemoveRange(userCompanies);

            var userCompany = new UserCompany
            {
                CompanyId = companyId,
                UserId = userId
            };
            this.dbSet.Add(userCompany);

            context.SaveChanges();

            return userCompany.UserCompanyId;
        }

        public override void Delete(object id)
        {
            var userCompany = GetDataByID(id);

            this.dbSet.Remove(userCompany);
            context.SaveChanges();
        }

        public void DeleteByCompanyId(int companyId)
        {
            var userCompanies = GetData().Where(x => x.CompanyId == companyId);

            foreach (var userCompany in userCompanies)
                this.dbSet.Remove(userCompany);

            context.SaveChanges();
        }

        public void DeleteByCompanyIds(IEnumerable<int> companyIds)
        {
            var userCompanies = GetData().Where(x => companyIds.Contains(x.CompanyId));

            foreach (var userCompany in userCompanies)
                this.dbSet.Remove(userCompany);

            context.SaveChanges();
        }

        public override List<UserCompanyViewModel> GetDataViewModel(IEnumerable<UserCompany> data)
        {
            return (from y in data
                    select new UserCompanyViewModel
                    {
                        UserCompanyId = y.UserCompanyId,
                        CompanyId = y.CompanyId,
                        UserId = y.UserId
                    }).ToList();
        }

        public UserCompanyManageViewModel GetDataManageViewModel(int companyId)
        {
            return (from c in this.context.Company
                    join uc in this.dbSet on c.CompanyId equals uc.CompanyId into __uc
                    from _uc in __uc.DefaultIfEmpty()
                    join u in this.context.User on _uc.UserId equals u.UserId into __u
                    from _u in __u.DefaultIfEmpty()
                    group new { c, _u } by new { c.CompanyId, c.RazaoSocial, c.NomeFantasia, c.FirstName, c.LastName, c.CompanyTypeId } into _y
                    where _y.Key.CompanyId == companyId
                    select new UserCompanyManageViewModel
                    {
                        Company = new CompanyViewModel { NomeFantasia = _y.Key.NomeFantasia, CompanyId = _y.Key.CompanyId, RazaoSocial = _y.Key.RazaoSocial, FirstName = _y.Key.FirstName, LastName = _y.Key.LastName, CompanyTypeId = _y.Key.CompanyTypeId },
                        UserIds = _y.Count(x => x._u != null) > 0 ? _y.Select(x => x._u.UserId).ToList() : new List<int>()
                    }).FirstOrDefault();
        }

        public override UserCompanyViewModel GetDataViewModel(UserCompany data)
        {
            return new UserCompanyViewModel
            {
                CompanyId = data.CompanyId,
                UserCompanyId = data.UserCompanyId,
                UserId = data.UserId
            };
        }

        public IQueryable<UserCompany> GetDataByCompanyId(int companyId)
        {
            return this.dbSet.Where(x => x.CompanyId == companyId);
        }

        public IQueryable<UserCompany> GetUsersByCompanyId(List<int> companyId)
        {
            return this.dbSet.Where(x => companyId.Contains(x.CompanyId));
        }

        public IEnumerable<UserCompany> GetDataByUserId(int userId)
        {
            return this.dbSet.Where(x => x.UserId == userId);
        }

        public override void Update(UserCompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.UserCompany;
        }
    }
}
