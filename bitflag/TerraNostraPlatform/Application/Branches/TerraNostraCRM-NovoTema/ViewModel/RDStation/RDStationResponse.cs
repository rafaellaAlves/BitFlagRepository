using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DTO.RDStation
{
    public class RDStationResponse
    {
        public HttpStatusCode Status { get; set; }
        public Dictionary<string, object> Data { get; set; }

        public RDStationResponse(HttpStatusCode status, Dictionary<string, object> data)
        {
            Status = status;
            Data = data;
        }
    }

    public class RDStationResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public T Data { get; set; }

        public RDStationResponse(HttpStatusCode status, T data)
        {
            Status = status;
            Data = data;
        }
    }
}
