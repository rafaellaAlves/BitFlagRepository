using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class InstituteDocumentation
    {
        public string Nome { get; set; }
        public int? Turma { get; set; }
        public bool? Contrato { get; set; }
        public bool? Fotos_3x4 { get; set; }
        public bool? Ficha_de_Matrícula { get; set; }
        public bool? Regulamento_Interno { get; set; }
        public bool? Requerimento_de_Matrícula { get; set; }
        public bool? Termo_de_Concordância_de_estágio { get; set; }
    }
}
