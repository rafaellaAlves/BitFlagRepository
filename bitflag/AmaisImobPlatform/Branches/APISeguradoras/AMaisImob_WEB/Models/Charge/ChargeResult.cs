using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.Charge
{
    public class ChargeResult
    {
        public int ChargeId { get; set; }
        public CompanyViewModel RealEstate { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
