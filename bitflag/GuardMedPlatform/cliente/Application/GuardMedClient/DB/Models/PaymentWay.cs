using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class PaymentWay
    {
        public int PaymentWayId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string ExternalCode { get; set; }
    }
}
