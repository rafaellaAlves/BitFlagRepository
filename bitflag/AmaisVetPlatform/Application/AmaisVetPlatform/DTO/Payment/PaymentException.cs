using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Payment
{
    public class PaymentException : Exception
    {
        public PaymentException(string message) : base(message) { }
    }
}
