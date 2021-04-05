using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLawActionComment : Shared.BaseEntity
    {
        public int CompanyLawActionCommentId { get; set; }
        public int CompanyLawActionId { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
    }
}
