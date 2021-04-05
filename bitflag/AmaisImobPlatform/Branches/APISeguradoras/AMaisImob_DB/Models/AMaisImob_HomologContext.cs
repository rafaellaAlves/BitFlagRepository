
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AMaisImob_DB.Models
{
    public partial class AMaisImob_HomologContext : DbContext
    {
        public AMaisImob_HomologContext()
        {
        }

        public AMaisImob_HomologContext(DbContextOptions<AMaisImob_HomologContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveCertificate> ActiveCertificates { get; set; }
        public virtual DbSet<Assistance> Assistance { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<CertificateContractual> CertificateContractual { get; set; }
        public virtual DbSet<CertificateContractualListView> CertificateContractualListView { get; set; }
        public virtual DbSet<Charge> Charge { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProduct { get; set; }
        public virtual DbSet<CategoryGuarantorProductTax> CategoryGuarantorProductTax { get; set; }
        public virtual DbSet<CertificateProductType> CertificateProductType { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyOwnerType> CompanyOwnerType { get; set; }
        public virtual DbSet<CompanyType> CompanyType { get; set; }
        public virtual DbSet<Guarantor> Guarantor { get; set; }
        public virtual DbSet<GuarantorProduct> GuarantorProduct { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<PlanCoverage> PlanCoverage { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAssistance> ProductAssistance { get; set; }
        public virtual DbSet<ProductCoverage> ProductCoverage { get; set; }
        public virtual DbSet<ProductPlan> ProductPlan { get; set; }
        public virtual DbSet<PropertyType> PropertyType { get; set; }
        public virtual DbSet<InsurancePolicy> InsurancePolicy { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RegimeTributario> RegimeTributario { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<StatusType> StatusType { get; set; }
        public virtual DbSet<Utilizacao> Utilizacao { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCompany> UserCompany { get; set; }
        public virtual DbSet<PaymentWay> PaymentWay { get; set; }
        public virtual DbSet<ConstructionType> ConstructionType { get; set; }
        public virtual DbSet<HabitationType> HabitationType { get; set; }
        public virtual DbSet<SystemVariable> SystemVariable { get; set; }
        public virtual DbSet<CertificateListView> CertificateListView { get; set; }
        public virtual DbSet<ResidenceType> ResidenceType { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<CertificateContractualMember> CertificateContractualMember { get; set; }
        public virtual DbSet<CertificateContractualIncomeType> CertificateContractualIncomeType { get; set; }
        public virtual DbSet<CertificateContractualQuote> CertificateContractualQuote { get; set; }
        public virtual DbSet<MartialStatus> MartialStatus { get; set; }
        public virtual DbSet<Kinship> Kinship { get; set; }
        public virtual DbSet<ProductFamily> ProductFamily { get; set; }
        public virtual DbSet<GuarantorType> GuarantorType { get; set; }
        public virtual DbSet<CertificateContractualApolicyFile> CertificateContractualPolicyFile { get; set; }
        public virtual DbSet<CertificateContractualView> CertificateContractualView { get; set; }
        public virtual DbSet<UserList> UserList { get; set; }
        public virtual DbSet<CertificateContractualPendencyFile> CertificateContractualPendencyFile { get; set; }
        public virtual DbSet<CertificateContractualPaymentType> CertificateContractualPaymentType { get; set; }
        public virtual DbSet<CertificateContractualInstallment> CertificateContractualInstallment { get; set; }
        public virtual DbSet<CompanyDocuSign> CompanyDocuSign { get; set; }
        public virtual DbSet<ChargeCertificateContractual> ChargeCertificateContractual { get; set; }
        public virtual DbSet<EmailLog> EmailLog { get; set; }
        public virtual DbSet<GuarantorProvider> GuarantorProvider { get; set; }
        public virtual DbSet<CompanyGuarantorProviderApi> CompanyGuarantorProviderApi { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=homolog.chokosys.com.br;Database=AMaisImob_Homolog;User Id=AMaisImob;Password=Trocar123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");


            modelBuilder.Entity<EmailLog>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailBcc).HasColumnName("EmailBCC");

                entity.Property(e => e.ErrorMessage).IsUnicode(false);
            });

            modelBuilder.Entity<Charge>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getDate())");
            });

            modelBuilder.Entity<CompanyDocuSign>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getDate())");
            });

            modelBuilder.Entity<SystemVariable>().ToTable("SystemVariable");
            modelBuilder.Entity<CertificateContractualApolicyFile>().ToTable("CertificateContractualApolicyFile");

            modelBuilder.Entity<CertificateContractualInstallment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getDate())");
            });

            modelBuilder.Entity<ProductFamily>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getDate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CertificateContractual>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getDate())");
            });


            modelBuilder.Entity<Assistance>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PaymentWay>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSimulation).HasDefaultValueSql("((0))");

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.Bairro).HasMaxLength(250);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade).HasMaxLength(250);

                entity.Property(e => e.Complemento).HasMaxLength(250);

                entity.Property(e => e.Endereco).HasMaxLength(250);

                entity.Property(e => e.LocatorCpf)
                    .IsRequired()
                    .HasColumnName("LocatorCPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.LocatorName).IsRequired();

                entity.Property(e => e.Numero).HasMaxLength(250);

                entity.Property(e => e.RenterCpf)
                    .IsRequired()
                    .HasColumnName("RenterCPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.RenterName).IsRequired();

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CertificateProductType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
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

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TermAccepted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CompanyOwnerType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CompanyType>(entity =>
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
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProductCoverage>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<InsurancePolicy>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
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

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("UserId");
                entity.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(255);
                entity.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(255);
                entity.Property(e => e.MobileNumber).HasColumnName("MobileNumber");
                entity.Property(e => e.MobileNumberConfirmed).HasColumnName("MobileNumberConfirmed");
            });
        }
    }
}