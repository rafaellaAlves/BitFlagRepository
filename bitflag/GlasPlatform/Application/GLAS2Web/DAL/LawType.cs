using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial class LawType
    {
        public int LawTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
