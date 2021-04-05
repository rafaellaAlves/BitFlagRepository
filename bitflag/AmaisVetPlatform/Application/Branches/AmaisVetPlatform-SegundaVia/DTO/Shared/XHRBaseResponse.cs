using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Shared
{
    public class XHRBaseResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }

        public XHRBaseResponse(T data, string message, bool hasError)
        {
            this.Data = data;
            this.Message = message;
            this.HasError = hasError;
        }
    }

    public class XHRBaseResponse
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }

        public XHRBaseResponse() { }
        public XHRBaseResponse(object data, string message, bool hasError)
        {
            this.Data = data;
            this.Message = message;
            this.HasError = hasError;
        }
    }
}
