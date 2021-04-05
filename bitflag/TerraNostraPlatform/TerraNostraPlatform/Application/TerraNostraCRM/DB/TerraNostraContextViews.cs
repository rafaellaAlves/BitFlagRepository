using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DB
{
    public partial class TerraNostraContext : DbContext
    {
        public virtual DbSet<ClientList> ClientList { get; set; }
        public virtual DbSet<FreezedFamilyList> FreezedFamilyList { get; set; }
        public virtual DbSet<InvoicePaymentList> InvoicePaymentList { get; set; }
        public virtual DbSet<InvoiceView> InvoiceView { get; set; }
        public virtual DbSet<UserIndicators> UserIndicators { get; set; }
        public virtual DbSet<WorkbenchList> WorkbenchList { get; set; }
    }
}
