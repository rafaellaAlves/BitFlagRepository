using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Benefits
{
    public class BenefitsViewModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Discount { get; set; }
        public string Link { get; set; }
    }
}
