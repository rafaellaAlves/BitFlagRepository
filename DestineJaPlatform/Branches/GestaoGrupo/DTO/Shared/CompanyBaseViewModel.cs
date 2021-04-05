using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Shared
{
    public class CompanyBaseViewModel : AddressBaseViewModel
    {
        [Update]
        public string CompanyName { get; set; }
        [Update]
        public string TradeName { get; set; }
        public string _CNPJ { get; set; }
        [Update]
        public string CNPJ
        {
            get { return _CNPJ.NumbersOnly(); }
            set { _CNPJ = value.NumbersOnly(); }
        }
        [Update]
        public bool? IEExempted { get; set; }
        [Update]
        public string IE { get; set; }
        [Update]
        public string FullName { get; set; }
        [Update]
        public string NickName { get; set; }
        public string _CPF { get; set; }
        [Update]
        public string CPF
        {
            get { return _CPF.NumbersOnly(); }
            set { _CPF = value.NumbersOnly(); }
        }
        [Update]
        public string RG { get; set; }

        public bool IsCompany { get { return string.IsNullOrWhiteSpace(FullName); } }
        public string Name { get { return IsCompany? CompanyName : FullName ; } }
        public string AlternativeName { get { return IsCompany? TradeName : NickName; } }
        public string Document { get { return IsCompany? CNPJ : CPF; } }
        public string DocumentFormated => Document.CNPJOrCPFmask();
    }
}
