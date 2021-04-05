using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DTO.Report
{
    public class NewAndEndedContractViewModel
    {
        public DateTime Date { get; set; }
        public string DateFormated => $"{new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(Date.Month)).Substring(0, 3)}/{Date.Year}";
        public int NewContractCount { get; set; }
        public int EndedContractCount { get; set; }
    }
}
