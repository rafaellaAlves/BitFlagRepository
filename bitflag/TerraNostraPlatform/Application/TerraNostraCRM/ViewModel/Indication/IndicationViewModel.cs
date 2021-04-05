using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Indication
{
    public class IndicationViewModel
    {
        public int? IndicationId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? ServiceTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool Accepted { get; set; }
        public int? ClientId { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public int? AcceptedBy { get; set; }
    }
}
