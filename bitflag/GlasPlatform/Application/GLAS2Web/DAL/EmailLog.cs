using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class EmailLog
    {
        public int EmailLogId { get; set; }
        public string Subject { get; set; }
        public string Emails { get; set; }
        public string Message { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }
        public bool Sended { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
