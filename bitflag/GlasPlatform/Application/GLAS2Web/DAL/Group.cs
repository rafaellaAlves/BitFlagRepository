using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}
