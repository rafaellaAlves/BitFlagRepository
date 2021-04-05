using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class UserCompany
    {
        public int UserCompanyId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }
}
