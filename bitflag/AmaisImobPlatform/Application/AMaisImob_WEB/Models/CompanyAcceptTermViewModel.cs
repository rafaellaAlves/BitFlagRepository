using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class CompanyAcceptTermViewModel
    {
        public int? CompanyId { get; set; }
        public string Token { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }

        public Models.CompanyViewModel Company { get; set; }
    }
}
