using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class UserMedicGroup
    {
        public int UserMedicGroupId { get; set; }
        public int UserId { get; set; }
        public int MedicGroupId { get; set; }
    }
}
