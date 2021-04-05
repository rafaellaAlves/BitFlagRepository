using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class PlataformaEscritorioViewModel
    {
        public int? PlataformaId { get; set; }
        public int? EscritorioId { get; set; }

        public PlataformaEscritorioViewModel(int? plataformaId, int? escritorioId)
        {
            this.PlataformaId = plataformaId;
            this.EscritorioId = escritorioId;
        }
    }
}
