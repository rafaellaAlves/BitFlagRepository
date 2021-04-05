using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Subscription
{
    public class IndicationVetViewModel
    {
        public string[] FullNameVet { get; set; }

        public string[] CellPhoneVet { get; set; }
        public Account.CompanyViewModel Account { get; set; }
    }
}
