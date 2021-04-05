using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.IUGU
{
    public class InvoiceStatusChange
    {
        public string id { get; set; }
        public string account_id { get; set; }
        public string status { get; set; }
        public string subscription_id { get; set; }
    }
}
