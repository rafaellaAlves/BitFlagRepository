﻿using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class AspNetRoleClaims
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
