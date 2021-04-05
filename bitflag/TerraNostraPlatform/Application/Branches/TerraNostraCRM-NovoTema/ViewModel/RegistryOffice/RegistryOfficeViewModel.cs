using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.RegistryOffice
{
    public class RegistryOfficeViewModel
    {
        public int? RegistryOfficeId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int LastHandler { get; set; }
    }
}
