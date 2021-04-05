using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Account
{
    public class NewPasswordViewModel
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
