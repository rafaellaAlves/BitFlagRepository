using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientLicenseConditioningEmailViewModel
    {
        public ClientLicenseConditioningViewModel Conditioning { get; set; }
        public ClientViewModel Client { get; set; }

        public string ClientLicenseEmail { get; set; }
        public string ClientLicenseName { get; set; }
        public string ClientLicenseConditioningPeriodicityName { get; set; }
        public DateTime EndDate { get; set; }
        public string EndDateFormated => EndDate.ToBrazilianDateFormat();
    }
}
