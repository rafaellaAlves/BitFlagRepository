using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class RoutePeriodicity : Shared.ListBase
    {
        public int RoutePeriodicityId { get; set; }
        public int Order { get; set; }
    }
}
