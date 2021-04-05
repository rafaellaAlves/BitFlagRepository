using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.User
{
    public class UserModel
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value.NumbersOnly(); }
        }
        private string mobileNumber;
        public string MobileNumber
        {
            get { return this.mobileNumber; }
            set { this.mobileNumber = value.NumbersOnly(); }
        }
        public bool IsActive { get; set; }

        public List<int> AddToCompanyId { get; set; }
        public string MainRole { get; set; }
        public string CompanyRole { get; set; }
        public string Skype { get; set; }
        public DateTime? LastAccessDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate?.ToString("dd/MM/yyyy HH:mm:ss"); } }
        public int? CreatedBy { get; set; }
        public string CultureInfo { get; set; }
    }
}
