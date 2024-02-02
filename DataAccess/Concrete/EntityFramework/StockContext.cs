using System;
using System.Collections.Generic;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public partial class StockContext : DbContext
{
    public StockContext()
    {
    }

    public StockContext(DbContextOptions<StockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<CurrencyType> CurrencyTypes { get; set; }

    public virtual DbSet<QuantityUnit> QuantityUnits { get; set; }

    public virtual DbSet<Shelf> Shelfs { get; set; }

    public virtual DbSet<StockClass> StockClasses { get; set; }

    public virtual DbSet<StockList> StockLists { get; set; }

    public virtual DbSet<StockType> StockTypes { get; set; }

    public virtual DbSet<StockUnit> StockUnits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StockDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<QuantityUnit>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Shelf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Shelf");

            entity.Property(e => e.Code).HasMaxLength(50);
        });

        modelBuilder.Entity<StockClass>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StockList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StockOperations");

            entity.HasOne(d => d.IdCabinetNavigation).WithMany(p => p.StockLists)
                .HasForeignKey(d => d.IdCabinet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockLists_Cabinets");

            entity.HasOne(d => d.IdShelfNavigation).WithMany(p => p.StockLists)
                .HasForeignKey(d => d.IdShelf)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockLists_Shelfs");

            entity.HasOne(d => d.IdStockClassNavigation).WithMany(p => p.StockLists)
                .HasForeignKey(d => d.IdStockClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockLists_StockClasses");

            entity.HasOne(d => d.IdStockTypeNavigation).WithMany(p => p.StockLists)
                .HasForeignKey(d => d.IdStockType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockLists_StockTypes");

            entity.HasOne(d => d.IdStockUnitNavigation).WithMany(p => p.StockLists)
                .HasForeignKey(d => d.IdStockUnit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockLists_StockUnits");
        });

        modelBuilder.Entity<StockType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StockType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<StockUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Stock");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StockCode).HasMaxLength(100);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdCurrencyTypePurchaseNavigation).WithMany(p => p.StockUnitIdCurrencyTypePurchaseNavigations)
                .HasForeignKey(d => d.IdCurrencyTypePurchase)
                .HasConstraintName("FK_StockUnits_CurrencyTypes");

            entity.HasOne(d => d.IdCurrencyTypeSaleNavigation).WithMany(p => p.StockUnitIdCurrencyTypeSaleNavigations)
                .HasForeignKey(d => d.IdCurrencyTypeSale)
                .HasConstraintName("FK_StockUnits_CurrencyTypes1");

            entity.HasOne(d => d.IdQuantityUnitNavigation).WithMany(p => p.StockUnits)
                .HasForeignKey(d => d.IdQuantityUnit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockUnits_QuantityUnits1");

            entity.HasOne(d => d.IdStockTypeNavigation).WithMany(p => p.StockUnits)
                .HasForeignKey(d => d.IdStockType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stock_StockType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
