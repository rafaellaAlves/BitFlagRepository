using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    public class ContactMedium
    {
        public int ContactMediumId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string ExternalCode { get; set; }
    }
}
