using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Mail
{
    public class EmailConfigurationViewModel
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Responsibles { get; set; }
    }
}
