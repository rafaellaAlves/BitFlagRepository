using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.User
{
    public class UserListViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDatePtBR(); } }
        public DateTime LastSaleDate { get; set; }
    }
}
