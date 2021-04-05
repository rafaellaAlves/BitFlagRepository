using System;
using System.Collections.Generic;

namespace DB
{
    public partial class FreezedFamily
    {
        public int FreezedFamilyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ClientId { get; set; }
        public bool? Accepted { get; set; }
        public int? AcceptedBy { get; set; }
        public DateTime? AcceptedDate { get; set; }
    }
}
