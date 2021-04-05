using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class GroupMedicListViewModel
    {
        public int MedicGroupId { get; set; }
        public string MedicGroupName { get; set; }
        public string ExternalCode { get; set; }
        public string CNPJ { get; set; }
        public string Discount { get; set; }
        public bool IsActive { get; set; }
        public int QtdCRM { get; set; }
    }
}
