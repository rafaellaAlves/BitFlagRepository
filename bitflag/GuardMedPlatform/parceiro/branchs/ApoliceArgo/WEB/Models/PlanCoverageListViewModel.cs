using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class PlanCoverageListViewModel
    {
        public int? ProductCoverageId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double? Taxes { get; set; }
        public string _Taxes
        {
            get
            {
                return Taxes.HasValue ? Taxes.Value.ToString("0.00000", CultureInfo.GetCultureInfo("pt-BR")) : null;
            }
            set
            {
                Taxes = double.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out double o) ? o : 0.0;
            }
        }
        public double? Minimum { get; set; }
        public string _Minimum
        {
            get
            {
                return Minimum.HasValue ? Minimum.Value.ToString("#,##0.00", CultureInfo.GetCultureInfo("pt-BR")) : null;
            }
            set
            {
                Minimum = double.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out double o) ? o : 0.0;
            }
        }
        public double? Maximum { get; set; }
        public string _Maximum
        {
            get
            {
                return Maximum.HasValue ? Maximum.Value.ToString("#,##0.00", CultureInfo.GetCultureInfo("pt-BR")) : null;
            }
            set
            {
                Maximum = double.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out double o) ? o : 0.0;
            }
        }
        public double? RealMinimum { get; set; }
        public string _RealMinimum
        {
            get
            {
                return RealMinimum.HasValue ? RealMinimum.Value.ToString("#,##0.00", CultureInfo.GetCultureInfo("pt-BR")) : null;
            }
            set
            {
                RealMinimum = double.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out double o) ? o : 0.0;
            }
        }
        public double? RealMaximum { get; set; }
        public string _RealMaximum
        {
            get
            {
                return RealMaximum.HasValue ? RealMaximum.Value.ToString("#,##0.00", CultureInfo.GetCultureInfo("pt-BR")) : null;
            }
            set
            {
                RealMaximum = double.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out double o) ? o : 0.0;
            }
        }
        public bool IsBasic { get; set; }
        public double? BasicLimit { get; set; }
        public string _BasicLimit
        {
            get
            {
                return BasicLimit.HasValue ? BasicLimit.Value.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR")) : null;
            }
            set
            {
                BasicLimit = double.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out double o) ? o : 0.0;
            }
        }
        public bool IsOptional { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool? Used { get; set; }
        public double? Garantia { get; set; }
        public string _Garantia
        {
            get
            {
                return Garantia.HasValue ? Garantia.Value.ToString("#,##0.00", CultureInfo.GetCultureInfo("pt-BR")) : null;
            }
            set
            {
                Garantia = double.TryParse(value, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out double o) ? o : 0.0;
            }
        }
        public string Franquias { get; set; }
    }
}
