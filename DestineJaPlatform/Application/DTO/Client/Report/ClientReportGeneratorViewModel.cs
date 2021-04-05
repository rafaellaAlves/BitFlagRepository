using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DTO.Shared;

namespace DTO.Client.Report
{
    public class ClientReportGeneratorViewModel
    {

        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string Name { get; set; }     
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public bool HasContract { get; set; }
        public bool HasService { get; set; }
        public DateTime? LastCollectedDate { get; set; }
        public string _LastCollectedDate => LastCollectedDate.ToBrazilianDateFormat();
    }
}