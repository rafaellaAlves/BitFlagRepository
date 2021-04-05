using System;
using System.Collections.Generic;
using System.Text;

namespace FUNCTIONS.Shared
{
    public class ReturnResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
        public object Data { get; set; }

        public ReturnResult()
        {
            this.Code = 0;
            this.Message = null;
            this.HasError = false;
            this.Data = null;
        }

        public ReturnResult(int code, string message, bool hasError, object data = null)
        {
            this.Code = code;
            this.Message = message;
            this.HasError = hasError;
            this.Data = data;
        }
    }
}
