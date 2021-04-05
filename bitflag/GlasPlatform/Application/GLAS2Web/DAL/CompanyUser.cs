using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class CompanyUser
    {
        public int CompanyUserId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastHandler { get; set; }

        public CompanyUser CompanyUserNavigation { get; set; }
        public CompanyUser InverseCompanyUserNavigation { get; set; }
    }
}
