using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.Charge
{
    public class FinancialListViewModel
    {
        public List<CompanyChargeViewModel> Items { get; set; }
        /// <summary>
        /// Valor pego do filtro
        /// </summary>
        public bool? ChargeContractualGuarantee { get; set; }
        /// <summary>
        /// Valor pego do filtro
        /// </summary>
        public DateTime ReferenceDate { get; set; }
        public string ReferenceDateFormatedPtBR => ReferenceDate.ToDatePtBR();
        public string ReferenceDateFormated => $"{new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(ReferenceDate.Month))} - {ReferenceDate.Year}";
        public string ReferenceDateISOString => ReferenceDate.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
        /// <summary>
        /// True quando a tela é usada para extrato
        /// </summary>
        public bool Extract { get; set; }

        public FinancialListViewModel(List<CompanyChargeViewModel>  items, DateTime referenceDate, bool? chargeContractualGuarantee, bool extract = false)
        {
            Items = items;
            ReferenceDate = referenceDate;
            ChargeContractualGuarantee = chargeContractualGuarantee;
            Extract = extract;
        }
    }
}
