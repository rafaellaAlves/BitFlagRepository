using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Residue
{
    public class ResiduePriceViewModel
    {
        public int? ResiduePriceId { get; set; }
        [Update]
        public int? ResidueFamilyId { get; set; }
        public int? RecipientId { get; set; }
        [Update]
        public int UnitOfMeasurementId { get; set; }
        [Update]
        public double? Price { get; set; }
        public string _Price { get { return Price.ToPtBR(); } set { Price = value.FromDoublePtBR(); } }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
