using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DTO.Client.Report
{
    public class ClientReportCollectionYearMapViewModel
    {
        public DateTime Date { get; set; }
        public string _Date => new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(Date.Month));
        public double Weight { get; set; }
        public string _Weight => Weight.ToWeightPtBr();
    }
}
