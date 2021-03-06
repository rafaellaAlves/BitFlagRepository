using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
        public string Iso3 { get; set; }
        public int? NumCode { get; set; }
        public int PhoneCode { get; set; }
    }
}
