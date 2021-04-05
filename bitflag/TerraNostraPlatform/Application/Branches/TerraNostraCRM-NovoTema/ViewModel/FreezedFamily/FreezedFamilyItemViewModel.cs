using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.FreezedFamily
{
    public class FreezedFamilyItemViewModel
    {
        public int FreezedFamilyItemId { get; set; }
        public int FreezedFamilyId { get; set; }
        public int ClientApplicantId { get; set; }
        public int? FamilyMemberId { get; set; }
        public int FamilyStructureId { get; set; }
        public string FamilyStructureDescription { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? DeathDate { get; set; }
        public string _DeathDate { get { return DeathDate.ToDatePtBR(); } }
        public DateTime? BirthDate { get; set; }
        public string _BirthDate { get { return BirthDate.ToDatePtBR(); } }
        public DateTime? MarriageDate { get; set; }
        public string _MarriageDate { get { return MarriageDate.ToDatePtBR(); } }
        public string BirthPlace { get; set; }
        public string MarriagePlace { get; set; }
        public string DeathPlace { get; set; }
        public int FamilyMemberTypeId { get; set; }
        public string FamilyMemberTypeName { get; set; }
        public string ConsortFullName { get; set; }
    }
}
