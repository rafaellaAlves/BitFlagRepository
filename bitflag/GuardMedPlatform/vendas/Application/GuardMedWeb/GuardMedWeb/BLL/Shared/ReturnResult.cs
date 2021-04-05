using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.BLL.Shared
{
    public class ReturnResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }

        public ReturnResult()
        {
            this.Code = 0;
            this.Message = null;
            this.HasError = false;
        }

        public ReturnResult(int code, string message, bool hasError)
        {
            this.Code = code;
            this.Message = message;
            this.HasError = hasError;
        }
    }
}
