using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ResidueDestinationType : Shared.ListBase
    {
        public int ResidueDestinationTypeId { get; set; }
        public int Order { get; set; }
    }
}
