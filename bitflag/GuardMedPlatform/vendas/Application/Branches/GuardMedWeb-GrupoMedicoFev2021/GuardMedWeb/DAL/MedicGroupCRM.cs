using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.DAL
{
    public class MedicGroupCRM
    {
        public int MedicGroupCRMId { get; set; }
        public int MedicGroupId { get; set; }
        public string CRM { get; set; }
        public string CRMEstado { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
