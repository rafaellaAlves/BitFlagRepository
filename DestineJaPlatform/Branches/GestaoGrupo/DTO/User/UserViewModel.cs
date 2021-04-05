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
        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsActive { get; set; }
        public bool TemporaryPassword { get; set; }
        public DateTime? NewUserSendedEmailDate { get; set; }
        public string CreationToken { get; set; }
        public string IsActiveText
        {
            get
            {
                return IsActive ? "Sim" : "Não";
            }
        }
    }
}
