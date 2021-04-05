using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public bool MobileNumberConfirmed { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastAccessDate { get; set; }
        public string Skype { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string CultureInfo { get; set; }
        //public int? LastHandler { get; set; }
        //public DateTime? ModifiedDate { get; set; }
    }
}
