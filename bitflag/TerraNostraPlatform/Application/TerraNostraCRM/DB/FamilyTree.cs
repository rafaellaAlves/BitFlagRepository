using System;
using System.Collections.Generic;

namespace DB
{
    public partial class FamilyTree
    {
        public int FamilyTreeId { get; set; }
        public int ClientId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? LastHandler { get; set; }
        public int? MarriedWith { get; set; }
        public bool IsClient { get; set; }
        public string MarriedWithName { get; set; }
        public string MarriedWithTitle { get; set; }
        public int? SecondParentId { get; set; }
    }
}
