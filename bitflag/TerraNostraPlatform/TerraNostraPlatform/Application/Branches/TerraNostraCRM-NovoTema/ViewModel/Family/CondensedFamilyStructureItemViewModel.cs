using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Family
{
    public class CondensedFamilyStructureItemViewModel
    {
        public int FamilyMemberId { get; set; }
        public int FamilyMemberTypeId { get; set; }
        public int FamilyStructureId { get; set; }
        public int ClientApplicantId { get; set; }
        public string Kinship { get; set; }
        public string FullName { get; set; }
        public string ConsortFullName { get; set; }
        public string Email { get; set; }
        public string BirthPlace { get; set; }
        public string MarriagePlace { get; set; }
        public string DeathPlace { get; set; }
        public DateTime? BirthDate { get; set; }
        public string _BirthDate { get { return BirthDate.ToDatePtBR(); } }
        public DateTime? MarriageDate { get; set; }
        public string _MarriageDate { get { return MarriageDate.ToDatePtBR(); } }
        public DateTime? DeathDate { get; set; }
        public string _DeathDate { get { return DeathDate.ToDatePtBR(); } }
    } 
}
