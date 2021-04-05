using AspNetIdentityDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Services.Account
{
    public class UserService
    {
        AspNetIdentityDbContext.ApplicationDbContext context;
        UserManager<User> userManager;
        RoleService roleService;
        public UserService(AspNetIdentityDbContext.ApplicationDbContext context, UserManager<User> userManager, RoleService roleService)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleService = roleService;
        }
        public async Task DeleteUser(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            user.IsDeleted = true;
            string deleted = "DELETED";
            int index = 0;

            while (this.context.Users.Any(x => x.UserName == $"{deleted}{index}"))
                index++;

            user.UserName = $"{deleted}{index}";
            user.NormalizedEmail = $"{deleted}{index}";
            user.NormalizedUserName = $"{deleted}{index}";
            user.Email = $"{deleted}{index}";
            user.NormalizedEmail = $"{deleted}{index}";

            await userManager.UpdateAsync(user);

            await this.context.SaveChangesAsync();
        }
        public async Task<int> ManageUser(DTO.User.UserViewModel userViewModel)
        {
            return userViewModel.UserId.HasValue ? await UpdateUser(userViewModel) : await CreateUser(userViewModel);
        }
        public async Task<int> CreateUser(DTO.User.UserViewModel userViewModel)
        {
            var result = await this.userManager.CreateAsync(new User()
            {
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                UserName = userViewModel.Email,
                Email = userViewModel.Email,
                IsActive = userViewModel.IsActive,
                CreationToken = userViewModel.CreationToken,
                TemporaryPassword = userViewModel.TemporaryPassword
            }, userViewModel.Password);

            if (!result.Succeeded)
                throw new Exception("Não foi possível criar o usuário");

            var user = await this.userManager.FindByNameAsync(userViewModel.Email);
            await AttachUserToRole(user.Id, userViewModel.RoleName);

            return user.Id;
        }
        public async Task<int> UpdateUser(DTO.User.UserViewModel userViewModel)
        {
            var user = await this.context.Users.FindAsync(userViewModel.UserId.Value);

            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.IsActive = userViewModel.IsActive;

            if (!string.IsNullOrWhiteSpace(userViewModel.Password))
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var result = await userManager.ResetPasswordAsync(user, token, userViewModel.Password);
                if (!result.Succeeded) throw new Exception("Houve um erro ao alterar a senha.");
            }

            await this.context.SaveChangesAsync();
            await AttachUserToRole(user.Id, userViewModel.RoleName);

            return userViewModel.UserId.Value;
        }
        public async Task<DTO.User.UserViewModel> GetUser(int id)
        {
            return await (from u in this.context.Users
                          join __ur in this.context.UserRoles on u.Id equals __ur.UserId into _ur
                          from ur in _ur.DefaultIfEmpty()
                          join __r in this.context.Roles on ur.RoleId equals __r.Id into _r
                          from r in _r.DefaultIfEmpty()
                          where u.Id == id && !u.IsDeleted
                          select new DTO.User.UserViewModel()
                          {
                              UserId = u.Id,
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                              Email = u.Email,
                              RoleName = (r == null ? "-" : r.Name),
                              RoleDescription = (r == null ? "-" : r.Description),
                              IsActive = u.IsActive,
                              TemporaryPassword = u.TemporaryPassword
                          }).AsNoTracking().SingleAsync();
        }
        public async Task<List<DTO.User.UserViewModel>> ListUsers()
        {
            return await ListUsersBase(null).ToListAsync();
        }
        public async Task<List<DTO.User.UserViewModel>> ListUsers(string q)
        {
            return await ListUsersBase(q).ToListAsync();
        }
        private IQueryable<DTO.User.UserViewModel> ListUsersBase(string q)
        {
            var users = (from u in this.context.Users
                         join __ur in this.context.UserRoles on u.Id equals __ur.UserId into _ur
                         from ur in _ur.DefaultIfEmpty()
                         join __r in this.context.Roles on ur.RoleId equals __r.Id into _r
                         from r in _r.DefaultIfEmpty()
                         where !u.IsDeleted
                         select new DTO.User.UserViewModel()
                         {
                             UserId = u.Id,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             Email = u.Email,
                             RoleName = (r == null ? "-" : r.Name),
                             RoleDescription = (r == null ? "-" : r.Description),
                             IsActive = u.IsActive,
                             TemporaryPassword = u.TemporaryPassword
                         }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(q))
            {
                foreach (var word in q.Split(' '))
                {
                    users = users.Where(x => (x.FirstName + x.LastName + x.Email).Contains(word));
                }
            }

            return users;
        }
        public async Task<bool> EmailExists(string email)
        {
            return await this.context.Users.AnyAsync(x => x.Email.ToUpper().Equals(email.ToUpper()) && !x.IsDeleted);
        }
        public async Task AttachUserToRole(int id, string roleName)
        {
            var user = await userManager.FindByIdAsync(Convert.ToString(id));
            var roles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, roles);
            await userManager.AddToRoleAsync(user, roleName);
            await userManager.UpdateAsync(user);
        }
        public async Task<bool> IsActive(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return user == null ? false : user.IsActive;
        }
        public async Task<bool> IsDeleted(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return user == null ? false : user.IsDeleted;
        }
        public async Task<Role> GetRoleByUserId(int userId)
        {
            return await (from u in this.context.Users
                          join ur in this.context.UserRoles on u.Id equals ur.UserId
                          join r in this.context.Roles on ur.RoleId equals r.Id
                          where u.Id == userId
                          select r).FirstOrDefaultAsync();
        }
        public async Task ClearTemporaryPassword(int userId)
        {
            var user = await this.context.Users.FindAsync(userId);

            user.TemporaryPassword = false;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ConfirmCreationToken(int userId, string token)
        {
            if (!await this.context.Users.AnyAsync(x => x.Id == userId && x.CreationToken == token)) return false;

            var user = await this.context.Users.SingleAsync(x => x.Id == userId);

            user.CreationToken = null;
            user.IsActive = true;

            await this.context.SaveChangesAsync();

            return true;
        }

    }
}