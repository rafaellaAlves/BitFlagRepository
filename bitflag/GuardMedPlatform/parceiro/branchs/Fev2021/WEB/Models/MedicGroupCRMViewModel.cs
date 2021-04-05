using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class MedicGroupCRMViewModel
    {
        public int? MedicGroupCRMId { get; set; }
        public int? MedicGroupId { get; set; }
        public string CRM { get; set; }
        public string CRMEstado { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
