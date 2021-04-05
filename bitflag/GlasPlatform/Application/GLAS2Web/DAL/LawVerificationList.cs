using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class LawVerificationList : Shared.BaseEntity
    {
        public int LawVerificationListId { get; set; }
        public int LawId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
