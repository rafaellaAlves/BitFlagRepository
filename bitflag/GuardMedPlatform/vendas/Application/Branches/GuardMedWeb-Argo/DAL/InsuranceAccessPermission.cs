using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class InsuranceAccessPermission
    {
        public int InsuranceAccessPermissionId { get; set; }
        public int SeguradoProfissionalId { get; set; }
        public DateTime AccessUntil { get; set; }
        public string Observation { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
