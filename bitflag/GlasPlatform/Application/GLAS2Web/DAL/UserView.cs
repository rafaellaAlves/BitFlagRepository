using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UserView
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string Roles { get; set; }
        public string MainRole { get; set; }
    }
}
