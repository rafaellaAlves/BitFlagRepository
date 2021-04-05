using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class ProductRenew
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int IdTipoDoImovel { get; set; }
        public string TipoDoImovel { get; set; }
        public bool Discontinue {get; set;}

    }
}
