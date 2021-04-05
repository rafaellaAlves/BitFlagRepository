using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DB
{
    public partial class TerraNostraContext : DbContext
    {
        public TerraNostraContext()
        {
        }

        public TerraNostraContext(DbContextOptions<TerraNostraContext> options)
            : base(options)
        {
        }

        public TerraNostraContext(DbContextOptionsBuilder<TerraNostraContext> dbContextOptionsBuilder)
            : base(dbContextOptionsBuilder.Options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<CertificateType> CertificateType { get; set; }
        public virtual DbSet<CivilStatus> CivilStatus { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientApplicant> ClientApplicant { get; set; }
        public virtual DbSet<ClientArchive> ClientArchive { get; set; }
        public virtual DbSet<ClientCalendar> ClientCalendar { get; set; }
        public virtual DbSet<ClientDependent> ClientDependent { get; set; }
        public virtual DbSet<ClientDependentType> ClientDependentType { get; set; }
        public virtual DbSet<ClientLog> ClientLog { get; set; }
        public virtual DbSet<ClientStatus> ClientStatus { get; set; }
        public virtual DbSet<ClientStatusHistory> ClientStatusHistory { get; set; }
        public virtual DbSet<ClientTaskNotification> ClientTaskNotification { get; set; }
        public virtual DbSet<ClientType> ClientType { get; set; }
        public virtual DbSet<FamilyMember> FamilyMember { get; set; }
        public virtual DbSet<FamilyMemberType> FamilyMemberType { get; set; }
        public virtual DbSet<FamilyStructure> FamilyStructure { get; set; }
        public virtual DbSet<FamilyTree> FamilyTree { get; set; }
        public virtual DbSet<FreezedFamily> FreezedFamily { get; set; }
        public virtual DbSet<FreezedFamilyItem> FreezedFamilyItem { get; set; }
        public virtual DbSet<Indication> Indication { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceFreezedFamilyItem> InvoiceFreezedFamilyItem { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItem { get; set; }
        public virtual DbSet<InvoiceItemServiceType> InvoiceItemServiceType { get; set; }
        public virtual DbSet<InvoicePayment> InvoicePayment { get; set; }
        public virtual DbSet<InvoicePaymentType> InvoicePaymentType { get; set; }
        public virtual DbSet<InvoicePaymentWay> InvoicePaymentWay { get; set; }
        public virtual DbSet<InvoiceServicePayment> InvoiceServicePayment { get; set; }
        public virtual DbSet<InvoiceServiceType> InvoiceServiceType { get; set; }
        public virtual DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public virtual DbSet<ItalyProtocolAdditionalDocumentsModule> ItalyProtocolAdditionalDocumentsModule { get; set; }
        public virtual DbSet<ItalyProtocolModule> ItalyProtocolModule { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobFreezedFamilyItemInfo> JobFreezedFamilyItemInfo { get; set; }
        public virtual DbSet<JobFreezedFamilyItemInfoRegistryOffice> JobFreezedFamilyItemInfoRegistryOffice { get; set; }
        public virtual DbSet<JobInteraction> JobInteraction { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<RegistryOffice> RegistryOffice { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<SystemVariable> SystemVariable { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketArea> TicketArea { get; set; }
        public virtual DbSet<TicketHistory> TicketHistory { get; set; }
        public virtual DbSet<TicketStatus> TicketStatus { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Workflow> Workflow { get; set; }
        public virtual DbSet<WorkflowStep> WorkflowStep { get; set; }
        public virtual DbSet<ContactMedium> ContactMedium { get; set; }
        public virtual DbSet<RDStationLog> RDStationLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=sistema.tncidadaniaitaliana.com.br;Database=TerraNostra_Dev;User Id=TerraNostra;Password=Trocar123!;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

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

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.Property(e => e.ActionType).IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Entity).IsRequired();

                entity.Property(e => e.EntityName).IsRequired();
            });

            modelBuilder.Entity<CertificateType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CivilStatus>(entity =>
            {
                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Bairro).HasMaxLength(250);

                entity.Property(e => e.Celular).HasMaxLength(50);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade).HasMaxLength(250);

                entity.Property(e => e.ClientTypeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento).HasMaxLength(250);

                entity.Property(e => e.Contact).HasDefaultValueSql("('')");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco).HasMaxLength(250);

                entity.Property(e => e.Family).HasMaxLength(60);

                entity.Property(e => e.FirstContactDate).HasColumnType("datetime");

                entity.Property(e => e.FirstContacted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ie)
                    .HasColumnName("IE")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NomeFantasia).HasMaxLength(250);

                entity.Property(e => e.Numero).HasMaxLength(250);

                entity.Property(e => e.Occupation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial).HasMaxLength(120);

                entity.Property(e => e.ResponsibleDate).HasColumnType("datetime");

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientApplicant>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.MarriageDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ClientArchive>(entity =>
            {
                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientCalendar>(entity =>
            {
                entity.HasKey(e => e.ClientTaskId)
                    .HasName("PK__ClientCa__5E2A0F44D214ED0D");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.NoticeDate).HasColumnType("datetime");

                entity.Property(e => e.TaskDate).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<ClientDependent>(entity =>
            {
                entity.Property(e => e.Bairro).HasMaxLength(250);

                entity.Property(e => e.Celular).HasMaxLength(50);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade).HasMaxLength(250);

                entity.Property(e => e.Complemento).HasMaxLength(250);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco).HasMaxLength(250);

                entity.Property(e => e.Family).HasMaxLength(60);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Numero).HasMaxLength(250);

                entity.Property(e => e.Occupation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientDependentType>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientLog>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.ModificatedDate).HasColumnType("datetime");

                entity.Property(e => e.PlainText)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<ClientStatus>(entity =>
            {
                entity.Property(e => e.ExternalCode).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ClientStatusHistory>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ClientTaskNotification>(entity =>
            {
                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TaskDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientType>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<FamilyMember>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.ClientApplicantId).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeathDate).HasColumnType("datetime");

                entity.Property(e => e.MarriageDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FamilyMemberType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<FamilyTree>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<FreezedFamily>(entity =>
            {
                entity.Property(e => e.Accepted).HasDefaultValueSql("((0))");

                entity.Property(e => e.AcceptedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<FreezedFamilyItem>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BirthPlace).HasMaxLength(500);

                entity.Property(e => e.DeathDate).HasColumnType("datetime");

                entity.Property(e => e.DeathPlace).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.MarriageDate).HasColumnType("datetime");

                entity.Property(e => e.MarriagePlace).HasMaxLength(500);
            });

            modelBuilder.Entity<Indication>(entity =>
            {
                entity.Property(e => e.AcceptedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Phone).IsRequired();
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.AlteredDate).HasColumnType("datetime");

                entity.Property(e => e.Cnncost).HasColumnName("CNNCost");

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceStatusId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<InvoiceFreezedFamilyItem>(entity =>
            {
                entity.Property(e => e.BirthCertificateBra).HasColumnName("BirthCertificateBRA");

                entity.Property(e => e.BirthCertificateIta).HasColumnName("BirthCertificateITA");

                entity.Property(e => e.Cnn).HasColumnName("CNN");

                entity.Property(e => e.DeathCertificateBra).HasColumnName("DeathCertificateBRA");

                entity.Property(e => e.DeathCertificateIta).HasColumnName("DeathCertificateITA");

                entity.Property(e => e.MarriageCertificateBra).HasColumnName("MarriageCertificateBRA");

                entity.Property(e => e.MarriageCertificateIta).HasColumnName("MarriageCertificateITA");
            });

            modelBuilder.Entity<InvoiceItemServiceType>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InvoicePayment>(entity =>
            {
                entity.Property(e => e.InstallmentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvoicePaymentType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<InvoicePaymentWay>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<InvoiceServiceType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InvoiceStatus>(entity =>
            {
                entity.Property(e => e.ExternalCode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ItalyProtocolAdditionalDocumentsModule>(entity =>
            {
                entity.HasKey(e => e.ItalyProtocolAdditionalDocumentsId);
            });

            modelBuilder.Entity<ItalyProtocolModule>(entity =>
            {
                entity.HasKey(e => e.ItalyProtocolId);

                entity.Property(e => e.SentDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<JobFreezedFamilyItemInfo>(entity =>
            {
                entity.Property(e => e.CertificateDate).HasColumnType("datetime");

                entity.Property(e => e.HaiaHandoutReceiveDate).HasColumnType("datetime");

                entity.Property(e => e.HaiaHandoutSentDate).HasColumnType("datetime");

                entity.Property(e => e.RegistryOfficeBook).HasMaxLength(255);

                entity.Property(e => e.RegistryOfficeCertificateShippingArrivalDate).HasColumnType("datetime");

                entity.Property(e => e.RegistryOfficePage).HasMaxLength(255);

                entity.Property(e => e.RegistryOfficePaymentDate).HasColumnType("datetime");

                entity.Property(e => e.RegistryOfficeRequirementSentDate).HasColumnType("datetime");

                entity.Property(e => e.RegistryOfficeRequirementSentEmailDate).HasColumnType("datetime");

                entity.Property(e => e.RegistryOfficeShippingDate).HasColumnType("datetime");

                entity.Property(e => e.RegistryOfficeTerm).HasMaxLength(255);

                entity.Property(e => e.TranslationReceiveDate).HasColumnType("datetime");

                entity.Property(e => e.TranslationSentDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<JobInteraction>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<JobStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.Entity<RDStationLog>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RegistryOffice>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.State).HasMaxLength(255);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.Property(e => e.ExternalCode).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SystemVariable>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK__SystemVa__C41E0288E3B2D52E");

                entity.Property(e => e.Key)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Subject).IsRequired();
            });

            modelBuilder.Entity<TicketArea>(entity =>
            {
                entity.Property(e => e.ExternalCode).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<TicketHistory>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Subject).IsRequired();
            });

            modelBuilder.Entity<TicketStatus>(entity =>
            {
                entity.Property(e => e.ExternalCode).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(256);

                entity.Property(e => e.LastName).HasMaxLength(256);

                entity.Property(e => e.LastSaleDate).HasColumnType("datetime");

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

            modelBuilder.Entity<Workflow>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WorkflowStep>(entity =>
            {
                entity.Property(e => e.JobFreezedFamilyInfoTitle).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Role)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
