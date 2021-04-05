using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class LawPotentialityType
    {
        public int LawPotentialityTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExternalCode { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}
