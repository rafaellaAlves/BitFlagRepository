using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientLicenseViewModel
    {
        public int? ClientLicenseId { get; set; }
        public int ClientId { get; set; }
        [Update]
        public string FileName { get; set; }
        [Update]
        public string GuidName { get; set; }
        [Update]
        public string MimeType { get; set; }
        [Update]
        public string Name { get; set; }
        [Update]
        public string Activity { get; set; }
        [Update]
        public string Issuer { get; set; }
        [Update]
        public DateTime? IssueDate { get; set; }
        public string _IssueDate { get => IssueDate.ToBrazilianDateFormat(); set => IssueDate = value.FromBrazilianDateFormat(); }
        [Update]
        public DateTime? DueDate { get; set; }
        public int? DueDateDays => !DueDate.HasValue ? null : (int?)(DueDate.Value - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).TotalDays;
        public string _DueDate { get => DueDate.ToBrazilianDateFormat(); set => DueDate = value.FromBrazilianDateFormat(); }
        [Update]
        public string License { get; set; }
        [Update]
        public int DaysToNotify { get; set; }
        [Update]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateFormated => CreatedDate.ToBrazilianDateFormat();
        public int CreatedBy { get; set; }
    }
}
