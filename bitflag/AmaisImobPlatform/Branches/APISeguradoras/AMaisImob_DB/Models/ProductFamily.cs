using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class ProductFamily
    {
        public int ProductFamilyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
