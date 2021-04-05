using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Shared
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
