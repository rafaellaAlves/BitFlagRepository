using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class EmailLog
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
