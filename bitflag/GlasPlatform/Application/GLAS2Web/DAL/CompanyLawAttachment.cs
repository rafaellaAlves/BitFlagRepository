using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLawAttachment : Shared.BaseEntity
    {
        public int CompanyLawAttachmentId { get; set; }
        public int CompanyLawId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Int64 Length { get; set; }
        public string Name { get; set; }
    }
}
