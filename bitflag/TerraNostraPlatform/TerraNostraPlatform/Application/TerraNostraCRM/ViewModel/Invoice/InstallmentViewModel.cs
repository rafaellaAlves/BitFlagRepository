using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Invoice
{
    public class InstallmentViewModel
    {
        public double Price { get; set; }
        public string _Price { get { return Price.ToPtBR(); } set { Price = (double)value.FromDoublePtBR(); } }
        public DateTime InstallmentDate { get; set; }
        public string _InstallmentDate { get { return InstallmentDate.ToDatePtBR(); } set { InstallmentDate = (DateTime)value.FromDatePtBR(); } }
        public bool Visible { get; set; }
        public InstallmentViewModel() { }

        public InstallmentViewModel(double price, DateTime installmentDate, bool visible = true)
        {
            this.Price = price;
            this.InstallmentDate = installmentDate;
            this.Visible = visible;
        }
    }
}
