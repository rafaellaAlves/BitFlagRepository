using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApplicationDbContext.Models;

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

        public ApplicationDbContext(DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder)
            : base(dbContextOptionsBuilder.Options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientActivity> ClientActivity { get; set; }
        public virtual DbSet<ClientCollectionAddress> ClientCollectionAddress { get; set; }
        public virtual DbSet<ClientContact> ClientContact { get; set; }
        public virtual DbSet<ClientContactType> ClientContactType { get; set; }
        public virtual DbSet<ClientContactList> ClientContactList { get; set; }
        public virtual DbSet<Transporter> Transporter { get; set; }
        public virtual DbSet<TransporterEnvironmentalDocumentation> TransporterEnvironmentalDocumentation { get; set; }
        public virtual DbSet<TransporterVehicle> TransporterVehicle { get; set; }
        public virtual DbSet<Recipient> Recipient { get; set; }
        public virtual DbSet<RecipientContact> RecipientContact { get; set; }
        public virtual DbSet<RecipientEnvironmentalDocumentation> RecipientEnvironmentalDocumentation { get; set; }
        public virtual DbSet<TransporterContact> TransporterContact { get; set; }
        public virtual DbSet<TransporterDriver> TransporterDriver { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractPeriodicity> ContractPeriodicity { get; set; }
        public virtual DbSet<ContractSituation> ContractSituation { get; set; }
        public virtual DbSet<ResidueFamily> ResidueFamily { get; set; }
        public virtual DbSet<ResidueFamilyList> ResidueFamilyList { get; set; }
        public virtual DbSet<ResidueFamilyClass> ResidueFamilyClass { get; set; }
        public virtual DbSet<Residue> Residue { get; set; }
        public virtual DbSet<Packaging> Packaging { get; set; }
        public virtual DbSet<PhysicalState> PhysicalState { get; set; }
        public virtual DbSet<UnitOfMeasurement> UnitOfMeasurement { get; set; }
        public virtual DbSet<ResidueList> ResidueList { get; set; }
        public virtual DbSet<ContractList> ContractList { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ResiduePrice> ResiduePrice { get; set; }
        public virtual DbSet<ResiduePriceList> ResiduePriceList { get; set; }
        public virtual DbSet<ContractResidue> ContractResidue { get; set; }
        public virtual DbSet<ServiceFreightPaymentTerm> ServiceFreightPaymentTerm { get; set; }
        public virtual DbSet<ServiceResidualPaymentTerm> ServiceResidualPaymentTerm { get; set; }
        public virtual DbSet<ServiceStatus> ServiceStatus { get; set; }
        public virtual DbSet<ServiceSituation> ServiceSituation { get; set; }
        public virtual DbSet<ServiceClientCollectionAddress> ServiceClientCollectionAddress { get; set; }
        public virtual DbSet<ServiceResidueFamilyPrice> ServiceResidueFamilyPrice { get; set; }
        public virtual DbSet<ServiceList> ServiceList { get; set; }
        public virtual DbSet<ContractClientCollectionAddress> ContractClientCollectionAddress { get; set; }
        public virtual DbSet<ServiceHistoric> ServiceHistoric { get; set; }
        public virtual DbSet<ContractPayment> ContractPayment { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<RouteClient> RouteClient { get; set; }
        public virtual DbSet<RouteClientList> RouteClientList { get; set; }
        public virtual DbSet<BaseRouteClientList> BaseRouteClientList { get; set; }
        public virtual DbSet<RouteResidueFamily> RouteResidueFamily { get; set; }
        public virtual DbSet<RouteList> RouteList { get; set; }
        public virtual DbSet<RouteType> RouteType { get; set; }
        public virtual DbSet<ContractStatus> ContractStatus { get; set; }
        public virtual DbSet<Demand> Demand { get; set; }
        public virtual DbSet<DemandClient> DemandClient { get; set; }
        public virtual DbSet<BaseDemandClientList> BaseDemandClientList { get; set; }
        public virtual DbSet<DemandClientList> DemandClientList { get; set; }
        public virtual DbSet<DemandResidueFamily> DemandResidueFamily { get; set; }
        public virtual DbSet<RoutePeriodicity> RoutePeriodicity { get; set; }
        public virtual DbSet<DemandStatus> DemandStatus { get; set; }
        public virtual DbSet<DemandClientResidue> DemandClientResidue { get; set; }
        public virtual DbSet<DemandClientResidueList> DemandClientResidueList { get; set; }
        public virtual DbSet<DemandDestination> DemandDestination { get; set; }
        public virtual DbSet<DemandDestinationStatus> DemandDestinationStatus { get; set; }
        public virtual DbSet<DemandDestinationList> DemandDestinationList { get; set; }
        public virtual DbSet<DemandDestinationDemand> DemandDestinationDemand { get; set; }
        public virtual DbSet<DemandList> DemandList { get; set; }
        public virtual DbSet<DemandWeight> DemandWeight { get; set; }
        public virtual DbSet<DemandResidueFamilyTotalWeight> DemandResidueFamilyTotalWeight { get; set; }
        public virtual DbSet<DemandNotUsedClient> DemandNotUsedClient { get; set; }
        public virtual DbSet<SystemVariable> SystemVariable { get; set; }
        public virtual DbSet<ClientUser> ClientUser { get; set; }
        public virtual DbSet<ResidueDestinationType> ResidueDestinationType { get; set; }
        public virtual DbSet<TransporterEnvironmentalDocumentationLicenseResidueFamily> TransporterEnvironmentalDocumentationLicenseResidueFamily { get; set; }
        public virtual DbSet<ClientCollectionRequest> ClientCollectionRequest { get; set; }
        public virtual DbSet<ClientLicense> ClientLicense { get; set; }
        public virtual DbSet<EmailLog> EmailLog { get; set; }
        public virtual DbSet<ClientLicenseConditioning> ClientLicenseConditioning { get; set; }
        public virtual DbSet<ClientLicenseConditioningPeriodicity> ClientLicenseConditioningPeriodicity { get; set; }
        public virtual DbSet<ClientLicenseConditioningItem> ClientLicenseConditioningItem { get; set; }
        public virtual DbSet<ClientLicenseConditioningItemList> ClientLicenseConditioningItemList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=homolog.chokosys.com.br;Database=DestineJa_Dev;User Id=DestineJa;Password=6VZt7yp68yDT2n3j;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientLicenseConditioning>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
            });
            modelBuilder.Entity<ClientLicenseConditioningItem>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
            });
            modelBuilder.Entity<EmailLog>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
            });
            modelBuilder.Entity<ClientLicense>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
            });
            modelBuilder.Entity<ClientCollectionRequest>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<DemandDestination>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
                entity.Property(e => e.Finished).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<Demand>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
                entity.Property(e => e.Cancel).HasDefaultValueSql("0");
                entity.Property(e => e.NotValidateFamily).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<ContractPayment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
                entity.Property(e => e.Payed).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<ContractResidue>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ResiduePrice>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Residue>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ResidueFamily>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
                entity.Property(e => e.AcceptTermEmailSended).HasDefaultValueSql("0");
                entity.Property(e => e.TermAccepted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TransporterContact>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TransporterDriver>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Recipient>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<RecipientContact>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<RecipientEnvironmentalDocumentation>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TransporterVehicle>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TransporterEnvironmentalDocumentation>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Transporter>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");
                entity.Property(e => e.Solicitation).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ClientCollectionAddress>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");

            });

            modelBuilder.Entity<ClientContact>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("getDate()");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("0");

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

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
