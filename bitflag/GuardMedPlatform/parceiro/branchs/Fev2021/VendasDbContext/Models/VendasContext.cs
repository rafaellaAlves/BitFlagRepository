using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VendasDbContext.Models
{
    public partial class VendasContext : DbContext
    {
        public VendasContext()
        {
        }

        public VendasContext(DbContextOptions<VendasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clt> Clt { get; set; }
        public virtual DbSet<EmailLog> EmailLog { get; set; }
        public virtual DbSet<Equipamento> Equipamento { get; set; }
        public virtual DbSet<Especialidade> Especialidade { get; set; }
        public virtual DbSet<EspecialidadePreco> EspecialidadePreco { get; set; }
        public virtual DbSet<EspecialidadeProfissional> EspecialidadeProfissional { get; set; }
        public virtual DbSet<InsuranceAccessPermission> InsuranceAccessPermission { get; set; }
        public virtual DbSet<MedicGroup> MedicGroup { get; set; }
        public virtual DbSet<MedicGroupCrm> MedicGroupCrm { get; set; }
        public virtual DbSet<PagamentoTipo> PagamentoTipo { get; set; }
        public virtual DbSet<PlanoSeguroClinicaVeterinaria> PlanoSeguroClinicaVeterinaria { get; set; }
        public virtual DbSet<PlanoSeguroEquipamento> PlanoSeguroEquipamento { get; set; }
        public virtual DbSet<PlanoSeguroProfissional> PlanoSeguroProfissional { get; set; }
        public virtual DbSet<RendaProtegidaPreco> RendaProtegidaPreco { get; set; }
        public virtual DbSet<SeguradoClinicaVeterinaria> SeguradoClinicaVeterinaria { get; set; }
        public virtual DbSet<SeguradoEquipamento> SeguradoEquipamento { get; set; }
        public virtual DbSet<SeguradoProfissional> SeguradoProfissional { get; set; }
        public virtual DbSet<SeguradoProfissionalHistorico> SeguradoProfissionalHistorico { get; set; }
        public virtual DbSet<SeguroClinicaVeterinariaPreco> SeguroClinicaVeterinariaPreco { get; set; }
        public virtual DbSet<SeguroProfissionalPreco> SeguroProfissionalPreco { get; set; }
        public virtual DbSet<SeguroResponsavelTecnicoPreco> SeguroResponsavelTecnicoPreco { get; set; }
        public virtual DbSet<SystemVariable> SystemVariable { get; set; }
        public virtual DbSet<TipoEquipamento> TipoEquipamento { get; set; }
        public virtual DbSet<MedicGroupListView> MedicGroupListView { get; set; }
        public virtual DbSet<SeguradoProfissionalExtracaoView> SeguradoProfissionalExtracaoView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=69.162.77.150;Database=GuardMed_DEV;User Id=GuardMed;Password=YCnnb3Bk5pUg9Sgg;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Clt>(entity =>
            {
                entity.ToTable("CLT");

                entity.Property(e => e.Cltid).HasColumnName("CLTId");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmailLog>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailBcc).HasColumnName("EmailBCC");

                entity.Property(e => e.ErrorMessage).IsUnicode(false);
            });

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.Property(e => e.Nf).HasColumnName("NF");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.Property(e => e.ExternalCode).IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<EspecialidadePreco>(entity =>
            {
                entity.Property(e => e.CodIugu).HasColumnName("CodIUGU");
            });

            modelBuilder.Entity<InsuranceAccessPermission>(entity =>
            {
                entity.Property(e => e.AccessUntil).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Observation).HasMaxLength(500);
            });

            modelBuilder.Entity<MedicGroup>(entity =>
            {
                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

                entity.Property(e => e.ExternalCode).HasMaxLength(100);
            });

            modelBuilder.Entity<MedicGroupCrm>(entity =>
            {
                entity.ToTable("MedicGroupCRM");

                entity.Property(e => e.MedicGroupCrmid).HasColumnName("MedicGroupCRMId");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasColumnName("CRM");

                entity.Property(e => e.Crmestado)
                    .IsRequired()
                    .HasColumnName("CRMEstado")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PagamentoTipo>(entity =>
            {
                entity.Property(e => e.ExternalCode).IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<PlanoSeguroClinicaVeterinaria>(entity =>
            {
                entity.Property(e => e.ExternalCode).IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<PlanoSeguroEquipamento>(entity =>
            {
                entity.Property(e => e.ExternalCode).IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<PlanoSeguroProfissional>(entity =>
            {
                entity.Property(e => e.ExternalCode).IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<SeguradoClinicaVeterinaria>(entity =>
            {
                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .IsUnicode(false);

                entity.Property(e => e.CertificadoGerado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.Cpftecnico).HasColumnName("CPFTecnico");

                entity.Property(e => e.Crmvestado)
                    .HasColumnName("CRMVEstado")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Crmvtecnico).HasColumnName("CRMVTecnico");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataNascimentoTecnico).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.EstaDeletado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IuguCustomerId).HasColumnName("IUGU_customer_id");

                entity.Property(e => e.IuguInvoiceId).HasColumnName("IUGU_invoice_id");

                entity.Property(e => e.IuguInvoiceSecureUrl).HasColumnName("IUGU_invoice_secure_url");

                entity.Property(e => e.IuguSubscriptionId).HasColumnName("IUGU_subscription_id");

                entity.Property(e => e.QtdClt).HasColumnName("QtdCLT");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SeguradoEquipamento>(entity =>
            {
                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .IsUnicode(false);

                entity.Property(e => e.CertificadoGerado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .IsUnicode(false);

                entity.Property(e => e.Crmv).HasColumnName("CRMV");

                entity.Property(e => e.Crmvestado)
                    .HasColumnName("CRMVEstado")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Nf).HasColumnName("NF");
            });

            modelBuilder.Entity<SeguradoProfissional>(entity =>
            {
                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.Property(e => e.CertificadoGerado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasColumnName("CRM");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataCompra).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.DataRetroatividade).HasColumnType("datetime");

                entity.Property(e => e.DataVencimentoSeguro).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCrm)
                    .IsRequired()
                    .HasColumnName("EstadoCRM")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IuguCustomerId).HasColumnName("IUGU_customer_id");

                entity.Property(e => e.IuguCustomerPaymentMethodId).HasColumnName("IUGU_customer_payment_method_id");

                entity.Property(e => e.IuguInvoiceId).HasColumnName("IUGU_invoice_id");

                entity.Property(e => e.IuguInvoiceSecureUrl).HasColumnName("IUGU_invoice_secure_url");

                entity.Property(e => e.IuguSubscriptionId).HasColumnName("IUGU_subscription_id");

                entity.Property(e => e.IuguToken).HasColumnName("IUGU_token");

                entity.Property(e => e.Nome).IsRequired();

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentOk).HasDefaultValueSql("((0))");

                entity.Property(e => e.RetroatividadeFileName).HasMaxLength(50);

                entity.Property(e => e.RetroatividadeFilePath).HasMaxLength(200);

                entity.Property(e => e.Senha)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SeguradoProfissionalHistorico>(entity =>
            {
                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasColumnName("CRM");

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacaoHistorico)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.DataRetroatividade).HasColumnType("datetime");

                entity.Property(e => e.DataVencimentoSeguro).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCrm)
                    .IsRequired()
                    .HasColumnName("EstadoCRM")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IuguCustomerId).HasColumnName("IUGU_customer_id");

                entity.Property(e => e.IuguCustomerPaymentMethodId).HasColumnName("IUGU_customer_payment_method_id");

                entity.Property(e => e.IuguInvoiceId).HasColumnName("IUGU_invoice_id");

                entity.Property(e => e.IuguInvoiceSecureUrl).HasColumnName("IUGU_invoice_secure_url");

                entity.Property(e => e.IuguSubscriptionId).HasColumnName("IUGU_subscription_id");

                entity.Property(e => e.IuguToken).HasColumnName("IUGU_token");

                entity.Property(e => e.Nome).IsRequired();

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.RetroatividadeFileName).HasMaxLength(50);

                entity.Property(e => e.RetroatividadeFilePath).HasMaxLength(200);
            });

            modelBuilder.Entity<SeguroClinicaVeterinariaPreco>(entity =>
            {
                entity.Property(e => e.Bloco1Bruto).HasColumnName("Bloco1_BRUTO");

                entity.Property(e => e.Bloco1Liquido).HasColumnName("Bloco1_LIQUIDO");

                entity.Property(e => e.Bloco1e2Bruto).HasColumnName("Bloco1e2_BRUTO");

                entity.Property(e => e.Bloco1e2Liquido).HasColumnName("Bloco1e2_LIQUIDO");

                entity.Property(e => e.Bloco1e2e3Bruto).HasColumnName("Bloco1e2e3_BRUTO");

                entity.Property(e => e.Bloco1e2e3Liquido).HasColumnName("Bloco1e2e3_LIQUIDO");

                entity.Property(e => e.Bloco2Bruto).HasColumnName("Bloco2_BRUTO");

                entity.Property(e => e.Bloco2Liquido).HasColumnName("Bloco2_LIQUIDO");

                entity.Property(e => e.Bloco3Bruto).HasColumnName("Bloco3_BRUTO");

                entity.Property(e => e.Rcppfcusto).HasColumnName("RCPPFCusto");

                entity.Property(e => e.Rcppjcusto).HasColumnName("RCPPJCusto");

                entity.Property(e => e.ServicosAdmcusto).HasColumnName("ServicosADMCusto");
            });

            modelBuilder.Entity<SeguroProfissionalPreco>(entity =>
            {
                entity.Property(e => e.CodIugu).HasColumnName("CodIUGU");

                entity.Property(e => e.CodIuguassociado).HasColumnName("CodIUGUAssociado");

                entity.Property(e => e.CustoAssociadoMensal).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustoMensal).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SystemVariable>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TipoEquipamento>(entity =>
            {
                entity.Property(e => e.ExternalCode).IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120);
            });
        }
    }
}
