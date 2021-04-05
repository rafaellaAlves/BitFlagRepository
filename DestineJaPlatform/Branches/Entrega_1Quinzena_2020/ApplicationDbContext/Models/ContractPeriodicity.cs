using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ContractPeriodicity : Shared.ListBase
    {
        public int ContractPeriodicityId { get; set; }
        public int Order { get; set; }
    }
}
