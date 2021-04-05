using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Shared
{
    public class AddressBaseViewModel
    {
        public string _CEP { get; set; }
        [Update]
        public string CEP
        {
            get { return _CEP.NumbersOnly(); }
            set { _CEP = value.NumbersOnly(); }
        }
        [Update]
        public string Address { get; set; }
        [Update]
        public string Number { get; set; }
        [Update]
        public string Complement { get; set; }
        [Update]
        public string Neighborhood { get; set; }
        [Update]
        public string State { get; set; }
        [Update]
        public string City { get; set; }

        public string FormId { get; set; }
    }
}
