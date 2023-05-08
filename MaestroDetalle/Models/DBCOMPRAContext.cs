using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MaestroDetalle.Models
{
    public partial class DBCOMPRAContext : DbContext
    {
        public DBCOMPRAContext()
        {
        }

        public DBCOMPRAContext(DbContextOptions<DBCOMPRAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-43STOG6C;Database=DBCOMPRA;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__COMPRA__0A5CDB5CA1D85A56");

                entity.ToTable("COMPRA");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra)
                    .HasName("PK__DETALLE___E046CCBBF8F51444");

                entity.ToTable("DETALLE_COMPRA");

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Producto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("FK_IdVenta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
