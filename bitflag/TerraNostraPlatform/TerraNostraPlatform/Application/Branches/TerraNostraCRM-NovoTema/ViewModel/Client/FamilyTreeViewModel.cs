using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class FamilyTreeViewModel
    {
        public int? FamilyTreeId { get; set; }
        public int? id { get { return FamilyTreeId; } set { FamilyTreeId = value; } }
        public int ClientId { get; set; }
        public int? ParentId { get; set; }
        public int? pid { get { return ParentId; } set { ParentId = value; } }
        public string Name { get; set; }
        public string Title { get; set; }
        public string[] tags
        {
            get
            {
                var tags = new List<string>();

                if (!string.IsNullOrWhiteSpace(MarriedWithName))        //selecionar template do node
                    tags.Add(IsClient ? "clientMarried" : "married");
                else
                    tags.Add(IsClient ? "client" : "normal");

                tags.Add(MarriedWith?.ToString()); //usado para formar grupos
                tags.Add(FamilyTreeId?.ToString());

                return tags.ToArray();
            }
        }
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
        public string[] spids
        {
            get
            {
                if (SecondParentId.HasValue) return new string[] { SecondParentId.ToString() };
                return new string[] { };
            }
        }

    }
}
