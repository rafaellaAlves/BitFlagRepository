using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
