using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ServiceClientCollectionAddress
    {
        public int ServiceClientCollectionAddressId { get; set; }
        public int ServiceId { get; set; }
        public int ClientCollectionAddressId { get; set; }

        public ServiceClientCollectionAddress() { }
        public ServiceClientCollectionAddress(int serviceId, int clientCollectionAddressId)
        {
            ServiceId = serviceId;
            ClientCollectionAddressId = clientCollectionAddressId;
        }
    }
}
