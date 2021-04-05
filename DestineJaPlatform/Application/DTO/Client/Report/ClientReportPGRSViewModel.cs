using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DTO.Client.Report
{
    public class ClientReportPGRSViewModel
    {
        public DateTime Month { get; set; }
        public string _Month => $"{new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(Month.Month)).Substring(0, 3)}/{Month:yyyy}";
        public int ResidueId { get; set; }
        public string ResidueName { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public string UnitOfMeasurementName { get; set; }
        public string UnitOfMeasurementInitials { get; set; }
        public string IBAMACode { get; set; }
        public int ResidueFamilyId { get; set; }
        public string ResidueFamilyName { get; set; }
        public string ResidueFamilyClassName { get; set; }
        public string PackingName { get; set; }
        public string ResidueDestinationTypeName { get; set; }
        public string RecipientName { get; set; }
        public double Weight { get; set; }
        public string _Weight => Weight.ToWeightPtBr();
    }
}
