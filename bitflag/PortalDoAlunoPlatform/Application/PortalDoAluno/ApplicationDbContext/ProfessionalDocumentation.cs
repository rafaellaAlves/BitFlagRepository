using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class ProfessionalDocumentation
    {
        public string Nome { get; set; }
        public int? Turma { get; set; }
        public int? Diploma_de_Graduação { get; set; }
        public int? Certificado_de_Especialização { get; set; }
        public int? Carteira_do_Conselho_Regional { get; set; }
        public int? Declaração_de_tempo_de_UTI { get; set; }
        public int? Declaração_de_Chefia { get; set; }
        public int? Declaração_de_docência { get; set; }
        public int? Resumo_Curricular { get; set; }
    }
}
