using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Shared
{
    public class ReportPrintViewModel
    {
        public string Title { get; set; }
        public List<string> TableHeaders { get; set; }
        public List<List<string>> TableData { get; set; }
        public List<string> ChartsBase64 { get; set; }
        public List<FilterViewModel> Filters { get; set; }
    }
}
