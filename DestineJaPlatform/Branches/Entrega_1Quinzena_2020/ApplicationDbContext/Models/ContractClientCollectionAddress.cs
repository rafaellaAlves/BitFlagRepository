using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ContractClientCollectionAddress
    {
        public int ContractClientCollectionAddressId { get; set; }
        public int ContractId { get; set; }
        public int ClientCollectionAddressId { get; set; }

        public ContractClientCollectionAddress() { }
        public ContractClientCollectionAddress(int contractId, int clientCollectionAddressId) {
            ContractId = contractId;
            ClientCollectionAddressId = clientCollectionAddressId;
        }
    }
}
