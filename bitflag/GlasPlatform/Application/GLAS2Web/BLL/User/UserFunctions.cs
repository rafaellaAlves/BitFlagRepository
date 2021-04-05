using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL;
using DTO.User;

namespace BLL.User
{
    public class UserFunctions : BLLBasicFunctions<DAL.Identity.User, UserModel>
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<DAL.Identity.User> userManager;
        public UserFunctions(DAL.GLAS2Context context, Microsoft.AspNetCore.Identity.UserManager<DAL.Identity.User> userManager)
            : base(context, "Id")
        {
            this.userManager = userManager;
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.User;
        }
        public override List<UserModel> GetDataViewModel(IQueryable<DAL.Identity.User> data)
        {
            var q = (from y in data.ToList()
                     join __ur in this.context.AspNetUserRoles on y.Id equals __ur.UserId into _ur
                     from ur in _ur.DefaultIfEmpty()
                     join r in this.context.Role on ur.RoleId equals r.Id
                     group new { y, r } by new { y, r } into g
                     select new UserModel()
                     {
                         UserId = g.Key.y.Id,
                         FirstName = g.Key.y.FirstName,
                         LastName = g.Key.y.LastName,
                         Email = g.Key.y.Email,
                         PhoneNumber = g.Key.y.PhoneNumber,
                         MobileNumber = g.Key.y.MobileNumber,
                         IsActive = g.Key.y.IsActive,
                         Skype = g.Key.y.Skype,
                         MainRole = g.Select(x => x.r.Name).FirstOrDefault(),
                         CreatedDate = g.Key.y.CreatedDate,
                         CreatedBy = g.Key.y.CreatedBy,
                         CultureInfo = g.Key.y.CultureInfo
                     }).ToList();

            return q;
        }
        public override UserModel GetDataViewModel(DAL.Identity.User data)
        {
            return new UserModel()
            {
                UserId = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                MobileNumber = data.MobileNumber,
                IsActive = data.IsActive,
                Skype = data.Skype,
                MainRole = (from ur in this.context.AspNetUserRoles
                            join r in this.context.Role on ur.RoleId equals r.Id
                            where ur.UserId == data.Id
                            select r.Name).FirstOrDefault(),
                CreatedDate = data.CreatedDate,
                CreatedBy = data.CreatedBy,
                CultureInfo = data.CultureInfo
            };
        }
        public override int CreateOrUpdate(UserModel model, string entityIdPropertyName = "UserId")
        {
            return base.CreateOrUpdate(model, entityIdPropertyName);
        }
        public override int Create(UserModel userModel)
        {
            return _Create(userModel).Result;
        }
        private async Task<int> _Create(UserModel userModel)
        {
            var user = new DAL.Identity.User()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.Email,
                Email = userModel.Email,
                PhoneNumber = userModel.PhoneNumber,
                MobileNumber = userModel.MobileNumber,
                IsActive = userModel.IsActive,
                Skype = userModel.Skype,
                CreatedBy = userModel.CreatedBy,
                CreatedDate = DateTime.Now,
                CultureInfo = userModel.CultureInfo ?? "pt-BR"
            };

            var identityResult = await this.userManager.CreateAsync(user, userModel.Password);
            if (identityResult.Succeeded)
                return user.Id;
            else
            {
                throw new Exception(string.Join(';', identityResult.Errors.Select(x => x.Code)));
            }
        }
        public override void Update(UserModel userModel)
        {
            var user = this.GetDataByID(userModel.UserId);

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.MobileNumber = userModel.MobileNumber;
            user.PhoneNumber = userModel.PhoneNumber;
            user.IsActive = userModel.IsActive;
            user.Skype = userModel.Skype;
            if (!string.IsNullOrWhiteSpace(userModel.Password))
                user.PasswordHash = this.userManager.PasswordHasher.HashPassword(user, userModel.Password);
            user.CultureInfo = userModel.CultureInfo;

            this.context.SaveChanges();
        }
        public override void Delete(object id)
        {
            var user = this.GetDataByID(id);

            user.IsDeleted = true;
            user.UserName = null;
            user.NormalizedUserName = null;
            user.NormalizedEmail = null;
            //user.LastHandler = -1;
            //user.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }
        public void DeleteByCompanyId(int companyId)
        {
            var userIds = this.context.CompanyUser.Where(x => x.CompanyId == companyId).Select(x => x.UserId);
            foreach (var item in this.context.User.Where(x => userIds.Contains(x.Id)))
            {
                item.IsDeleted = true;
                item.UserName = null;
                item.NormalizedUserName = null;
                item.NormalizedEmail = null;
            }

            this.context.SaveChanges();
        }
        public bool UserIsDeleted(int userId)
        {
            var user = this.GetDataByID(userId);
            if (user != null)
                return user.IsDeleted;
            else
                throw new Exception("Usuário não existe na base de dados");
        }
        public DateTime? LastAccessDate(int userId)
        {
            var user = this.GetDataByID(userId);
            if (user == null)
                return null;
            else
                return user.LastAccessDate;

        }
        public void SetLastAccessDate(int userId)
        {
            var user = this.GetDataByID(userId);
            if (user == null)
                return;

            user.LastAccessDate = DateTime.Now;

            this.context.SaveChanges();
        }
    }
}
