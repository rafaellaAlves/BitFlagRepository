using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class CategoryProduct
    {
        public int Id { get; set; }
        public int GuarantorProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
