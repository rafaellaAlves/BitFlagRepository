using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLawComment
    {
        public int CompanyLawCommentId { get; set; }
        public int CompanyLawId { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
