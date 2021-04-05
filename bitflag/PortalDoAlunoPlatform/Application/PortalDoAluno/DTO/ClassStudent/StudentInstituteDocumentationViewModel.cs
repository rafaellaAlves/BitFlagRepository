using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ClassStudent
{
    public class StudentInstituteDocumentationViewModel
    {
        public bool? Contract { get; set; }
        public bool? MatriculationForm { get; set; }
        public bool? MatriculationRequirement { get; set; }
        public bool? Photos { get; set; }
        public bool? InternalRegulation { get; set; }
        public bool? ThesisAgreementTerm { get; set; }
        public bool? InternshipAgreementTerm { get; set; }
        public string InstituteDocumentationComments { get; set; }
    }
}
