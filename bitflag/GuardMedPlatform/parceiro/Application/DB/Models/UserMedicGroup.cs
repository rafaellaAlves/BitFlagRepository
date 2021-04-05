using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class UserMedicGroup
    {
        public int UserMedicGroupId { get; set; }
        public int UserId { get; set; }
        public int MedicGroupId { get; set; }
    }
}
