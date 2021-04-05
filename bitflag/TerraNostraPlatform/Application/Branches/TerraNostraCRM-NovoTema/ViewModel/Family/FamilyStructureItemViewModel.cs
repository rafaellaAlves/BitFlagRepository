using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Family
{
    public class FamilyStructureItemViewModel
    {
        public int FamilyStructureId { get; set; }
        public int ClientApplicantId { get; set; }
        public int ClientId { get; set; }
        public int? FamilyMemberId { get; set; }
        public int FamilyMemberTypeId { get; set; }
        public string FamilyMemberTypeName { get; set; }
        public string FamilyMemberTypeDescription { get; set; }
        public Family.FamilyMemberViewModel FamilyMemberViewModel { get; set; }
        public List<FamilyStructureItemViewModel> Items { get; set; }
        public FamilyStructureItemViewModel()
        {
            this.Items = new List<FamilyStructureItemViewModel>();
        }
    }
}
