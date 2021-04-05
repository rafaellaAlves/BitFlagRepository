using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class LawChange
    {
        public int LawChangeId { get; set; }
        public int LawId { get; set; }
        public int ChangedLawId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
