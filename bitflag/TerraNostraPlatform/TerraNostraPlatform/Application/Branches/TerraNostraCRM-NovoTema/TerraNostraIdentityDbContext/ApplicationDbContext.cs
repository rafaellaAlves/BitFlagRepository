using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerraNostraIdentityDbContext
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public virtual DbSet<UserListView> UserListView { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("User");
            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("UserId");
                entity.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(255);
                entity.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(255);
                entity.Property(e => e.MobileNumber).HasColumnName("MobileNumber");
                entity.Property(e => e.MobileNumberConfirmed).HasColumnName("MobileNumberConfirmed");
                entity.Property(e => e.SalesmanAvailable).HasColumnName("SalesmanAvailable");
            });
            builder.Entity<Role>().ToTable("Role");
        }
    }
}
