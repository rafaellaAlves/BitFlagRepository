using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class ResidenceType
    {
        [Key]
        public int ResidenceTypeId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
    }
}
