using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ServiceStatus : Shared.ListBase
    {
        public int ServiceStatusId { get; set; }
        public int Order { get; set; }
    }
}
