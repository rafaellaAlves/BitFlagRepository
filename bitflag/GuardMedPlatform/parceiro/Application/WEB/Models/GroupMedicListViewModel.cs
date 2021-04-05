using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Utils;

namespace WEB.Models
{
    public class GroupMedicListViewModel
    {
        public int MedicGroupId { get; set; }
        public string MedicGroupName { get; set; }
        public string ExternalCode { get; set; }
        public string CNPJ { get; set; }
        public double? Discount { get; set; }
        public string DiscountFormatted { get => Discount.ToPtBR(); set => Discount = value.FromDoublePtBR(); }
        public bool IsActive { get; set; }
        public int QtdCRM {  get; set; }
        public int? RevenuesFormId { get; set; }
        public int? CompanyPlatformId { get; set; }

        public double? PlatformAgency { get; set; }
        public string PlatformAgencyFormatted { get => PlatformAgency.ToPtBR(); set => PlatformAgency = value.FromDoublePtBR(); }

        public double? PlatformLife { get; set; }
        public string PlatformLifeFormatted { get => PlatformLife.ToPtBR(); set => PlatformLife = value.FromDoublePtBR(); }

        public double? PlatformComission { get; set; }
        public string PlatformComissionFormatted { get => PlatformComission.ToPtBR(); set => PlatformComission = value.FromDoublePtBR(); }

        public int? CompanyOfficeId { get; set; }

        public double? OfficeAgency { get; set; }
        public string OfficeAgencyFormatted { get => OfficeAgency.ToPtBR(); set => OfficeAgency = value.FromDoublePtBR(); }

        public double? OfficeLife { get; set; }
        public string OfficeLifeFormatted { get => OfficeLife.ToPtBR(); set => OfficeLife = value.FromDoublePtBR(); }

        public double? OfficeComission { get; set; }
        public string OfficeComissionFormatted { get => OfficeComission.ToPtBR(); set => OfficeComission = value.FromDoublePtBR(); }
    }
}
