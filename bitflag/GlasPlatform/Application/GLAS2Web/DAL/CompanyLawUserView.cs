using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLawUserView
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int? CompanyLawUserId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public DateTime? LastView { get; set; }
    }
}
