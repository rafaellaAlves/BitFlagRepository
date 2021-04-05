using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public bool MobileNumberConfirmed { get; set; }
        public string Skype { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? BornDate { get; set; }
    }
}
