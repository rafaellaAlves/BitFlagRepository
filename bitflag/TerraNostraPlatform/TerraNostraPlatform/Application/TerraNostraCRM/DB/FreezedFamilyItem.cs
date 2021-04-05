using System;
using System.Collections.Generic;

namespace DB
{
    public partial class FreezedFamilyItem
    {
        public int FreezedFamilyItemId { get; set; }
        public int FreezedFamilyId { get; set; }
        public int ClientApplicantId { get; set; }
        public int? FamilyMemberId { get; set; }
        public int FamilyStructureId { get; set; }
        public string FullName { get; set; }
        public string ConsortFullName { get; set; }
        public string Email { get; set; }
        public DateTime? DeathDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? MarriageDate { get; set; }
        public string BirthPlace { get; set; }
        public string MarriagePlace { get; set; }
        public string DeathPlace { get; set; }
    }
}
