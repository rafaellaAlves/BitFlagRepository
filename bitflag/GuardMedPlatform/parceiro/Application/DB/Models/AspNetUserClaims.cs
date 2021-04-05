using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class AspNetUserClaims
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
