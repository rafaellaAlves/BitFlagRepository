using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Invoice
{
    public class FreezedFamilyInvoiceItemViewModel
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

        //checkboxes
        public bool BirthCertificateBRA { get; set; }
        public bool BirthCertificateITA { get; set; }
        public bool MarriageCertificateBRA { get; set; }
        public bool MarriageCertificateITA { get; set; }
        public bool DeathCertificateBRA { get; set; }
        public bool DeathCertificateITA { get; set; }
        public bool BirthCertificateTranslation { get; set; }
        public bool BirthCertificateHaiaHandout { get; set; }
        public bool MarriageCertificateTranslation { get; set; }
        public bool MarriageCertificateHaiaHandout { get; set; }
        public bool DeathCertificateTranslation { get; set; }
        public bool DeathCertificateHaiaHandout { get; set; }
        public bool CNN { get; set; }
        public string ConsortFullName { get; set; }
    }
}
