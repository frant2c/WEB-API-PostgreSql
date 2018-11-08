using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestWebApi
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }
        public virtual DbSet<SizeGuide> SizeGuide { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=Shop;Username=postgres;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("char");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Size).HasColumnName("size");
            });

            modelBuilder.Entity<Purchases>(entity =>
            {
                entity.HasKey(e => e.PurchaseId);

                entity.ToTable("purchases");

                entity.Property(e => e.PurchaseId)
                    .HasColumnName("purchase_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customer_name")
                    .HasColumnType("character(12)");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Purchase)
                    .WithOne(p => p.Purchases)
                    .HasForeignKey<Purchases>(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prod_id_to_purchases");
            });

            modelBuilder.Entity<SizeGuide>(entity =>
            {
                entity.HasKey(e => e.Russia);

                entity.ToTable("size guide");

                entity.Property(e => e.Us).HasColumnName("US");
            });
        }
    }
}
