using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Company
{
    public class CompanyLawAttachmentListViewModel
    {
        public int CompanyID { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public int CompanyLawId { get; set; }
        public int AttachmentCount { get; set; }
    }
}
