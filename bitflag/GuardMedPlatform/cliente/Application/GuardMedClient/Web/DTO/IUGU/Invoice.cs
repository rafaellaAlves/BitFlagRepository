using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.IUGU
{
    public class Invoice
    {
        public List<InvoiceItem> Items { get; set; }
    }

    public class InvoiceItem
    {
        public string Id { get; set; }
        public string Customer_id { get; set; }
        public DateTime? Due_Date { get; set; }
        public string _Due_Date { get => Due_Date?.ToString("MMMM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")); }
        public string Status { get; set; }
        public int Total_cents { get; set; }
        public string Secure_url { get; set; }
        public string Total { get; set; }
        public string Created_at { get; set; }
    }
}
