using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AMaisImob_DB.Models
{
    public partial class AMaisImob_DevContext : DbContext
    {
        public AMaisImob_DevContext()
        {
        }

        public AMaisImob_DevContext(DbContextOptions<AMaisImob_DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveCertificate> ActiveCertificate { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Assistance> Assistance { get; set; }
        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<CategoryGuarantorProductTax> CategoryGuarantorProductTax { get; set; }
        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<CertificateContractualApolicyFile> CertificateContractualApolicyFile { get; set; }
        public virtual DbSet<CertificateContractualIncomeType> CertificateContractualIncomeType { get; set; }
        public virtual DbSet<CertificateContractualInstallment> CertificateContractualInstallment { get; set; }
        public virtual DbSet<CertificateContractualMember> CertificateContractualMember { get; set; }
        public virtual DbSet<CertificateContractualPaymentType> CertificateContractualPaymentType { get; set; }
        public virtual DbSet<CertificateContractualPendencyFile> CertificateContractualPendencyFile { get; set; }
        public virtual DbSet<CertificateProductType> CertificateProductType { get; set; }
        public virtual DbSet<Charge> Charge { get; set; }
        public virtual DbSet<ChargeCertificateContractual> ChargeCertificateContractual { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyDocuSign> CompanyDocuSign { get; set; }
        public virtual DbSet<CompanyGuarantorProviderApi> CompanyGuarantorProviderApi { get; set; }
        public virtual DbSet<CompanyOwnerType> CompanyOwnerType { get; set; }
        public virtual DbSet<CompanyType> CompanyType { get; set; }
        public virtual DbSet<ConstructionType> ConstructionType { get; set; }
        public virtual DbSet<EmailLog> EmailLog { get; set; }
        public virtual DbSet<GuarantorProvider> GuarantorProvider { get; set; }
        public virtual DbSet<GuarantorType> GuarantorType { get; set; }
        public virtual DbSet<HabitationType> HabitationType { get; set; }
        public virtual DbSet<InsurancePolicy> InsurancePolicy { get; set; }
        public virtual DbSet<Kinship> Kinship { get; set; }
        public virtual DbSet<MartialStatus> MartialStatus { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<PaymentWay> PaymentWay { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<PlanCoverage> PlanCoverage { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAssistance> ProductAssistance { get; set; }
        public virtual DbSet<ProductCoverage> ProductCoverage { get; set; }
        public virtual DbSet<ProductFamily> ProductFamily { get; set; }
        public virtual DbSet<ProductPlan> ProductPlan { get; set; }
        public virtual DbSet<PropertyType> PropertyType { get; set; }
        public virtual DbSet<ResidenceType> ResidenceType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<StatusType> StatusType { get; set; }
        public virtual DbSet<SystemVariable> SystemVariable { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCompany> UserCompany { get; set; }

        // Unable to generate entity type for table 'dbo.CertificateContractual'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CertificateContractualQuote'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Category'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.GuarantorProduct'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CategoryProduct'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Guarantor'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RegimeTributario'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Utilizacao'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=69.162.77.150;Database=AMaisImob_Dev;User Id=AMaisImob;Password=3kfPeS5dfYR7VsbK;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ActiveCertificate>(entity =>
            {
                entity.HasKey(e => e.CertAtivosId)
                    .HasName("PK__ActiveCe__A0975EAFD1B7C9C8");

                entity.Property(e => e.ReferenceDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Assistance>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ReportCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.Property(e => e.ActionType).IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Entity).IsRequired();

                entity.Property(e => e.EntityName).IsRequired();
            });

            modelBuilder.Entity<CategoryGuarantorProductTax>(entity =>
            {
                entity.Property(e => e.MaxRentAndChargesPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaxRentPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TipoImovel).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.Property(e => e.AdherenceDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.Bairro).HasMaxLength(250);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade).HasMaxLength(250);

                entity.Property(e => e.Complemento).HasMaxLength(250);

                entity.Property(e => e.ConstructionTypeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Endereco).HasMaxLength(250);

                entity.Property(e => e.LocatorCpf)
                    .IsRequired()
                    .HasColumnName("LocatorCPF")
                    .HasMaxLength(14);

                entity.Property(e => e.LocatorName).IsRequired();

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Numero).HasMaxLength(250);

                entity.Property(e => e.RenterCpf)
                    .IsRequired()
                    .HasColumnName("RenterCPF")
                    .HasMaxLength(14);

                entity.Property(e => e.RenterName).IsRequired();

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VigencyDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CertificateContractualApolicyFile>(entity =>
            {
                entity.Property(e => e.FileGuid)
                    .IsRequired()
                    .HasColumnName("FileGUID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FileMimeType)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CertificateContractualIncomeType>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CertificateContractualInstallment>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<CertificateContractualMember>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Occupation)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CertificateContractualPaymentType>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CertificateContractualPendencyFile>(entity =>
            {
                entity.Property(e => e.FileGuid)
                    .IsRequired()
                    .HasColumnName("FileGUID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FileMimeType)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CertificateProductType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Charge>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.IuguinvoiceId).HasColumnName("IUGUInvoiceId");

                entity.Property(e => e.Iuguurl).HasColumnName("IUGUUrl");

                entity.Property(e => e.PayedDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ChargeCertificateContractual>(entity =>
            {
                entity.Property(e => e.FileName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GuidFileName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceFileName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceGuidFileName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceMimeType)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MimeType)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Bairro).HasMaxLength(250);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade).HasMaxLength(250);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyOwnerTypeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CompanyReference)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Complemento).HasMaxLength(250);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco).HasMaxLength(250);

                entity.Property(e => e.Ie)
                    .HasColumnName("IE")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NomeFantasia).HasMaxLength(250);

                entity.Property(e => e.Numero).HasMaxLength(250);

                entity.Property(e => e.RazaoSocial).HasMaxLength(120);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermAcceptedDate).HasColumnType("datetime");

                entity.Property(e => e.TermAcceptedIp)
                    .HasColumnName("TermAcceptedIP")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyDocuSign>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReferenceDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CompanyGuarantorProviderApi>(entity =>
            {
                entity.HasKey(e => new { e.GuarantorProviderId, e.CompanyId })
                    .HasName("PK__CompanyG__41B7C500B443A977");

                entity.ToTable("CompanyGuarantorProviderAPI");
            });

            modelBuilder.Entity<CompanyOwnerType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CompanyType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EmailLog>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailBcc).HasColumnName("EmailBCC");

                entity.Property(e => e.ErrorMessage).IsUnicode(false);
            });

            modelBuilder.Entity<GuarantorProvider>(entity =>
            {
                entity.Property(e => e.GuarantorProviderId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GuarantorType>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<InsurancePolicy>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndRegisteredDate).HasColumnType("datetime");

                entity.Property(e => e.InsurancePolicyNumber).IsRequired();

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartRegisteredDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Kinship>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MartialStatus>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentWay>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProductCoverage>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProductFamily>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ResidenceType>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemVariable>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.BornDate).HasColumnType("datetime");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(256);

                entity.Property(e => e.LastName).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasColumnType("datetime");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });
        }
    }
}
