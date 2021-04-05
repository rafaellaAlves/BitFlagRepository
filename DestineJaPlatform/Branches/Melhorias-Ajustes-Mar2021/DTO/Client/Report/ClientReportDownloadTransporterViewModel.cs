using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client.Report
{
    public class ClientReportDownloadTransporterViewModel
    {
        public int TransporterId { get; set; }
        public int TransporterEnvironmentalDocumentationId { get; set; }
        public bool TransporterIsCompany { get; set; }
        public string TransporterCompanyName { get; set; }
        public string TransporterTradeName { get; set; }
        public string TransporterDocument { get; set; }
        public string DocumentName { get; set; }
        public string License { get; set; }
        public DateTime DueDate { get; set; }
        public string _DueDate => DueDate.ToBrazilianDateFormat();
        public int DaysToDueDate => (DueDate - DateTime.Now).Days;
    }
}
