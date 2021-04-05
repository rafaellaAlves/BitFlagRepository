using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class EmailLog
    {
        public int EmailLogId { get; set; }
        public string EmailTo { get; set; }
        public string EmailReply { get; set; }
        public string EmailBcc { get; set; }
        public string Subject { get; set; }
        public bool Sended { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
