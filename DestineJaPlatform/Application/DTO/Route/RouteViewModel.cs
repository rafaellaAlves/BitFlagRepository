using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Route
{
    public class RouteViewModel
    {
        public int? RouteId { get; set; }
        [Update]
        public string Name { get; set; }
        [Update]
        public string Observation { get; set; }
        [Update]
        public int RouteTypeId { get; set; }
        [Update]
        public int RoutePeriodicityId { get; set; }
        public bool Canceled { get; set; }
        public bool Suspended { get; set; }
        public string SuspendReason { get; set; }
        public string CancelReason { get; set; }
        public string EnableReason { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
