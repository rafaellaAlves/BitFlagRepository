using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    /// <summary>
    /// Contêm o total de peso inserido pra uma demanda
    /// </summary>
    public class DemandWeight
    {
        [Key]
        public int DemandId { get; set; }
        public int TotalWeight { get; set; }
    }
}
