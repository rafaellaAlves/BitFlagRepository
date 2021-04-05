using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class TransporterEnvironmentalDocumentation
    {
        public int TransporterEnvironmentalDocumentationId { get; set; }
        public int TransporterId { get; set; }
        public string Name { get; set; }
        public string ActivityName { get; set; }
        public string Issuer { get; set; }
        public DateTime? IssuerDate { get; set; }
        public DateTime DueDate { get; set; }
        public string FileName { get; set; }
        public string GuidName { get; set; }
        public string MimeType { get; set; }
        public bool IsRSSFile { get; set; }
        public string License { get; set; }
        public int DaysToNotify { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }                                                       
}
