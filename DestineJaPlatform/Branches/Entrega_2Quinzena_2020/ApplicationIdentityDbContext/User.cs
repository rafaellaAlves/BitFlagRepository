using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetIdentityDbContext
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreationToken { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool TemporaryPassword { get; set; }
    }
}
