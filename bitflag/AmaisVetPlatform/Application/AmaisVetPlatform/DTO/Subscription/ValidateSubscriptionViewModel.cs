using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Subscription
{
    public class ValidateSubscriptionViewModel
    {
        public string Reference { get; set; }
        public string FullName { get; set; }
        public string CRMV { get; set; }
        public DateTime BirthDate { get; set; }
        public string NumberCPF { get; set; }

    }
}
