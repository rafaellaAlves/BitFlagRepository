using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class Thesis
    {
        public int ThesisId { get; set; }
        public int ClassStudentId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Advisor { get; set; }
        public string Institution1 { get; set; }
        public string Institution2 { get; set; }
        public string DeliveryDate { get; set; }
        public string PresentationDate { get; set; }
        public string State { get; set; }
        public string MPTI { get; set; }
        public string Keyword { get; set; }
        public string FileName { get; set; }
        public string AuthorsComment { get; set; }
        public string JuryComment { get; set; }
        public string Concept { get; set; }
        public string ApprovalDate { get; set; }
        public int? ProtocolNumber { get; set; }
        public string ProtocolDate { get; set; }
    }
}
