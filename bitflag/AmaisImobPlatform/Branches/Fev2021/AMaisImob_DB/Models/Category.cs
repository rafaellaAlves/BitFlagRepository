using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string ExternalCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}
