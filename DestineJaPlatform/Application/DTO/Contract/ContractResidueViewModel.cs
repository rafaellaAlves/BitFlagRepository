using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Contract
{
    public class ContractResidueViewModel
    {
        public int ContractResidueId { get; set; }
        public int ContractId { get; set; }
        public int ResidueId { get; set; }
        public int ResidueFamilyId { get { return Residue.ResidueFamilyId; } }
        public string ResidueFamilyName { get { return ResidueFamily.Name; } }
        public Residue.ResidueViewModel Residue { get; set; }
        public Residue.ResidueFamilyViewModel ResidueFamily { get; set; }
        public double? Price { get; set; }
        public string _Price { get { return Price.ToPtBR(); } set { Price = value.FromDoublePtBR(); } }
        public double? MinimumPrice { get; set; }
        public string _MinimumPrice { get { return MinimumPrice.ToPtBR(); } set { MinimumPrice = value.FromDoublePtBR(); } }
        public double? MediumPrice { get; set; }
        public string _MediumPrice { get { return MediumPrice.ToPtBR(); } set { MediumPrice = value.FromDoublePtBR(); } }
        public double? MaximumPrice { get; set; }
        public string _MaximumPrice { get { return MaximumPrice.ToPtBR(); } set { MaximumPrice = value.FromDoublePtBR(); } }
        public bool Charge { get; set; }
        public bool DeductFromFranchise { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public string UnitOfMeasurementName { get; set; }

        public ContractResidueViewModel()
        {
            Residue = new Residue.ResidueViewModel();
            ResidueFamily = new Residue.ResidueFamilyViewModel();
        }
    }
}
