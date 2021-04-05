using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.Charge
{
    public class FinancialFilterViewModel
    {
        public int? RealEstateAgencyId { get; set; }
        public int? RealEstateId { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? ChargeContractualGuarantee { get; set; }
    }
}
