using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ClientContactType
    {
        public int ClientContactTypeId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
    }
}
