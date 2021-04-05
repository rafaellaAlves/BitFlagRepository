using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Company
{
    public class CompanyUser
    {
        public int CompanyUserRoleId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool CanDelete { get; set; }

        public string CompanyRoleDescription { get; set; }
        public string UserRoleDescription { get; set; }
        public string UserRole { get; set; }
    }
}
