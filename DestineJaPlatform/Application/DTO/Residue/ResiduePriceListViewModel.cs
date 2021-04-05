using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Residue
{
    public class ResiduePriceListViewModel
    {
        public int? ResiduePriceId { get; set; }
        public int? ResidueFamilyId { get; set; }
        public int? ResidueId { get; set; }
        public string ResidueFamilyName { get; set; }
        public string ONUCode { get; set; }
        public int? RecipientId { get; set; }
        public int? UnitOfMeasurementId { get; set; }
        public string UnitOfMeansurementName { get; set; }
        public double? Price { get; set; }
        public string _Price { get { return Price.ToPtBR(); } set { Price = value.FromDoublePtBR(); } }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
