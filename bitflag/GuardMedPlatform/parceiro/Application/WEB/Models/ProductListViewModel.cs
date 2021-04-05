using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class ProductListViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public string Description { get; set; }
        public int QtdCoverage { get; set; }
        public int QtdPlan { get; set; }
    }
}
