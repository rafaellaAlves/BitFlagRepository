using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DB.Models
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
        public int Nivel { get; set; }
    }
}
