using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandResidueFamilyTotalWeight
    {
        [Key]
        public int DemandId { get; set; }
        public int? ResidueFamilyId { get; set; }
        public double TotalWeight { get; set; }
        public string _TotalWeight => TotalWeight % 1 == 0 ? TotalWeight.ToString() : TotalWeight.ToString("#0.0", CultureInfo.GetCultureInfo("pt-BR"));
    }
}
