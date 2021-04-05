using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class CompanyGroup
    {
        public int CompanyGroupId { get; set; }
        public int CompanyId { get; set; }
        public int? GroupId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastHandler { get; set; }
    }
}
