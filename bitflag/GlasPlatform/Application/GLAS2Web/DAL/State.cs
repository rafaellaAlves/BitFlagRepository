using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public int CountryId { get; set; }
    }
}
