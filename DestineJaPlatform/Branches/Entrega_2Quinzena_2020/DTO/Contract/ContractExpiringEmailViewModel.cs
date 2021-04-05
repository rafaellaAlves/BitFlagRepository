using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Contract
{
    public class ContractExpiringEmailViewModel
    {
        public ContractViewModel Contract { get; set; }
        public ClientViewModel Client { get; set; }
    }
}
