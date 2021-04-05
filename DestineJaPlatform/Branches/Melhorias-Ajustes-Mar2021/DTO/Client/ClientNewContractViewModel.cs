using DTO.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientNewContractViewModel
    {
        public ClientViewModel Client { get; set; }
        public ClientContactViewModel MainContact { get; set; }
        public ClientCollectionAddressViewModel MainAddress { get; set; }
        public List<ClientContactViewModel> Contacts { get; set; }
        public bool FirstContract { get; set; }

        public ClientNewContractViewModel()
        {
            Contacts = new List<ClientContactViewModel>();
        }
    }
}