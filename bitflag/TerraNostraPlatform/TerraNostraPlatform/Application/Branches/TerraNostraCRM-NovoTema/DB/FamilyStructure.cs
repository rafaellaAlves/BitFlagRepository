using System;
using System.Collections.Generic;

namespace DB
{
    public partial class FamilyStructure
    {
        public int FamilyStructureId { get; set; }
        public int FamilyMemberTypeId { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
    }
}
