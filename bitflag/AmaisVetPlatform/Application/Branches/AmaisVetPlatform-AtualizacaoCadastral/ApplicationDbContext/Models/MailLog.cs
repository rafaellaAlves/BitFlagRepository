using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext.Models
{
    public partial class MailLog
    {
        public int MailLogId { get; set; }
        public string EmailTo { get; set; }
        public string EmailReply { get; set; }
        public string EmailBcc { get; set; }
        public string Subject { get; set; }
        public bool Sent { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
