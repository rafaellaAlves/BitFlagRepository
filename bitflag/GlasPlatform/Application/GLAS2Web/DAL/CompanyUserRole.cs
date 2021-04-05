using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyUserRole
    {
        public int CompanyUserRoleId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
