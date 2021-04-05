using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool Canceled { get; set; }
        public bool Suspended { get; set; }
        public string SuspendReason { get; set; }
        public string CancelReason { get; set; }
        public string EnableReason { get; set; }
        public int RouteTypeId { get; set; }
        public int RoutePeriodicityId { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
