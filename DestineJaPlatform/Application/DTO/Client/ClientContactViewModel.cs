using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientContactViewModel
    {
        public int? ClientContactId { get; set; }
        public int ClientId { get; set; }
        [Update]
        public int ClientContactTypeId { get; set; }
        [Update]
        public string Name { get; set; }
        public string CPF { get; set; }
        [Update]
        public string Email { get; set; }
        [Update]
        public string Phone { get; set; }
        [Update]
        public string MobilePhone { get; set; }
        [Update]
        public string Role { get; set; }
        [Update]
        public bool MainContact { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
