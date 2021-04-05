using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VendasDbContext.Models
{
    public class MedicGroupListView
    {
        [Key]
        public int MedicGroupId { get; set; }
        public string MedicGroupName { get; set; }
        public string ExternalCode { get; set; }
        public string CNPJ { get; set; }
        public double Discount { get; set; }
        public bool IsActive { get; set; }
        public int QtdCRM { get; set; }
    }
}
