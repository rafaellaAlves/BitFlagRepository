using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Transporter
{
    public class TransporterViewModel : Shared.CompanyBaseViewModel
    {
        public int? TransporterId { get; set; }
        [Update]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int DeletedBy { get; set; }
        public bool IsActive { get; set; }
        public bool CreationComplete { get; set; }
    }
}
