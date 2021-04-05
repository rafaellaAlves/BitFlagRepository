using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.DAL
{
    public class GuardMedWebContext : DbContext
    {
        public virtual DbSet<DAL.PlanoSeguroProfissional> PlanoSeguroProfissional { get; set; }
        public virtual DbSet<DAL.SeguradoProfissional> SeguradoProfissional { get; set; }
        public virtual DbSet<DAL.SeguroProfissionalPreco> SeguroProfissionalPreco { get; set; }
        public virtual DbSet<DAL.PlanoSeguroEquipamento> PlanoSeguroEquipamento { get; set; }
        public virtual DbSet<DAL.SeguradoEquipamento> SeguradoEquipamento { get; set; }
        public virtual DbSet<DAL.SeguradoClinicaVeterinaria> SeguradoClinicaVeterinaria { get; set; }
        public virtual DbSet<DAL.PagamentoTipo> PagamentoTipo { get; set; }
        public virtual DbSet<DAL.SeguroClinicaVeterinariaPreco> SeguroClinicaVeterinariaPreco { get; set; }
        public virtual DbSet<DAL.SeguroResponsavelTecnicoPreco> SeguroResponsavelTecnicoPreco { get; set; }
        public virtual DbSet<DAL.PlanoSeguroClinicaVeterinaria> PlanoSeguroClinicaVeterinaria { get; set; }
        public virtual DbSet<DAL.Equipamento> Equipamento { get; set; }
        public virtual DbSet<DAL.TipoEquipamento> TipoEquipamento { get; set; }
        public virtual DbSet<DAL.SystemVariable> SystemVariable { get; set; }
        public virtual DbSet<DAL.SeguradoProfissionalView> SeguradoProfissionalView { get; set; }
        public virtual DbSet<DAL.SeguradoProfissionalExtracaoView> SeguradoProfissionalExtracaoView { get; set; }
        public virtual DbSet<DAL.SeguradoAparelhoView> SeguradoAparelhoView { get; set; }
        public virtual DbSet<DAL.CLT> CLT { get; set; }
        public virtual DbSet<DAL.SeguradoClinicaVeterinariaView> SeguradoClinicaVeterinariaView { get; set; }
        public virtual DbSet<DAL.Especialidade> Especialidade { get; set; }
        public virtual DbSet<DAL.EspecialidadeProfissional> EspecialidadeProfissional { get; set; }
        public virtual DbSet<DAL.EspecialidadePreco> EspecialidadePreco { get; set; }
        public virtual DbSet<DAL.MedicGroup> MedicGroup { get; set; }
        public virtual DbSet<DAL.MedicGroupCRM> MedicGroupCRM { get; set; }
        public virtual DbSet<DAL.MedicGroupListView> MedicGroupListView { get; set; }
        public virtual DbSet<DAL.RendaProtegidaPreco> RendaProtegidaPreco { get; set; }

        public GuardMedWebContext(DbContextOptionsBuilder<GuardMedWebContext> dbContextOptionsBuilder)
            : base(dbContextOptionsBuilder.Options)
        {
        }

        public GuardMedWebContext(DbContextOptions<GuardMedWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RendaProtegidaPreco>().ToTable("RendaProtegidaPreco");
            modelBuilder.Entity<MedicGroupListView>().ToTable("MedicGroupListView");
            modelBuilder.Entity<MedicGroup>().ToTable("MedicGroup");
            modelBuilder.Entity<MedicGroupCRM>().ToTable("MedicGroupCRM");
            modelBuilder.Entity<EspecialidadeProfissional>().ToTable("EspecialidadeProfissional");
            modelBuilder.Entity<Especialidade>().ToTable("Especialidade");
            modelBuilder.Entity<SeguradoClinicaVeterinariaView>().ToTable("SeguradoClinicaVeterinariaView");
            modelBuilder.Entity<CLT>().ToTable("CLT");
            modelBuilder.Entity<SeguradoAparelhoView>().ToTable("SeguradoAparelhoView");
            modelBuilder.Entity<SeguradoProfissionalView>().ToTable("SeguradoProfissionalView");
            modelBuilder.Entity<SeguradoProfissionalExtracaoView>().ToTable("SeguradoProfissionalExtracaoView");
            modelBuilder.Entity<SystemVariable>().ToTable("SystemVariable");
            modelBuilder.Entity<TipoEquipamento>().ToTable("TipoEquipamento");
            modelBuilder.Entity<Equipamento>().ToTable("Equipamento");
            modelBuilder.Entity<PlanoSeguroClinicaVeterinaria>().ToTable("PlanoSeguroClinicaVeterinaria");
            modelBuilder.Entity<SeguroClinicaVeterinariaPreco>().ToTable("SeguroClinicaVeterinariaPreco");
            modelBuilder.Entity<SeguroResponsavelTecnicoPreco>().ToTable("SeguroResponsavelTecnicoPreco");
            modelBuilder.Entity<PagamentoTipo>().ToTable("PagamentoTipo");
            //modelBuilder.Entity<SeguradoClinicaVeterinaria>().ToTable("SeguradoClinicaVeterinaria");
            modelBuilder.Entity<PlanoSeguroEquipamento>().ToTable("PlanoSeguroEquipamento");
            modelBuilder.Entity<SeguradoEquipamento>().ToTable("SeguradoEquipamento");
            modelBuilder.Entity<PlanoSeguroProfissional>().ToTable("PlanoSeguroProfissional");
            modelBuilder.Entity<SeguradoProfissional>().ToTable("SeguradoProfissional");
            modelBuilder.Entity<SeguroProfissionalPreco>().ToTable("SeguroProfissionalPreco");
            
            modelBuilder.Entity<SeguradoClinicaVeterinaria>(entity =>
            {
                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
                
            });
        }
    }
}
