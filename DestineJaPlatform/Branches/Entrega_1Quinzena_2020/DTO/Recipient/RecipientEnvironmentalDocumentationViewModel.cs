using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Recipient
{
    public class RecipientEnvironmentalDocumentationViewModel
    {
        public int? RecipientEnvironmentalDocumentationId { get; set; }
        public int RecipientId { get; set; }
        [Update]
        public string DocumentName { get; set; }
        [Update]
        public string Issuer { get; set; }
        [Update]
        public string ActivityName { get; set; }
        [Update]
        public DateTime? IssuerDate { get; set; }
        public string _IssuerDate { get => IssuerDate.ToBrazilianDateFormat(); set => IssuerDate = value.FromBrazilianDateFormatNullable(); }
        [Update]
        public DateTime? DueDate { get; set; }
        public string _DueDate { get => DueDate.ToBrazilianDateFormat(); set => DueDate = value.FromBrazilianDateFormatNullable(); }
        [Update]
        public string FileName { get; set; }
        [Update]
        public string GuidName { get; set; }
        [Update]
        public string MimeType { get; set; }
        [Update]
        public int DaysToNotify { get; set; }
        [Update]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
