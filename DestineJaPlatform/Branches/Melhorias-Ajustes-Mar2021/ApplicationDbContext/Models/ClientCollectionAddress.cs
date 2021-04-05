using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ClientCollectionAddress : Shared.AddressBase
    {
        public int ClientCollectionAddressId { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool Main { get; set; }
    }
}
