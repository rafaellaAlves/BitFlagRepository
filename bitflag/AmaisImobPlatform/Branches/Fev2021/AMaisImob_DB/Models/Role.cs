using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
