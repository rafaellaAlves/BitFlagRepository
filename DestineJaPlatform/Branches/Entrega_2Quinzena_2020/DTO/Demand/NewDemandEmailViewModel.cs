using DTO.Client;
using DTO.Transporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Demand
{
    public class NewDemandEmailViewModel
    {
        public DemandViewModel Demand { get; set; }
        public ClientViewModel Client { get; set; }
        public TransporterDriverViewModel Driver { get; set; }
    }
}
