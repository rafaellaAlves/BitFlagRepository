using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace DTO.Company
{
    public class CompanyLawActionAttachmentViewModel
    {
        public int? CompanyLawActionAttachmentId { get; set; }
        public int CompanyLawActionId { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Int64 Length { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToBrazilianDateFormat(); } }
    }
}
