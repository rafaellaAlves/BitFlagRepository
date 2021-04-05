using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace DTO.EmailLog
{
    public class EmailLogViewModel
    {
        public int EmailLogId { get; set; }
        public string Subject { get; set; }
        public string Emails { get; set; }
        public string Message { get; set; }
        public int? CompanyId { get; set; }
        public string Company { get; set; }
        public int? UserId { get; set; }
        public bool Sended { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate => CreatedDate.ToBrazilianDateTimeFormat();
    }
}
