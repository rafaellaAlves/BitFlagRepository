using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class PresenceList
    {
        public string Nome { get; set; }
        public int? Turma { get; set; }
        public int? ClassId { get; set; }
        public string Estado { get; set; }
        public int? Ano { get; set; }
        public string Info { get; set; }
        public int? PeriodId { get; set; }
        public string Periodo { get; set; }
    }
}
