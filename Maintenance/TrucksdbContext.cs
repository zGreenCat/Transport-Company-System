using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Maintenance;

public partial class TrucksdbContext : DbContext
{
    public TrucksdbContext()
    {
    }

    public TrucksdbContext(DbContextOptions<TrucksdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SuppRegister> SuppRegisters { get; set; }

    public virtual DbSet<TravelRegister> TravelRegisters { get; set; }

    public virtual DbSet<Truck> Trucks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=trucksdb;uid=root;pwd=root123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<SuppRegister>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("supp_register");

            entity.HasIndex(e => e.TruckId, "truck_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.TruckId).HasColumnName("truck_id");

            entity.HasOne(d => d.Truck).WithMany(p => p.SuppRegisters)
                .HasForeignKey(d => d.TruckId)
                .HasConstraintName("supp_register_ibfk_1");
        });

        modelBuilder.Entity<TravelRegister>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("travel_register");

            entity.HasIndex(e => e.IdTruck, "id_truck");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Destination)
                .HasMaxLength(150)
                .HasColumnName("destination");
            entity.Property(e => e.IdTruck).HasColumnName("id_truck");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.IdTruckNavigation).WithMany(p => p.TravelRegisters)
                .HasForeignKey(d => d.IdTruck)
                .HasConstraintName("travel_register_ibfk_1");
        });

        modelBuilder.Entity<Truck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("truck");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .HasColumnName("brand");
            entity.Property(e => e.Mileage).HasColumnName("mileage");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Year)
                .HasColumnType("year")
                .HasColumnName("year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
