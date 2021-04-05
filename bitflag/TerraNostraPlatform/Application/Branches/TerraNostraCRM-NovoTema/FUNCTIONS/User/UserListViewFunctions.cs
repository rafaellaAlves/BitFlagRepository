using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using TerraNostraIdentityDbContext;

namespace FUNCTIONS.User
{
    public class UserListViewFunctions : FUNCTIONS.BasicIdentityFunctions<TerraNostraIdentityDbContext.UserListView, DTO.User.UserListViewModel>
    {
        public UserListViewFunctions(TerraNostraIdentityDbContext.ApplicationDbContext context)
            : base(context, "UserId")
        {
        }

        public override int Create(DTO.User.UserListViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<DTO.User.UserListViewModel> GetDataViewModel(IEnumerable<UserListView> data)
        {
            return (from y in data
                    select new DTO.User.UserListViewModel()
                    {
                        UserId = y.UserId,
                        FirstName = y.FirstName,
                        LastName = y.LastName,
                        Email = y.Email,
                        PhoneNumber = y.PhoneNumber,
                        IsActive = y.IsActive,
                        Role = y.Role,
                        RoleId = y.RoleId,
                        CreatedDate = y.CreatedDate,
                        FullName = y.FullName,
                        IsDeleted = y.IsDeleted
                    }).ToList();
        }

        public override DTO.User.UserListViewModel GetDataViewModel(UserListView data)
        {
            return new DTO.User.UserListViewModel()
            {
                UserId = data.UserId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                IsActive = data.IsActive,
                Role = data.Role,
                RoleId = data.RoleId,
                CreatedDate = data.CreatedDate,
                FullName = data.FullName,
                IsDeleted = data.IsDeleted
            };
        }

        public override void Update(DTO.User.UserListViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.UserListView;
        }
    }
}
