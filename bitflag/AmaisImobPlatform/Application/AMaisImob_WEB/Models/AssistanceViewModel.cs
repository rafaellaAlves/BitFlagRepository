using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class AssistanceViewModel
    {
        public int? AssistanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Value { get; set; }
        public string _Value
        {
            get
            {
                return Value.HasValue ? Value.Value.ToString("#,##0.00", CultureInfo.GetCultureInfo("pt-BR")) : null;
            }
            set
            {
                Value = double.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out double o) ? o : 0.0;
            }
        }
        public bool? IsDeleted { get; set; }
        public string ReportCode { get; set; }
    }
}
