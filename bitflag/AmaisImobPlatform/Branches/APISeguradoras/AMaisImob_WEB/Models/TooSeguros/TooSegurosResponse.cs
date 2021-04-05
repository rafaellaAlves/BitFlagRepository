using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace AMaisImob_WEB.Models.TooSeguros
{
    public class TooSegurosResponse
    {
        public HttpStatusCode Status { get; set; }
        public Dictionary<string, object> Data { get; set; }

        public TooSegurosResponse(HttpStatusCode status, Dictionary<string, object> data)
        {
            Status = status;
            Data = data;
        }
    }

    public class TooSegurosResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public T Data { get; set; }

        public TooSegurosResponse(HttpStatusCode status, T data)
        {
            Status = status;
            Data = data;
        }
    }
}
