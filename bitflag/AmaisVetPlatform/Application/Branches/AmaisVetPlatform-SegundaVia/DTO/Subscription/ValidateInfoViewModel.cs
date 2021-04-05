using DTO.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Subscription
{
    public class ValidateInfoViewModel
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string CpfClean { get { return Cpf.NumbersOnly(); } }
        public string Crmv { get; set; }
        public string Reference { get; set; }
    }
}
