using DTO.Shared;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientCollectionAddressViewModel : AddressBaseViewModel
    {

        public int? ClientCollectionAddressId { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        [Update]
        public bool Main { get; set; }
    }
}
