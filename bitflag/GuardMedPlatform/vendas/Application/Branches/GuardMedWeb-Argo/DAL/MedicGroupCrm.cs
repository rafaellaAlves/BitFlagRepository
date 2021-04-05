using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class MedicGroupCrm
    {
        public int MedicGroupCrmid { get; set; }
        public int MedicGroupId { get; set; }
        public string Crm { get; set; }
        public string Crmestado { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
