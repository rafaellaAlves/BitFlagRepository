using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Family
{
    public class FamilyMemberViewModel
    {
        public int ClientId { get; set; }
        public int ClientApplicantId { get; set; }
        public int FamilyStructureId { get; set; }
        public string FullName { get; set; }
        public string ConsortFullName { get; set; }
        public DateTime? DeathDate { get; set; }
        public string _DeathDate
        {
            get
            {
                return this.DeathDate.ToDatePtBR();
            }
            set
            {
                this.DeathDate = value.FromDatePtBR();
            }
        }
        public DateTime? BirthDate { get; set; }
        public string _BirthDate
        {
            get
            {
                return this.BirthDate.ToDatePtBR();
            }
            set
            {
                this.BirthDate = value.FromDatePtBR();
            }
        }
        public DateTime? MarriageDate { get; set; }
        public string _MarriageDate
        {
            get
            {
                return this.MarriageDate.ToDatePtBR();
            }
            set
            {
                this.MarriageDate = value.FromDatePtBR();
            }
        }
        public string DeathPlace { get; set; }
        public string BirthPlace { get; set; }
        public string MarriagePlace { get; set; }
        public bool HasAnyInfo
        {
            get
            {
                return !string.IsNullOrWhiteSpace(FullName) ||
                    !string.IsNullOrWhiteSpace(DeathPlace) ||
                    !string.IsNullOrWhiteSpace(BirthPlace) ||
                    !string.IsNullOrWhiteSpace(MarriagePlace) ||
                    DeathDate.HasValue ||
                    MarriageDate.HasValue ||
                    BirthDate.HasValue;
            }
        }

        public string Email { get; set; } //utilizado para o salvamento apenas do requerente
    }
}
