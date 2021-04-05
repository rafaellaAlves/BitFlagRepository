using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
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

        public virtual DbSet<AdministrativeSituation> AdministrativeSituation { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CertificatesDelivered> CertificatesDelivered { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassStudent> ClassStudent { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<EmailList> EmailList { get; set; }
        public virtual DbSet<Finance> Finance { get; set; }
        public virtual DbSet<InstituteDocumentation> InstituteDocumentation { get; set; }
        public virtual DbSet<OptionPresence> OptionPresence { get; set; }
        public virtual DbSet<ParcelSituation> ParcelSituation { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<PersonalDocumentation> PersonalDocumentation { get; set; }
        public virtual DbSet<PresenceList> PresenceList { get; set; }
        public virtual DbSet<PresentialSituation> PresentialSituation { get; set; }
        public virtual DbSet<ProfessionalDocumentStatus> ProfessionalDocumentStatus { get; set; }
        public virtual DbSet<ProfessionalDocumentation> ProfessionalDocumentation { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentDocument> StudentDocument { get; set; }
        public virtual DbSet<StudentList> StudentList { get; set; }
        public virtual DbSet<StudentPresenceSituation> StudentPresenceSituation { get; set; }
        public virtual DbSet<Thesis> Thesis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=bitflag.systems;Database=PortalDoAluno_Dev;User Id=PortalDoAluno;Password=Trocar123!;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministrativeSituation>(entity =>
            {
                entity.HasKey(e => e.IdParcel)
                    .HasName("PK__Administ__C62A2C1A4D49C30B");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.MonthReference)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate).HasColumnType("date");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

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

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CertificatesDelivered>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CertificatesDelivered");

                entity.Property(e => e.CertifiedOfMPTIDate).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ModuleCount).HasDefaultValueSql("((8))");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ClassStudent>(entity =>
            {
                entity.Property(e => e.ASAAS_customer_id).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EmailList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmailList");

                entity.Property(e => e.E_mail)
                    .HasColumnName("E-mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Finance>(entity =>
            {
                entity.Property(e => e.DueDate).IsUnicode(false);

                entity.Property(e => e.Installment).IsUnicode(false);

                entity.Property(e => e.Payment).IsUnicode(false);
            });

            modelBuilder.Entity<InstituteDocumentation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("InstituteDocumentation");

                entity.Property(e => e.Ficha_de_Matrícula).HasColumnName("Ficha de Matrícula");

                entity.Property(e => e.Fotos_3x4).HasColumnName("Fotos 3x4");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Regulamento_Interno).HasColumnName("Regulamento Interno");

                entity.Property(e => e.Requerimento_de_Matrícula).HasColumnName("Requerimento de Matrícula");

                entity.Property(e => e.Termo_de_Concordância_de_estágio).HasColumnName("Termo de Concordância de estágio");
            });

            modelBuilder.Entity<OptionPresence>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParcelSituation>(entity =>
            {
                entity.HasKey(e => e.SituationId)
                    .HasName("PK__ParcelSi__7E44DA9890A47296");

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PersonalDocumentation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PersonalDocumentation");

                entity.Property(e => e.CPF)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Carteira)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RG)
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PresenceList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PresenceList");

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Info).HasMaxLength(255);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Periodo)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PresentialSituation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PresentialSituation");

                entity.Property(e => e.Módulo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessionalDocumentStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__Professi__C8EE2063CE25F672");

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessionalDocumentation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProfessionalDocumentation");

                entity.Property(e => e.Carteira_do_Conselho_Regional).HasColumnName("Carteira do Conselho Regional");

                entity.Property(e => e.Certificado_de_Especialização).HasColumnName("Certificado de Especialização");

                entity.Property(e => e.Declaração_de_Chefia).HasColumnName("Declaração de Chefia");

                entity.Property(e => e.Declaração_de_docência).HasColumnName("Declaração de docência");

                entity.Property(e => e.Declaração_de_tempo_de_UTI).HasColumnName("Declaração de tempo de UTI");

                entity.Property(e => e.Diploma_de_Graduação).HasColumnName("Diploma de Graduação");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Resumo_Curricular).HasColumnName("Resumo Curricular");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.ASAAS_customer_id).IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CPF).IsUnicode(false);

                entity.Property(e => e.CellPhone).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.Complement).IsUnicode(false);

                entity.Property(e => e.CouncilDocumentNumber).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FinishDate).HasColumnType("date");

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.MatriculationLocking).IsUnicode(false);

                entity.Property(e => e.MatriculationStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Neighborhood).IsUnicode(false);

                entity.Property(e => e.Number).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.PhotoFileName).IsUnicode(false);

                entity.Property(e => e.Profession).IsUnicode(false);

                entity.Property(e => e.RG).IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.Zipcode).IsUnicode(false);
            });

            modelBuilder.Entity<StudentDocument>(entity =>
            {
                entity.Property(e => e.CertifiedOfMPTIDate).IsUnicode(false);

                entity.Property(e => e.Contract).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentOfCNIDate).IsUnicode(false);

                entity.Property(e => e.DocumentsSentComments)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralComments).IsUnicode(false);

                entity.Property(e => e.InstituteDocumentationComments)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.InternalRegulation).HasDefaultValueSql("((0))");

                entity.Property(e => e.InternshipAgreementTerm).HasDefaultValueSql("((0))");

                entity.Property(e => e.InternshipComments)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.MatriculationForm).HasDefaultValueSql("((0))");

                entity.Property(e => e.MatriculationRequirement).HasDefaultValueSql("((0))");

                entity.Property(e => e.Photos).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProfessionalDocumentationCommets)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.RegularlyMatriculatedDate).IsUnicode(false);

                entity.Property(e => e.ThesisAgreementTerm).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<StudentList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StudentList");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.CPF).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.CourseFullName).HasMaxLength(535);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Neighborhood).IsUnicode(false);

                entity.Property(e => e.Number).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.Zipcode).IsUnicode(false);
            });

            modelBuilder.Entity<StudentPresenceSituation>(entity =>
            {
                entity.HasKey(e => e.StudentPresenceId)
                    .HasName("PK__StudentP__554B09A764CFC03B");

                entity.Property(e => e.Comments)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.SaturdayComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaturdayDate).HasColumnType("datetime");

                entity.Property(e => e.SundayComments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SundayDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Thesis>(entity =>
            {
                entity.Property(e => e.Advisor).IsUnicode(false);

                entity.Property(e => e.ApprovalDate).IsUnicode(false);

                entity.Property(e => e.AuthorsComment).IsUnicode(false);

                entity.Property(e => e.CPF).IsUnicode(false);

                entity.Property(e => e.Concept).IsUnicode(false);

                entity.Property(e => e.DeliveryDate).IsUnicode(false);

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.Institution1).IsUnicode(false);

                entity.Property(e => e.Institution2).IsUnicode(false);

                entity.Property(e => e.JuryComment).IsUnicode(false);

                entity.Property(e => e.Keyword).IsUnicode(false);

                entity.Property(e => e.MPTI).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PresentationDate).IsUnicode(false);

                entity.Property(e => e.ProtocolDate).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
