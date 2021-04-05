using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DTO.Payment.Integration.Iugu
{
    public class ResponseData
    {
        public HttpStatusCode Status { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
}
