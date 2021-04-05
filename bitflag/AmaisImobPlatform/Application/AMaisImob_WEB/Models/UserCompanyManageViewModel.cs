using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class UserCompanyManageViewModel
    {
        public CompanyViewModel Company { get; set; }
        public List<int> UserIds { get; set; }
    }
}
