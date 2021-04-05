using WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class ChargeViewModel
    {
        public int ChargeId { get; set; }
        public int RealEstateId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string _Price { get { return Price.ToPtBR(); } }
        public DateTime ReferenceDate { get; set; }
        public string _ReferenceDate { get { return ReferenceDate.ToMonthYearPtBR(); } }
        public DateTime DueDate { get; set; }
        public string _DueDate { get { return DueDate.ToDatePtBR(); } }
        public DateTime CreateDate { get; set; }
        public string _CreateDate { get { return DueDate.ToDatePtBR(); } }
        public string IUGUUrl { get; set; }
        public bool IsPayed { get; set; }
        public string IUGUDescription { get; set; }
        public string IUGUnotification_url { get; set; }
        public string PayedToken { get; set; }
        public string IUGUInvoiceId { get; set; }
        public DateTime? PayedDate { get; set; }
        public int? PayedBy { get; set; }

        public string CompanyName { get; set; } //dado pego a partir do meotdo GetCharges
    }
}
