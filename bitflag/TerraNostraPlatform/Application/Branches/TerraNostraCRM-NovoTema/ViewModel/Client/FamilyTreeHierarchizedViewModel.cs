using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class FamilyTreeHierarchizedViewModel
    {
        public int FamilyTreeId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public int? MarriedWith { get; set; }
        public bool IsClient { get; set; }
        public FamilyTreeHierarchizedViewModel Spouse { get; set; }
        public List<FamilyTreeHierarchizedViewModel> Childrens { get; set; }

        public FamilyTreeHierarchizedViewModel()
        {
            Childrens = new List<FamilyTreeHierarchizedViewModel>();
        }
    }
}
