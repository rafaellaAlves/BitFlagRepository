using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class EmailList
    {
        public string Nome { get; set; }
        public string E_mail { get; set; }
        public int? Turma { get; set; }
    }
}
