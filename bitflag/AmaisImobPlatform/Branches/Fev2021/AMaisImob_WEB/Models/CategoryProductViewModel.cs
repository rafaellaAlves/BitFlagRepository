using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class CategoryProductViewModel
    {
        public int Id { get; set; }
        public int GuarantorProductId { get; set; }
        public int CategoryId { get; set; }
        public string GuarantorProductDescription { get; set; }
        public string CategoryProductDescription { get; set; }
    }
}
