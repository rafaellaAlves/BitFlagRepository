using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLawActionAttachment : Shared.BaseEntity
    {
        public int CompanyLawActionAttachmentId { get; set; }
        public int CompanyLawActionId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Int64 Length { get; set; }
        public string Name { get; set; }
    }
}
