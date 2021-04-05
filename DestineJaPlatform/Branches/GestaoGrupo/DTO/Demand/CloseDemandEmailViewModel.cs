using DTO.Client;
using DTO.Transporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Demand
{
    public class CloseDemandEmailViewModel
    {
        public DemandViewModel Demand { get; set; }
        public DemandClientViewModel DemandClient { get; set; }
        public ClientViewModel Client { get; set; }
        public TransporterDriverViewModel Driver { get; set; }
    }
}
