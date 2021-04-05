using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class CLTViewModel
    {
        public int? CLTId { get; set; }
        public int? SeguradoClinicaVeterinariaId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
