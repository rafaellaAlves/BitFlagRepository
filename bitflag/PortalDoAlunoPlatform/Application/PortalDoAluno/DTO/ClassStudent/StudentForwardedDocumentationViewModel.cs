using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ClassStudent
{
    public class StudentForwardedDocumentationViewModel
    {
        public bool RegularlyMatriculatedDeclaration { get; set; }
        public string RegularlyMatriculatedDate { get; set; }
        public bool CertifiedOfMPTI { get; set; }
        public string CertifiedOfMPTIDate { get; set; }
        public bool DocumentOfCNI { get; set; }
        public string DocumentOfCNIDate { get; set; }
        public string DocumentsSentComments { get; set; }
    }
}
