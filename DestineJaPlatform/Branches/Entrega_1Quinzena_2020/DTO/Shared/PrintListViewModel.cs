using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Shared
{
    public class PrintListViewModel<T>
    {
        public List<T> Items { get; set; }
        public string ChartBase64 { get; set; }
        public List<FilterViewModel> Filters { get; set; }
    }
}
