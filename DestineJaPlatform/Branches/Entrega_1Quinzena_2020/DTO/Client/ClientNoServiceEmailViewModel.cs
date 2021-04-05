using DTO.Demand;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientNoServiceEmailViewModel
    {
        public ClientViewModel Client { get; set; }
        public DemandViewModel Demand { get; set; }
        public DateTime VisitedDate { get; set; }
        public string VisitedDateFormated => VisitedDate.ToBrazilianDateFormat();

        public ClientNoServiceEmailViewModel(ClientViewModel client, DemandViewModel demand, DateTime visitedDate)
        {
            Client = client;
            Demand = demand;
            VisitedDate = visitedDate;
        }
    }
}
