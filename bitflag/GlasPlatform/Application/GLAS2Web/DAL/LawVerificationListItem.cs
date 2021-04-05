using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class LawVerificationListItem : Shared.BaseEntity
    {
        public int LawVerificationListItemId { get; set; }
        public int LawVerificationListId { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
    }
}
