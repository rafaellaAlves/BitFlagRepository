using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class PlanViewModel
    {
        public int? PlanId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public int? AssistanceId { get; set; }
        public int? CertificateId { get; set; }

        public CertificateViewModel Certificate { get; set; }

        public PlanViewModel()
        {
            Certificate = new CertificateViewModel();
        }
    }
}
