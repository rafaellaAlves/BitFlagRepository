using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.Charge
{
    public class ChargeAnalyseViewModel
    {
        public int? ChargeId { get; set; }
        public DateTime ReferenceDate { get; set; }
        public string ReferenceDateFormated => $"{new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(ReferenceDate.Month)).ToUpper()} - {ReferenceDate.Year}";
        public string ReferenceDateFormatedPtBR => ReferenceDate.ToDatePtBR();
        public string ReferenceDateFormatedIsoString => ReferenceDate.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");

        public List<ChargePriceItem> Items { get; set; }
        public CompanyViewModel Company { get; set; }

        public ChargeAnalyseViewModel(List<ChargePriceItem> items, CompanyViewModel company, DateTime referenceDate, int? chargeId)
        {
            Items = items;
            ReferenceDate = referenceDate;
            Company = company;
            ChargeId = chargeId;
        }
    }
}
