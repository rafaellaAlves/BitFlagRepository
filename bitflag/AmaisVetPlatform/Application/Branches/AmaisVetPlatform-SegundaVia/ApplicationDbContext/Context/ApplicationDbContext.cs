using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApplicationDbContext.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HealthQuestionnaire> HealthQuestionnaire { get; set; }
        public virtual DbSet<HealthQuestionnaireOption> HealthQuestionnaireOption { get; set; }
        public virtual DbSet<HealthQuestionnaireQuestion> HealthQuestionnaireQuestion { get; set; }
        public virtual DbSet<HealthQuestionnaireResponse> HealthQuestionnaireResponse { get; set; }
        public virtual DbSet<MailLog> MailLog { get; set; }
        public virtual DbSet<OccupationArea> OccupationArea { get; set; }
        public virtual DbSet<PaymentGatewayProvider> PaymentGatewayProvider { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<PlanCoverage> PlanCoverage { get; set; }
        public virtual DbSet<PlanCoverageType> PlanCoverageType { get; set; }
        public virtual DbSet<PlanPriceTable> PlanPriceTable { get; set; }
        public virtual DbSet<PlanPriceTableEntry> PlanPriceTableEntry { get; set; }
        public virtual DbSet<ProfessionalSpecialty> ProfessionalSpecialty { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<SubscriptionPaymentGatewayProviderInfo> SubscriptionPaymentGatewayProviderInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=63.143.42.215;Database=AmaisVetPlatform_DEV;User Id=AmaisVetPlatform_DEV;Password=123456;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HealthQuestionnaire>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<HealthQuestionnaireOption>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<HealthQuestionnaireQuestion>(entity =>
            {
                entity.HasKey(e => e.HealthQuestionnaireQuestionaId);

                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<HealthQuestionnaireResponse>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Response).HasMaxLength(128);
            });

            modelBuilder.Entity<MailLog>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailBcc).HasColumnName("EmailBCC");

                entity.Property(e => e.ErrorMessage).IsUnicode(false);
            });

            modelBuilder.Entity<OccupationArea>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<PaymentGatewayProvider>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.Property(e => e.PlanId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<PlanCoverage>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<PlanCoverageType>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<PlanPriceTable>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.ExternalCode).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<PlanPriceTableEntry>(entity =>
            {
                entity.Property(e => e.PaymentGatewayExternalCode).HasMaxLength(128);
            });

            modelBuilder.Entity<ProfessionalSpecialty>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(512);

                entity.Property(e => e.AddressAdditionalInfo).HasMaxLength(128);

                entity.Property(e => e.AddressNumber).HasMaxLength(32);

                entity.Property(e => e.AlteredDate).HasColumnType("datetime");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CertificateDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(128);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsFixedLength();

                entity.Property(e => e.CompanyName).HasMaxLength(128);

                entity.Property(e => e.Coupon).HasMaxLength(128);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(32);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crmv)
                    .IsRequired()
                    .HasColumnName("CRMV")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Crmvstate)
                    .HasColumnName("CRMVState")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EffectiveEndDate).HasColumnType("date");

                entity.Property(e => e.EffectiveStartDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.HealthBlockDate).HasColumnType("datetime");

                entity.Property(e => e.HealthUnblockDate).HasColumnType("datetime");

                entity.Property(e => e.IsStateAgreement).HasDefaultValueSql("((0))");

                entity.Property(e => e.IuguId)
                    .HasColumnName("IUGU_ID")
                    .HasMaxLength(512);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Neighborhood).HasMaxLength(128);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentHasError).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.PlanName).HasMaxLength(128);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SubscriptionPaymentGatewayProviderInfo>(entity =>
            {
                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PlanCode)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.SubscriptionCode)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
