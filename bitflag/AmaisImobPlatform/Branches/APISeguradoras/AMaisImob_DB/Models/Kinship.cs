using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class Kinship
    {
        public int KinshipId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public int? Order { get; set; }
    }
}
