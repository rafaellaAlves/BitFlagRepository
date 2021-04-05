using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DTO.Client.Report
{
    public class ClientReportCollectionMapViewModel
    {
        public DateTime Month { get; set; }
        public string _Month => $"{new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(Month.Month)).Substring(0, 3)}/{Month:yyyy}";
        public int? ResidueFamilyId { get; set; }
        public string ResidueFamilyName { get; set; }
        public double Weight { get; set; }
        public string _Weight => Weight.ToWeightPtBr();
    }
}
