using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VNPT.Data.Models
{
    public partial class VNPTContext : DbContext
    {
        public VNPTContext()
        {
        }

        public VNPTContext(DbContextOptions<VNPTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VNPT.Data.Models.Config> Config { get; set; }        
        public virtual DbSet<VNPT.Data.Models.Invoice> Invoice { get; set; }
        public virtual DbSet<VNPT.Data.Models.InvoiceProperty> InvoiceProperty { get; set; }
        public virtual DbSet<VNPT.Data.Models.Membership> Membership { get; set; }
        public virtual DbSet<VNPT.Data.Models.MembershipProperty> MembershipProperty { get; set; }
        public virtual DbSet<VNPT.Data.Models.PhieuYeuCau> PhieuYeuCau { get; set; }
        public virtual DbSet<VNPT.Data.Models.PhieuYeuCau_ThuocTinh> PhieuYeuCau_ThuocTinh { get; set; }
        public virtual DbSet<VNPT.Data.Models.Product> Product { get; set; }
        public virtual DbSet<VNPT.Data.Models.ProductConfig> ProductConfig { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(VNPT.Data.Helpers.AppGlobal.ConectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
