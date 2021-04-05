using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class CompanyDocuSignViewModel
    {
        public int? CompanyDocuSignId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTradeName { get; set; }
        public DateTime ReferenceDate { get; set; }
        public string ReferenceDateFormated => $"{new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(ReferenceDate.Month)).ToUpper()} - {ReferenceDate.Year}" ;
        public string ReferenceDateISO => ReferenceDate.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
        public int Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public double Price { get; set; }
        public string PriceFormated => Price.ToPtBR();
        public double TotalPrice { get; set; }
        public string TotalFormated => TotalPrice.ToPtBR();
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public string Bonus { get; set; }
    }
}
