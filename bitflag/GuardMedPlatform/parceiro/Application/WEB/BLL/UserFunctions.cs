using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WEB.Models;
using BLL;
using DB.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;

namespace WEB.BLL
{
    public class UserFunctions : BLLBasicFunctions<DB.Models.User, WEB.Models.UserViewModel>
    {
        UserManager<DB.Models.AspNetUser> userManager;
        private readonly RoleFunctions roleFunctions;

        public UserFunctions(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager)
            : base(context, "UserId")
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
            var user = new DB.Models.AspNetUser()
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
            var user = userManager.FindByIdAsync(Convert.ToString(model.UserId.Value)).Result;

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

            //this.context.Update(user);
            //this.context.SaveChanges();
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
                         UserId = y.UserId,
                         FirstName = y.FirstName,
                         LastName = y.LastName,
                         Email = y.Email,
                         PhoneNumber = y.PhoneNumber,
                         MobileNumber = y.MobileNumber,
                         IsActive = y.IsActive,
                         BornDate = y.BornDate,
                         Role = GetRolesByUserId(y.UserId)
                     }).ToList();

            return q;
        }
        public List<UserViewModel> GetDataViewModel(IEnumerable<AspNetUser> data)
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
                UserId = data.UserId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                MobileNumber = data.MobileNumber,
                IsActive = data.IsActive,
                BornDate = data.BornDate,
                Role = GetRolesByUserId(data.UserId)
            };
        }
        public UserViewModel GetDataViewModel(AspNetUser data)
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
            var anur = new DB.Models.AspNetUserRoles()
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
                var anur = new DB.Models.AspNetUserRoles()
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
                    join ur in context.AspNetUserRoles on y.UserId equals ur.UserId
                    join ro in context.Role on ur.RoleId equals ro.Id
                    where y.UserId == id
                    select ro.Description).SingleOrDefault();
        }

        public List<User> GetDataByRole(string normalizedName)
        {
            return (from y in dbSet
                    join ur in context.AspNetUserRoles on y.UserId equals ur.UserId
                    join ro in context.Role on ur.RoleId equals ro.Id
                    where ro.NormalizedName.Equals(normalizedName) && !y.IsDeleted
                    select y).ToList();
        }

        public List<User> GetUserWithoutCompanyByRoles(int companyId, params string[] normalizedNames)
        {
            return (from y in dbSet
                    join ur in context.AspNetUserRoles on y.UserId equals ur.UserId
                    join ro in context.Role on ur.RoleId equals ro.Id
                    join uc in context.UserCompany on y.UserId equals uc.UserId into _uc
                    from __uc in _uc.DefaultIfEmpty()
                    where normalizedNames.Contains(ro.NormalizedName) && !y.IsDeleted && (__uc == null || __uc.CompanyId == companyId)
                    select y).ToList();
        }

        public PlataformaEscritorioViewModel GetPlataformaEscritorioByUserId(int userId)
        {
            // Obter a company que o usuário se encontra.
            var userCompany = context.UserCompany.FirstOrDefault(x => x.UserId == userId);
            // Se ainda não foi alocado, retorna objeto em branco
            if (userCompany == null) return new PlataformaEscritorioViewModel(null, null);
            // Obter empresa do usuário
            var company = context.Company.SingleOrDefault(x => x.CompanyId == userCompany.CompanyId);
            // Se empresa não existir, retorna objeto em branco
            if (company == null) return new PlataformaEscritorioViewModel(null, null);

            if (company.CompanyTypeId == 1) // Se for plataforma
                return new PlataformaEscritorioViewModel(company.CompanyId, null);
            else if (company.CompanyTypeId == 2) // Se for escritório
                return new PlataformaEscritorioViewModel(company.ParentCompanyId, company.CompanyId);
            else  // PANICO!
                return new PlataformaEscritorioViewModel(null, null);
        }

        public bool ExistEmail(string email, int? userId = null)
        {
            var user = this.dbSet.FirstOrDefault(x => x.Email == email);

            return user != null && (!userId.HasValue || user.UserId != userId);

        }
    }

}
