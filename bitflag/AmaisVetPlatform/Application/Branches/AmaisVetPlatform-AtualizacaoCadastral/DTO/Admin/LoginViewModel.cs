﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Admin
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string UserEmail { get; set; }

        public string Password { get; set; }

        public int Type { get; set; }

    }
}
