using System;
using System.Collections.Generic;

namespace VendasDbContext.Models
{
    public partial class Clt
    {
        public int Cltid { get; set; }
        public int? SeguradoClinicaVeterinariaId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
