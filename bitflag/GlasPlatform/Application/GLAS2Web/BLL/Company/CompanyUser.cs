using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Company;

namespace BLL.Company
{
    public class CompanyUserFunction : BLLBasicFunctions<DAL.CompanyUser, DTO.Company.CompanyUser>
    {
        private readonly Company.CompanyFunctions companyFunctions;

        public CompanyUserFunction(DAL.GLAS2Context context)
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
            //var r = (from cu in data
            //         join u in this.context.User on cu.UserId equals u.Id
            //         select new DTO.Company.CompanyUser()
            //         {
            //             CompanyUserId = cu.CompanyUserId,
            //             CompanyId = cu.CompanyId,
            //             UserId = cu.UserId,
            //             FirstName = u.FirstName,
            //             LastName = u.LastName,
            //             Email = u.Email,
            //             Profile = "Perfil"
            //         }).ToList();

            //return r;
        }

        public override DTO.Company.CompanyUser GetDataViewModel(DAL.CompanyUser data)
        {
            throw new NotImplementedException();
            //return (from u in this.context.User
            //        where u.Id == data.UserId
            //        select new DTO.Company.CompanyUser()
            //        {
            //            CompanyUserId = data.CompanyUserId,
            //            CompanyId = data.CompanyId,
            //            UserId = data.UserId,
            //            FirstName = u.FirstName,
            //            LastName = u.LastName,
            //            Email = u.Email,
            //            Profile = "[PERFIL]"
            //        }).FirstOrDefault();
        }

        public override void Update(DTO.Company.CompanyUser model)
        {
            throw new NotSupportedException();
        }


        public bool UserIsInCompany(int userId, int companyId)
        {
            return this.dbSet.Any(x => x.UserId == userId && x.CompanyId == companyId);
        }

        public List<DTO.Company.CompanyUser> UsersInCompany(int companyId)
        {
            return GetDataViewModel(this.dbSet.Where(x => x.CompanyId == companyId));
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
