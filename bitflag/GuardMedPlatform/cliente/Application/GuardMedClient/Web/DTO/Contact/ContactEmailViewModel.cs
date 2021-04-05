using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Contact
{
    public class ContactEmailViewModel
    {
        public SeguradoProfissionalViewModel Segurado { get; set; }
        public string Mensagem { get; set; }
    }
}
