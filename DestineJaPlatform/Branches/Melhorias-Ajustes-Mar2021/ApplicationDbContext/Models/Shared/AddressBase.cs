using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models.Shared
{
    public class AddressBase
    {
        public string CEP { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
