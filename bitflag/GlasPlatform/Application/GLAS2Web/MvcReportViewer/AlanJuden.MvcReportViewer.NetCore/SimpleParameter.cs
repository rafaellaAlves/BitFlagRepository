using System;
using System.Collections.Generic;
using System.Text;

namespace AlanJuden.MvcReportViewer.NetCore
{
    public class SimpleParameter
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }

        public SimpleParameter()
        {
            this.Values = new List<string>();
        }
    }
}
