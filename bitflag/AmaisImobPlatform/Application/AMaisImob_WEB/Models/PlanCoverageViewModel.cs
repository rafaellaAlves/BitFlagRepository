using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using System.Globalization;

namespace AMaisImob_WEB.Models
{
    public class PlanCoverageViewModel
    {
        public int? PlanCoverageId { get; set; }
        public int? PlanId { get; set; }
        public int? ProductCoverageId { get; set; }
        public bool Used { get; set; }
        public double? Garantia { get; set; }
        public string _Garantia
        {
            get
            {
                return Garantia.HasValue ? Garantia.Value.ToString("#,###,##0.00", CultureInfo.GetCultureInfo("pt-BR")) : null;
            }
            set
            {
                Garantia = double.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out double o) ? o : 0.0;
            }
        }
    }
}
