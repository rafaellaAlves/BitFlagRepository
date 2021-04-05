using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Models
{
    public class Benefit
    {
        public int BenefitId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Discount { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
