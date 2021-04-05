using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
