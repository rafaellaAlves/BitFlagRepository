using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Company;

namespace BLL.Company
{
    public class CompanyUserFunctions : BLLBasicFunctions<DAL.CompanyUser, DTO.Company.CompanyUser>
    {
        private readonly Company.CompanyFunctions companyFunctions;

        public CompanyUserFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyUserId")
        {
            this.companyFunctions = new CompanyFunctions(context);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyUser;
        }

        public override int Create(DTO.Company.CompanyUser model)
        {
            var companyUser = new DAL.CompanyUser();

            companyUser.CompanyId = model.CompanyId;
            companyUser.UserId = model.UserId;
            companyUser.LastHandler = -1;

            this.dbSet.Add(companyUser);
            this.context.SaveChanges();

            return companyUser.CompanyUserId;
        }

        public override void Delete(object id)
        {
            var companyUser = this.GetDataByID(id);

            this.context.Remove(companyUser);
            this.context.SaveChanges();
        }

        public override List<DTO.Company.CompanyUser> GetDataViewModel(IQueryable<DAL.CompanyUser> data)
        {

            throw new NotImplementedException();

            //return (from cu in data
            //        join u in this.context.User on cu.UserId equals u.Id
            //        join ur in this.context.AspNetUserRoles on cu.UserId equals ur.UserId
            //        join r in this.context.Role on ur.RoleId equals r.Id
            //        group r by new { cu, u } into g
            //        select new DTO.Company.CompanyUser()
            //        {
            //            CompanyUserId = g.Key.cu.CompanyUserId,
            //            CompanyId = g.Key.cu.CompanyId,
            //            UserId = g.Key.cu.UserId,
            //            FirstName = g.Key.u.FirstName,
            //            LastName = g.Key.u.LastName,
            //            Email = g.Key.u.Email,
            //            Profile = string.Join(", ", g.Select(x => x.Description))
            //        }).ToList();
        }

        public override DTO.Company.CompanyUser GetDataViewModel(DAL.CompanyUser data)
        {
            throw new NotImplementedException();

            //return (from u in this.context.User
            //        join ur in this.context.AspNetUserRoles on data.UserId equals ur.UserId
            //        join r in this.context.Role on ur.RoleId equals r.Id
            //        group r by new { data, u } into g
            //        select new DTO.Company.CompanyUser()
            //        {
            //            CompanyUserId = g.Key.data.CompanyUserId,
            //            CompanyId = g.Key.data.CompanyId,
            //            UserId = g.Key.data.UserId,
            //            FirstName = g.Key.u.FirstName,
            //            LastName = g.Key.u.LastName,
            //            Email = g.Key.u.Email,
            //            Profile = string.Join(", ", g.Select(x => x.Description))
            //        }).FirstOrDefault();
        }

        public override void Update(DTO.Company.CompanyUser model)
        {
            throw new NotSupportedException();
        }


        public bool UserIsInCompany(int userId, int companyId)
        {
            //return (from cu in this.dbSet
            //        join ur in this.context.AspNetUserRoles on cu.UserId equals ur.UserId
            //        join r in this.context.Role on ur.RoleId equals r.Id
            //        join u in this.context.User on cu.UserId equals u.Id
            //        where cu.CompanyId.Equals(companyId) && cu.UserId.Equals(userId)
            //        select cu);

            return this.dbSet.Any(x => x.UserId == userId && x.CompanyId == companyId);
        }

        public List<DTO.Company.CompanyUser> UsersInCompany(int companyId, params string[] roles)
        {
            return this.GetDataViewModel((from cu in this.dbSet
                    join ur in this.context.AspNetUserRoles on cu.UserId equals ur.UserId
                    join r in this.context.Role on ur.RoleId equals r.Id
                    join u in this.context.User on cu.UserId equals u.Id
                    where cu.CompanyId.Equals(companyId)
                    select cu));

            //return GetDataViewModel(this.dbSet.Where(x => x.CompanyId == companyId));
        }

        public List<DTO.Company.CompanyViewModel> GetUserCompanies(int userId)
        {
            var companies = (from cu in this.dbSet
                             join c in this.context.Company on cu.CompanyId equals c.CompanyId
                             where cu.UserId.Equals(userId)
                             select c);

            return this.companyFunctions.GetDataViewModel(companies);
        }
    }


}
