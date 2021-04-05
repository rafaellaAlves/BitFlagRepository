using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Company
{
    public class CompanyLawCommentViewModel
    {
        public int? CompanyLawCommentId { get; set; }
        public int CompanyLawId { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public string CreatedDate { get; set; }
        public string Name { get; set; }
    }
}