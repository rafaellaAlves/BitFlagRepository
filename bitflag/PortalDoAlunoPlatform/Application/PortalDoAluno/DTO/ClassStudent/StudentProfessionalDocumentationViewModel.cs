using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ClassStudent
{
    public class StudentProfessionalDocumentationViewModel
    {
        public int? GraduationCertificate { get; set; }
        public int? RegionalCouncilDocument { get; set; }
        public int? LeadershipStatement { get; set; }
        public int? CurriculumSummary { get; set; }
        public int? CertifiedOfSpecialization { get; set; }
        public int? UtiTimeDeclaration { get; set; }
        public int? TeachingDeclaration { get; set; }
        public string ProfessionalDocumentationCommets { get; set; }
    }
}
