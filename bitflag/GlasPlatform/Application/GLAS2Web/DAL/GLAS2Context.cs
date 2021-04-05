using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL
{
    public partial class GLAS2Context : DbContext
    {
        public virtual DbSet<CompanyLogo> CompanyLogo { get; set; }
        public virtual DbSet<CompanyLawVerificationListItemResponse> CompanyLawVerificationListItemResponse { get; set; }
        public virtual DbSet<LawVerificationList> LawVerificationList { get; set; }
        public virtual DbSet<LawVerificationListItem> LawVerificationListItem { get; set; }
        public virtual DbSet<CompanyLawActionComment> CompanyLawActionComment { get; set; }
        public virtual DbSet<CompanyLawAction> CompanyLawAction { get; set; }
        public virtual DbSet<CompanyLawComment> CompanyLawComment { get; set; }
        public virtual DbSet<CompanyLawActionType> CompanyLawActionType { get; set; }
        public virtual DbSet<CompanyLawActionStatus> CompanyLawActionStatus { get; set; }
        public virtual DbSet<Segmento> Segmento { get; set; }
        public virtual DbSet<Orgao> Orgao { get; set; }
        public virtual DbSet<Esfera> Esfera { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<LawConclusionStatus> LawConclusionStatus { get; set; }
        public virtual DbSet<LawApplicationType> LawApplicationType { get; set; }
        public virtual DbSet<CompanyLaw> CompanyLaw { get; set; }
        public virtual DbSet<LawType> LawType { get; set; }
        public virtual DbSet<Law> Law { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<CompanyUser> CompanyUser { get; set; }
        public virtual DbSet<CompanyGroup> CompanyGroup { get; set; }
        public virtual DbSet<CompanyLawActionView> CompanyLawActionView { get; set; }
        public virtual DbSet<CompanyLawView> CompanyLawView { get; set; }
        public virtual DbSet<LawView> LawView { get; set; }
        public virtual DbSet<Identity.AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<Identity.User> User { get; set; }
        public virtual DbSet<Identity.Role> Role { get; set; }
        public virtual DbSet<LawAttachment> Lawattachment { get; set; }
        public virtual DbSet<CompanyLawAttachment> CompanyLawattachment { get; set; }
        public virtual DbSet<CompanyUserRole> CompanyUserRole { get; set; }
        public virtual DbSet<CompanyLawActionAttachment> CompanyLawActionAttachment { get; set; }
        public virtual DbSet<UserView> UserView { get; set; }
        public virtual DbSet<CompanyLawUserView> CompanyLawUserView { get; set; }
        public virtual DbSet<LawPotentialityType> LawPotentialityType { get; set; }
        public virtual DbSet<Audit> Audit { get; set; }
        public virtual DbSet<AuditType> AuditType { get; set; }
        public virtual DbSet<AuditStatus> AuditStatus { get; set; }
        public virtual DbSet<AuditItem> AuditItem { get; set; }
        public virtual DbSet<AuditItemStatus> AuditItemStatus { get; set; }
        public virtual DbSet<CompanyLawVisualization> CompanyLawVisualization { get; set; }
        public virtual DbSet<CompanyView> CompanyView { get; set; }
        public virtual DbSet<LawVerificationListItemView> LawVerificationListItemView { get; set; }
        public virtual DbSet<LawChange> LawChange { get; set; }
        public virtual DbSet<EmailLog> EmailLog { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public virtual DbSet<QuestionSubTheme> QuestionSubTheme { get; set; }
        public virtual DbSet<QuestionTheme> QuestionTheme { get; set; }
        public virtual DbSet<QuestionSubThemeList> QuestionSubThemeList { get; set; }
        public virtual DbSet<QuestionList> QuestionList { get; set; }
        public virtual DbSet<QuestionAnswerList> QuestionAnswerList { get; set; }
        public virtual DbSet<CompanyQuestion> CompanyQuestion { get; set; }
        public virtual DbSet<CompanyQuestionAnswer> CompanyQuestionAnswer { get; set; }
        public virtual DbSet<CompanyQuestionChoosenAnswer> CompanyQuestionChoosenAnswer { get; set; }
        public virtual DbSet<CompanyQuestionChoosenAnswerItem> CompanyQuestionChoosenAnswerItem { get; set; }
        public virtual DbSet<Translation> Translation { get; set; }

        public GLAS2Context(DbContextOptions<GLAS2Context> options)
            : base(options)
        {
        }

        public GLAS2Context(DbContextOptionsBuilder<GLAS2Context> dbContextOptionsBuilder)
            : base(dbContextOptionsBuilder.Options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //IdentityOnModelCreating(modelBuilder);

            //modelBuilder.Entity<CompanyLawUserView>(entity =>
            //{
            //    entity.Property(e => e.LastView).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            //});

            modelBuilder.Entity<CompanyQuestion>(entity => { entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())"); });
            modelBuilder.Entity<CompanyQuestionAnswer>(entity => { entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())"); });
            modelBuilder.Entity<CompanyQuestionChoosenAnswer>(entity => { entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())"); });

            modelBuilder.Entity<Question>(entity =>
                {
                    entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                    entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
                });
            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<QuestionSubTheme>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<QuestionTheme>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<EmailLog>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Sended).HasDefaultValueSql("1");
            });
            modelBuilder.Entity<LawChange>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            });
            modelBuilder.Entity<CompanyLawVisualization>(entity =>
            {
                entity.Property(e => e.VisualizationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CompanyLawActionAttachment>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1)");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CompanyLawAttachment>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1)");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LawAttachment>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1)");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.FullLaw).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CompanyLogo>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1)");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LawVerificationListItem>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });


            modelBuilder.Entity<LawVerificationList>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CompanyLawActionComment>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CompanyLawAction>(entity =>
            {
                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
                entity.Property(e => e.RenewDate).HasColumnType("datetime");
                entity.Property(e => e.WarningDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CompanyLawComment>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LawConclusionStatus>(entity =>
            {
                entity.Property(e => e.LawConclusionStatusId).HasColumnName("LawConclusionStatusId");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LawApplicationType>(entity =>
            {
                entity.Property(e => e.LawApplicationTypeId).HasColumnName("LawApplicationTypeId");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CompanyLaw>(entity =>
            {
                entity.Property(e => e.CompanyLawId).HasColumnName("CompanyLawId");
                entity.Property(e => e.CompanyId).HasColumnName("CompanyId");
                entity.Property(e => e.LawId).HasColumnName("LawId");
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LawType>(entity =>
            {
                entity.Property(e => e.LawTypeId).HasColumnName("LawTypeId");
                entity.Property(e => e.Name).HasMaxLength(120);
                entity.Property(e => e.Description);
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Law>(entity =>
            {
                entity.Property(e => e.LawId).HasColumnName("LawId");
                entity.Property(e => e.LawTypeId).HasColumnName("LawTypeId");
                entity.Property(e => e.Number).HasMaxLength(120);
                entity.Property(e => e.PublishDate).HasColumnType("date");
                entity.Property(e => e.ForceDate).HasColumnType("date");
                entity.Property(e => e.Title).HasMaxLength(120);
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.QuestionEmailSended).HasDefaultValueSql("((0))");
                entity.Property(e => e.EndedQuestions).HasDefaultValueSql("((0))");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Bairro).HasMaxLength(250);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Cidade).HasMaxLength(250);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Complemento).HasMaxLength(250);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco).HasMaxLength(250);

                entity.Property(e => e.Ie)
                    .HasColumnName("IE")
                    .HasColumnType("char(50)");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NomeFantasia).HasMaxLength(250);

                entity.Property(e => e.Numero).HasMaxLength(250);

                entity.Property(e => e.RazaoSocial).HasMaxLength(120);

                entity.Property(e => e.Telefone).HasColumnType("char(50)");

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasColumnType("char(2)");
            });

            modelBuilder.Entity<Group>(entity =>
            {

                entity.Property(e => e.GroupId)
                    .HasColumnName("GroupId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("Name");

                entity.Property(e => e.Description)
                    .HasColumnName("Description");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentId");
            });

            modelBuilder.Entity<CompanyUser>(entity =>
            {
                entity.Property(e => e.CompanyUserId)
                    .HasColumnName("CompanyUserID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CompanyUserNavigation)
                    .WithOne(p => p.InverseCompanyUserNavigation)
                    .HasForeignKey<CompanyUser>(d => d.CompanyUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyUser_CompanyUser");
            });

            modelBuilder.Entity<CompanyGroup>(entity =>
            {
                entity.Property(e => e.CompanyGroupId).HasColumnName("CompanyGroupId").ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.LastHandler).HasDefaultValueSql("((-1))");
            });

            modelBuilder.Entity<Identity.AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });
            modelBuilder.Entity<Identity.User>().ToTable("User");
            modelBuilder.Entity<Identity.User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("UserId");

                entity.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(255);
                entity.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(255);

                entity.Property(e => e.MobileNumber).HasColumnName("MobileNumber");
                entity.Property(e => e.MobileNumberConfirmed).HasColumnName("MobileNumberConfirmed");

                entity.Property(e => e.CreatedDate).HasDefaultValue(DateTime.Now);
                //entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            });
            modelBuilder.Entity<Identity.Role>().ToTable("Role");
        }
    }
}
