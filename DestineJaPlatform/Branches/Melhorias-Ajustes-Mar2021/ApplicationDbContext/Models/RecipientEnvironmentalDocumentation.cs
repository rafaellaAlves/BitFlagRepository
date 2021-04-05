using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbContext.Models
{
   public class RecipientEnvironmentalDocumentation
    {
        [Key]
        public int RecipientEnvironmentalDocumentationId { get; set; }
        public int RecipientId { get; set; }
        public string DocumentName { get; set; }
        public string Issuer { get; set; }
        public string ActivityName { get; set; }
        public DateTime? IssuerDate { get; set; }
        public DateTime DueDate { get; set; }
        public string FileName { get; set; }
        public string GuidName { get; set; }
        public string MimeType { get; set; }
        public int DaysToNotify { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
