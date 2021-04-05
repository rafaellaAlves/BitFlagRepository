using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ClassStudent
{
    public class StudentThesisViewModel
    {
        public int ClassStudentId { get; set; }
        public string Title { get; set; }
        public string ApprovalDate { get; set; }
        public string PresentationDate { get; set; }
        public string Advisor { get; set; }
        public string Concept { get; set; }
        public int? ProtocolNumber { get; set; }
        public string ProtocolDate { get; set; }
        public string FileName { get; set; }
        public bool HasFile => !string.IsNullOrWhiteSpace(FileName);
    }
}
