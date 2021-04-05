using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Recipient
{
   public class RecipientContactViewModel
    {
        public int? RecipientContactId { get; set; }
        public int RecipientId { get; set; }
        [Update]
        public string Name { get; set; }
        [Update]
        public string Role { get; set; }
        [Update]
        public string Phone { get; set; }
        [Update]
        public string Email { get; set; }
        [Update]
        public string CellPhone { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
