using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models.Shared
{
    public class CompanyBase : AddressBase
    {
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string CNPJ { get; set; }
        public bool? IEExempted { get; set; }
        public string IE { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
    }
}
