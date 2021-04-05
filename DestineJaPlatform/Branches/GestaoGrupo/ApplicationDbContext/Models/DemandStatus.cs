using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandStatus : Shared.ListBase
    {
        public int DemandStatusId { get; set; }
        public int Order { get; set; }
    }
}
