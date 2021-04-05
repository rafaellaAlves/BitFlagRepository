using System;
using System.Collections.Generic;

namespace VendasDbContext.Models
{
    public partial class PlanoSeguroClinicaVeterinaria
    {
        public int PlanoSeguroClinicaVeterinariaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool EstaAtivo { get; set; }
        public string ExternalCode { get; set; }
    }
}
