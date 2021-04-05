using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AMaisImob_WEB.Models;
using BLL;
using AMaisImob_DB.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AMaisImob_WEB.BLL
{
    public class UserFunctions : BLLBasicFunctions<AMaisImob_DB.Models.User, AMaisImob_WEB.Models.UserViewModel>
    {
        UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly RoleFunctions roleFunctions;

        public UserFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context, UserManager<AMaisImob_DB.Models.User> userManager)
            : base(context, "Id")
        {
            this.userManager = userManager;
            this.roleFunctions = new RoleFunctions(context);
        }


        public override int CreateOrUpdate(UserViewModel model, string entityIdPropertyName = "UserId")
        {
            return base.CreateOrUpdate(model, entityIdPropertyName);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.User;
        }

        public override int Create(UserViewModel model)
        {
            return _Create(model).Result;
        }

        public async Task<int> _Create(UserViewModel model)
        {
            var user = new AMaisImob_DB.Models.User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                MobileNumber = model.MobileNumber,
                IsActive = model.IsActive,
                BornDate = model.BornDate
            };

            var identityResult = await this.userManager.CreateAsync(user, model.Password);
            if (identityResult.Succeeded)
            {
                return user.Id;
            }
            else
            {
                return 0;
                //throw new Exception(string.Join(';', identityResult.Errors.Select(x => x.Code)));
            }
        }

        public override void Update(UserViewModel model)
        {
            var user = this.GetDataByID(model.UserId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.MobileNumber = model.MobileNumber;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.IsActive = model.IsActive;
            user.BornDate = model.BornDate;

            if (!string.IsNullOrWhiteSpace(model.Password))
                user.PasswordHash = this.userManager.PasswordHasher.HashPassword(user, model.Password);

            this.userManager.UpdateAsync(user);

            this.context.Update(user);
            this.context.SaveChanges();
        }

        public override void Delete(object id)
        {
            var user = this.GetDataByID(id);

            user.IsDeleted = true;
            user.UserName = null;
            user.NormalizedUserName = null;
            user.NormalizedEmail = null;

            this.context.Update(user);
            this.context.SaveChanges();
        }

        public void Delete(object id, int lastHandler)
        {
            var user = this.GetDataByID(id);

            user.IsDeleted = true;
            user.UserName = null;
            user.NormalizedUserName = null;
            user.NormalizedEmail = null;

            this.context.Update(user);
            this.context.SaveChanges();
        }

        public override List<UserViewModel> GetDataViewModel(IEnumerable<User> data)
        {
            var q = (from y in data.ToList()
                     select new UserViewModel()
                     {
                         UserId = y.Id,
                         FirstName = y.FirstName,
                         LastName = y.LastName,
                         Email = y.Email,
                         PhoneNumber = y.PhoneNumber,
                         MobileNumber = y.MobileNumber,
                         IsActive = y.IsActive,
                         BornDate = y.BornDate,
                         Role = GetRolesByUserId(y.Id)
                     }).ToList();

            return q;
        }

        public override UserViewModel GetDataViewModel(User data)
        {
            return new UserViewModel()
            {
                UserId = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                MobileNumber = data.MobileNumber,
                IsActive = data.IsActive,
                BornDate = data.BornDate,
                Role = GetRolesByUserId(data.Id)
            };
        }

        public void ClearUserRoles(int userId)
        {
            var userRoles = this.context.AspNetUserRoles.Where(x => x.UserId.Equals(userId)).ToArray();
            for (int i = 0; i < userRoles.Length; i++)
            {
                this.context.AspNetUserRoles.Remove(userRoles[i]);
            }
            this.context.SaveChanges();
        }

        public void AddUserToRole(int userId, string role)
        {
            var r = this.context.Role.Single(x => x.NormalizedName.Equals(role.ToUpper()));
            var anur = new AMaisImob_DB.Models.AspNetUserRoles()
            {
                RoleId = r.Id,
                UserId = userId
            };

            this.context.Add(anur);
            this.context.SaveChanges();
        }

        public void AddUserToRoles(int userId, List<string> roles)
        {
            foreach (var role in roles)
            {
                var r = this.context.Role.Single(x => x.NormalizedName.Equals(role.ToUpper()));
                var anur = new AMaisImob_DB.Models.AspNetUserRoles()
                {
                    RoleId = r.Id,
                    UserId = userId
                };

                this.context.Add(anur);
            }
            this.context.SaveChanges();
        }

        public string GetRolesByUserId(int id)
        {
            return (from y in dbSet
                    join ur in context.AspNetUserRoles on y.Id equals ur.UserId
                    join ro in context.Role on ur.RoleId equals ro.Id
                    where y.Id == id
                    select ro.Description).SingleOrDefault();
        }

        public List<User> GetDataByRole(string normalizedName)
        {
            return (from y in dbSet
                    join ur in context.AspNetUserRoles on y.Id equals ur.UserId
                    join ro in context.Role on ur.RoleId equals ro.Id
                    where ro.NormalizedName.Equals(normalizedName) && !y.IsDeleted
                    select y).ToList();
        }

        public List<User> GetUserWithoutCompanyByRoles(int companyId, params string[] normalizedNames)
        {
            return (from y in dbSet
                    join ur in context.AspNetUserRoles on y.Id equals ur.UserId
                    join ro in context.Role on ur.RoleId equals ro.Id
                    join uc in context.UserCompany on y.Id equals uc.UserId into _uc
                    from __uc in _uc.DefaultIfEmpty()
                    where normalizedNames.Contains(ro.NormalizedName) && !y.IsDeleted && (__uc == null || __uc.CompanyId == companyId)
                    select y).ToList();
        }

        public async Task<bool> CheckEmail(int? userId, string email) => !await this.dbSet.AnyAsync(x => x.Email == email && !x.IsDeleted && (!userId.HasValue || userId != x.Id));
    }

}
