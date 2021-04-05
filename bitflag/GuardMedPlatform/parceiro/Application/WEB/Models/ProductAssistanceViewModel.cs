using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class ProductAssistanceViewModel
    {
        public int? ProductAssistanceId { get; set; }
        public int ProductId { get; set; }
        public int AssistanceId { get; set; }
    }
}
