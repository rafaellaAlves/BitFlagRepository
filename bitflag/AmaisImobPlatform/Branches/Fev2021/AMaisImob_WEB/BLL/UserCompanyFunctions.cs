using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using Microsoft.AspNetCore.Internal;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace AMaisImob_WEB.BLL
{
    public class UserCompanyFunctions : BLLBasicFunctions<UserCompany, UserCompanyViewModel>
    {
        public UserCompanyFunctions(AMaisImob_HomologContext context)
            : base(context, "UserCompanyId")
        {
        }

        public override int Create(UserCompanyViewModel model)
        {
            if(this.dbSet.Any(x => x.UserId == model.UserId))
            {
                this.dbSet.RemoveRange(this.dbSet.Where(x => x.UserId == model.UserId));
                context.SaveChanges();
            }

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

        public override void Delete(object id)
        {
            var userCompany = GetDataByID(id);

            this.dbSet.Remove(userCompany);
            context.SaveChanges();
        }
        public async Task DeleteByUserId(int userId)
        {
            this.dbSet.RemoveRange(GetData(x => x.UserId == userId));
            await this.context.SaveChangesAsync();
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
                    join u in this.context.User on _uc.UserId equals u.Id into __u
                    from _u in __u.DefaultIfEmpty()
                    group new { c, _u } by new { c.CompanyId, c.RazaoSocial, c.NomeFantasia, c.FirstName, c.LastName, c.CompanyTypeId } into _y
                    where _y.Key.CompanyId == companyId
                    select new UserCompanyManageViewModel
                    {
                        Company = new CompanyViewModel { NomeFantasia = _y.Key.NomeFantasia, CompanyId = _y.Key.CompanyId, RazaoSocial = _y.Key.RazaoSocial, FirstName = _y.Key.FirstName, LastName = _y.Key.LastName, CompanyTypeId = _y.Key.CompanyTypeId },
                        UserIds = _y.Count(x => x._u != null) > 0 ? _y.Select(x => x._u.Id).ToList() : new List<int>()
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

        public IQueryable<UserCompany> GetDataByCompanyId(int companyId) => this.dbSet.Where(x => x.CompanyId == companyId).AsNoTracking();
        public IEnumerable<UserCompany> GetDataByCompanyId(IEnumerable<int> companyIds) => this.dbSet.Where(x => companyIds.Contains(x.CompanyId)).AsNoTracking();
        public async Task<IEnumerable<UserList>> GetUsersByCompanyId(int companyId, bool includeRealState = false)
        {
            if (includeRealState)
            {
                return this.context.UserList.FromSql("pr_GetUsersByCompanyId @CompanyId = @_CompanyId, @RemoveRealStateSellers = @_RemoveRealStateSellers",
                    new SqlParameter("@_CompanyId", companyId),
                    new SqlParameter("@_RemoveRealStateSellers", false));
            }
            else
            {
                var userIds = await GetDataByCompanyId(companyId).Select(x => x.UserId).ToListAsync();
                return await Task.Run(() => this.context.UserList.Where(x => userIds.Contains(x.UserId)).AsNoTracking());
            }
        }
        public IEnumerable<UserList> GetUsersByCompanyIdWithoutRealStateSellers(int companyId)
        {
            return this.context.UserList.FromSql("pr_GetUsersByCompanyId @CompanyId = @_CompanyId, @RemoveRealStateSellers = @_RemoveRealStateSellers",
                new SqlParameter("@_CompanyId", companyId),
                new SqlParameter("@_RemoveRealStateSellers", true));
        }

        public async Task<bool> Exits(int companyId, int userId)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "pr_UserCompanyExists @CompanyId = @_CompanyId, @UserId = @_UserId";
                command.Parameters.Add(new SqlParameter("@_CompanyId", companyId));
                command.Parameters.Add(new SqlParameter("@_UserId", userId));

                await context.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (result.Read()) return (bool)result["Exists"];
                }
            }

            return await Task.Run(() => false);
            //await Task.Run(async () => await this.dbSet.AnyAsync(x => companyId.Contains(x.CompanyId) && x.UserId == userId) || await this.dbSet.AnyAsync(x => companyId.Contains(x.Pare) && x.UserId == userId));
        }

        public IEnumerable<UserCompany> GetDataByUserId(int userId) => this.dbSet.Where(x => x.UserId == userId).AsNoTracking();

        public override void Update(UserCompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.UserCompany;
        }

        public async Task<List<User>> GetRealEstateAdministratorUser(int companyId)
        {
            var realEstateAdministratorRoleId = (await this.context.Role.SingleAsync(x => x.NormalizedName == "IMOBILIARIOADMINISTRATIVO")).Id;

            return await Task.Run(async () => await (from uc in this.dbSet.AsNoTracking()
                                                     join u in this.context.User.AsNoTracking() on uc.UserId equals u.Id
                                                     join r in this.context.AspNetUserRoles.AsNoTracking() on new { user = u.Id, role = realEstateAdministratorRoleId } equals new { user = r.UserId, role = r.RoleId }
                                                     where uc.CompanyId == companyId
                                                     select u).ToListAsync());
        }
        public async Task CopyCompaniesFromUser(int copyUserId, int pasteUserId)
        {
            var companies = await this.dbSet.Where(x => x.UserId == copyUserId).AsNoTracking().Select(x => x.CompanyId).ToListAsync();

            await this.dbSet.AddRangeAsync(companies.Select(x => new UserCompany
            {
                CompanyId = x,
                UserId = pasteUserId
            }));
            await this.context.SaveChangesAsync();
        }
    }
}
