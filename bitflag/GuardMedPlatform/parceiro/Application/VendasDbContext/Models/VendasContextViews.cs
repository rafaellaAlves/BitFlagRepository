using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VendasDbContext.Models
{
    public partial class VendasContext : DbContext
    {
        public virtual DbSet<MedicGroupListView> MedicGroupListView { get; set; }
        public virtual DbSet<SeguradoProfissionalExtracaoView> SeguradoProfissionalExtracaoView { get; set; }
    }
}
