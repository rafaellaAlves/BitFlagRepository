using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ClientLicense
    {
        public int ClientLicenseId { get; set; }
        public int ClientId { get; set; }
        public string FileName { get; set; }
        public string GuidName { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }
        public string Activity { get; set; }
        public string Issuer { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string License { get; set; }
        public int DaysToNotify { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
