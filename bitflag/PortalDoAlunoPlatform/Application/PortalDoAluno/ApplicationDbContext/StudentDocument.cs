using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class StudentDocument
    {
        public int StudentDocumentId { get; set; }
        public int ClassStudentId { get; set; }
        public bool InternshipDocument1 { get; set; }
        public bool InternshipDocument2 { get; set; }
        public string InternshipComments { get; set; }
        public bool? Contract { get; set; }
        public bool? MatriculationForm { get; set; }
        public bool? MatriculationRequirement { get; set; }
        public bool? Photos { get; set; }
        public bool? InternalRegulation { get; set; }
        public bool? ThesisAgreementTerm { get; set; }
        public bool? InternshipAgreementTerm { get; set; }
        public string InstituteDocumentationComments { get; set; }
        public int? GraduationCertificate { get; set; }
        public int? RegionalCouncilDocument { get; set; }
        public int? LeadershipStatement { get; set; }
        public int? CurriculumSummary { get; set; }
        public int? CertifiedOfSpecialization { get; set; }
        public int? UtiTimeDeclaration { get; set; }
        public int? TeachingDeclaration { get; set; }
        public string ProfessionalDocumentationCommets { get; set; }
        public bool RegularlyMatriculatedDeclaration { get; set; }
        public string RegularlyMatriculatedDate { get; set; }
        public bool CertifiedOfMPTI { get; set; }
        public string CertifiedOfMPTIDate { get; set; }
        public bool DocumentOfCNI { get; set; }
        public string DocumentOfCNIDate { get; set; }
        public string DocumentsSentComments { get; set; }
        public string GeneralComments { get; set; }
    }
}
