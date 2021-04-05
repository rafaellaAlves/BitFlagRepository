using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;

namespace WEB.Models
{
    public class ProductPlanManageViewModel
    {
        public Product Product { get; set; }
        public List<int> PlanIds { get; set; }
    }
}
