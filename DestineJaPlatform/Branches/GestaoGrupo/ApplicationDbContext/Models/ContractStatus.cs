using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ContractStatus : Shared.ListBase
    {
        public int ContractStatusId { get; set; }
        public int Order { get; set; }
    }
}
