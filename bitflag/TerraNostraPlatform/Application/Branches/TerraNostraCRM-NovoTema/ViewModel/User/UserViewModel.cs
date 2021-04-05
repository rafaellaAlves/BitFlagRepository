using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.User
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
        public string RoleNormalizedName { get; set; }
        public int? LastHandler { get; set; }
        public string CPF { get; set; }
        public string Cpf
        {
            get { return this.CPF; }
            set { this.CPF = value.NumbersOnly(); }
        }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDatePtBR(); } }
        public DateTime? DeletedDate { get; set; }
        public string _DeletedDate { get { return DeletedDate.ToDatePtBR(); } }
        public bool SalesmanAvailable { get; set; }
        public DateTime? LastSaleDate { get; set; }
    }
}
