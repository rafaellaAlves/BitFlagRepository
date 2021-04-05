using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.Charge
{
    public class CompanyChargeViewModel
    {
        public int? ChargeId { get; set; }
        public bool IsLocked { get; set; }
        public bool AllFilesUploaded { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public string ReferenceDateFormatedPtBR => ReferenceDate.ToDatePtBR();
        public string ReferenceDateFormated => !ReferenceDate.HasValue? null : $"{new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(ReferenceDate.Value.Month))} - {ReferenceDate.Value.Year}";
        public string ReferenceDateISOString => !ReferenceDate.HasValue ? "" : ReferenceDate.Value.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
        public string IUGUUrl { get; set; }
        public string IUGUInvoiceId { get; set; }

        public int RealEstateAgencyId { get; set; }
        public string ParentCompanyName { get; set; }
        public string ParentCompanyTradeName { get; set; }

        public int RealEstateId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTradeName { get; set; }

        public DateTime? CreateDate { get; set; }
        public string CreateDateFormated => CreateDate.ToDateTimePtBR();
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceDateFormated => InvoiceDate.ToDateTimePtBR();
        public DateTime? PayedDate { get; set; }
        public string PayedDateFormated => PayedDate.ToDateTimePtBR();
        public DateTime? DueDate { get; set; }
        public string DueDateFormated => DueDate.ToDatePtBR();
        public bool CompanyChargeContractualGuarantee { get; set; }
    }
}
