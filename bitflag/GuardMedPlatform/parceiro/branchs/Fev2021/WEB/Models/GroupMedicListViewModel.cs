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
        public string DiscountFormated { get => Discount.ToPtBR(); set => Discount = value.FromDoublePtBR(); }
        public bool IsActive { get; set; }
        public int QtdCRM { get; set; }
    }
}
