using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Utils;

namespace WEB.Models
{
    public class UserViewModel
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        public int LastHandler { get; set; }
        public DateTime? BornDate { get; set; }
        public string _BornDate { get { return BornDate.ToDatePtBR(); } set { BornDate = value.FromDatePtBR(); } }
    }
}
