using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Shared
{
    public class ReturnResult
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }

        public ReturnResult(object data, string message, bool hasError)
        {
            this.Data = data;
            this.Message = message;
            this.HasError = hasError;
        }
    }
}
