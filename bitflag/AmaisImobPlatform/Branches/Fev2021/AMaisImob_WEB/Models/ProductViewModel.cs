using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class ProductViewModel
    {
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public string Description { get; set; }
        public bool? Discontinue { get; set; }
        public int? ProductFamilyId { get; set; }
    }
}
