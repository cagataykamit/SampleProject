using System;
using System.Collections.Generic;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public partial class StockContext : DbContext
{
    public StockContext()
    {
    }

    public StockContext(DbContextOptions<StockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AmountType> AmountTypes { get; set; }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<CurrencyType> CurrencyTypes { get; set; }

    public virtual DbSet<Shelf> Shelfs { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StockType> StockTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StockDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AmountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AmountType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cabinet");

            entity.Property(e => e.Code).HasMaxLength(50);

            entity.HasOne(d => d.IdShelfNavigation).WithMany(p => p.Cabinets)
                .HasForeignKey(d => d.IdShelf)
                .HasConstraintName("FK__Cabinet__IdShelf__4E88ABD4");
        });

        modelBuilder.Entity<CurrencyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CurrencyType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Shelf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Shelf");

            entity.Property(e => e.Code).HasMaxLength(50);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Stock");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StockCode).HasMaxLength(100);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdAmountTypeNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IdAmountType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock__IdAmountT__4BAC3F29");

            entity.HasOne(d => d.IdCurrencyTypePurchaseNavigation).WithMany(p => p.StockIdCurrencyTypePurchaseNavigations)
                .HasForeignKey(d => d.IdCurrencyTypePurchase)
                .HasConstraintName("FK__Stock__IdCurrenc__4CA06362");

            entity.HasOne(d => d.IdCurrencyTypeSaleNavigation).WithMany(p => p.StockIdCurrencyTypeSaleNavigations)
                .HasForeignKey(d => d.IdCurrencyTypeSale)
                .HasConstraintName("FK__Stock__IdCurrenc__4D94879B");

            entity.HasOne(d => d.IdStockTypeNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IdStockType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stock_StockType");
        });

        modelBuilder.Entity<StockType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StockType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
