using DTO.Client;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Contract
{
    public class ContractClientViewModel
    {
        public ClientViewModel Client { get; set; }
        public List<ClientContactViewModel> ClientContact { get; set; }
        public List<ClientCollectionAddressViewModel> ClientCollectionAddresses { get; set; }
        public string ContactName { get; set; }
        public string ContactCpf { get; set; }
        public string _ContactCpf { get => ContactCpf.NumbersOnly(); set => ContactCpf = value.NumbersOnly(); }
        public string ContactRole { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobilePhone { get; set; }
        public string ContactEmail { get; set; }

        public ContractClientViewModel()
        {
            Client = new ClientViewModel();
            ClientContact = new List<ClientContactViewModel>();
            ClientCollectionAddresses = new List<ClientCollectionAddressViewModel>();
        }
    }
}
