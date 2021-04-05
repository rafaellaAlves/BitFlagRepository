using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
    }
}
