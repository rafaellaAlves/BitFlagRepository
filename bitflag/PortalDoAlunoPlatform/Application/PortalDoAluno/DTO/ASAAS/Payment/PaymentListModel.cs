using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ASAAS.Payment
{
    public class PaymentListModel
    {
        public string Object { get; set; }
        public bool HasMore { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<PaymentModel> Data { get; set; }

        public PaymentListModel()
        {
            this.Data = new List<PaymentModel>();
        }
    }
}
