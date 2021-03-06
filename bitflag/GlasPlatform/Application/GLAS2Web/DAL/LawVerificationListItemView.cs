using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class LawVerificationListItemView
    {
        [Key]
        public int? LawVerificationListItemId { get; set; }
        public int LawVerificationListId { get; set; }
        public string Reference { get; set; }
        public double? ReferneceOrdering { get; set; }
        public string Description { get; set; }
    }
}
