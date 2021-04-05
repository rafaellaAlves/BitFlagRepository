using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class PresentialSituation
    {
        public string Nome { get; set; }
        public int? Turma { get; set; }
        public string Módulo { get; set; }
        public int? Sábado { get; set; }
        public int? Domingo { get; set; }
    }
}
