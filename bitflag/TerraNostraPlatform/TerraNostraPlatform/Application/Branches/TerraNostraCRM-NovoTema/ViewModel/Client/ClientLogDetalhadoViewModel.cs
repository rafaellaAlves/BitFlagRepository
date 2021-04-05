using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientLogDetalhadoViewModel
    {
        public DTO.Client.ClientViewModel Client { get; set; }
        public List<DTO.Client.ClientLogViewModel> ClientLogs { get; set; }
    }
}
