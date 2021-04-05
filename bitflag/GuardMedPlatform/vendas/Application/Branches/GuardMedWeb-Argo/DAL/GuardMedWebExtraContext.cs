using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL
{
    public partial class GuardMedWebContext : DbContext
    {
        public GuardMedWebContext(DbContextOptions<GuardMedWebContext> options) : base(options)
        { }

        public virtual DbSet<MedicGroupListView> MedicGroupListView { get; set; }
        public virtual DbSet<SeguradoProfissionalExtracaoView> SeguradoProfissionalExtracaoView { get; set; }
        public virtual DbSet<SeguradoProfissionalView> SeguradoProfissionalView { get; set; }
        public virtual DbSet<SeguradoClinicaVeterinariaView> SeguradoClinicaVeterinariaView { get; set; }
        public virtual DbSet<SeguradoAparelhoView> SeguradoAparelhoView { get; set; }

    }
}
