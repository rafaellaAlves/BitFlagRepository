using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
