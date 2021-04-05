using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ClientContactList
    {
        [Key]
        public int ClientContactId { get; set; }
        public int ClientId { get; set; }
        public int ClientContactTypeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Role { get; set; }
        public bool MainContact { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public string ClientContactTypeName { get; set; }
    }
}
