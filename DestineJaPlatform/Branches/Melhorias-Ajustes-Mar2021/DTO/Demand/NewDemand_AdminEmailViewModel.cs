using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Demand
{
    public class NewDemand_AdminEmailViewModel
    {
        public DemandViewModel Demand { get; set; }
        public List<ClientViewModel> Clients { get; set; }
    }
}
