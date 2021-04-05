using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class CertificatePlanViewModel
    {
        public int? PlanId { get; set; }
        public int? AssistanceId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public bool NameHasNumber { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public double MonthlyPrice { get; set; }
        public string _MonthlyPrice { get { return MonthlyPrice.ToString("#,#0.00", CultureInfo.GetCultureInfo("pt-BR")); } }
        public double AnnualPrice { get; set; }
        public string _AnnualPrice { get { return AnnualPrice.ToString("#,#0.00", CultureInfo.GetCultureInfo("pt-BR")); } }
        public int? CertificateId { get; set; }
        public double? AssitancePrice { get; set; }
        public string _AssitancePrice { get { return AssitancePrice.HasValue? AssitancePrice.Value.ToString("#,#0.00", CultureInfo.GetCultureInfo("pt-BR")) : "0,00"; } }

        public double PlanAssitancePrice { get { return MonthlyPrice + (AssitancePrice.HasValue ? AssitancePrice.Value : 0); } }
        public string _PlanAssitancePrice { get { return PlanAssitancePrice.ToString("#,#0.00", CultureInfo.GetCultureInfo("pt-BR")); } }
    }
}
