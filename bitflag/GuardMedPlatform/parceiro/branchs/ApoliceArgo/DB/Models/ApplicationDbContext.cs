using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Models
{
    public class ApplicationDbContext : IdentityDbContext<AspNetUser, AspNetRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AspNetUser>().ToTable("User");
            builder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("UserId");
                entity.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(255);
                entity.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(255);
                entity.Property(e => e.MobileNumber).HasColumnName("MobileNumber");
                entity.Property(e => e.MobileNumberConfirmed).HasColumnName("MobileNumberConfirmed");
            });
            builder.Entity<AspNetRole>().ToTable("Role");
        }
    }
}
