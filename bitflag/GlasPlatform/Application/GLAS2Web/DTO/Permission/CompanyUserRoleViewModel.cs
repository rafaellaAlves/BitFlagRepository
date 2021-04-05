using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Permission
{
    public class CompanyUserRoleViewModel
    {
        public int CompanyId { get; set; }
        public Company.CompanyViewModel Company { get; set; }

        public int UserId { get; set; }
        public User.UserModel User { get; set; }

        public int RoleId { get; set; }
        public Permission.CompanyUserRoleViewModel Role {  get; set; }
    }
}
