using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PostgresDb.Models;

namespace PostgresDb.Data;

public partial class ServiceForOrderingCoalContext : DbContext
{
    public ServiceForOrderingCoalContext()
    {
    }

    public ServiceForOrderingCoalContext(DbContextOptions<ServiceForOrderingCoalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Addre> Addres { get; set; }

    public virtual DbSet<AddresClient> AddresClients { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<CoalType> CoalTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=service_for_ordering_coal;Username=postgres;Password=njvfnkj[");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Addre>(entity =>
        {
            entity.HasKey(e => e.AddresId).HasName("addres_pkey");

            entity.ToTable("addres");

            entity.Property(e => e.AddresId)
                .ValueGeneratedNever()
                .HasColumnName("addres_id");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Name).HasColumnName("name_");
        });

        modelBuilder.Entity<AddresClient>(entity =>
        {
            entity.HasKey(e => e.AddresClientsId).HasName("addres_clients_pkey");

            entity.ToTable("addres_clients");

            entity.Property(e => e.AddresClientsId)
                .ValueGeneratedNever()
                .HasColumnName("addres_clients_id");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Name).HasColumnName("name_");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientsId).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.ClientsId)
                .ValueGeneratedNever()
                .HasColumnName("clients_id");
            entity.Property(e => e.FkAddres).HasColumnName("fk_addres");
            entity.Property(e => e.FkAddresClients).HasColumnName("fk_addres_clients");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.Name).HasColumnName("name_");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasColumnName("phone");

            entity.HasOne(d => d.FkAddresNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.FkAddres)
                .HasConstraintName("clients_fk_addres_fkey");

            entity.HasOne(d => d.FkAddresClientsNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.FkAddresClients)
                .HasConstraintName("clients_fk_addres_clients_fkey");
        });

        modelBuilder.Entity<CoalType>(entity =>
        {
            entity.HasKey(e => e.CoalTypeId).HasName("coal_type_pkey");

            entity.ToTable("coal_type");

            entity.Property(e => e.CoalTypeId)
                .ValueGeneratedNever()
                .HasColumnName("coal_type_id");
            entity.Property(e => e.Abbreviation).HasColumnName("abbreviation");
            entity.Property(e => e.FullAbbreviation).HasColumnName("full_abbreviation");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order__pkey");

            entity.ToTable("order_");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.Date).HasColumnName("date_");
            entity.Property(e => e.FkClients).HasColumnName("fk_clients");
            entity.Property(e => e.FkPrice).HasColumnName("fk_price");
            entity.Property(e => e.FullPrice).HasColumnName("full_price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.FkClientsNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkClients)
                .HasConstraintName("order__fk_clients_fkey");

            entity.HasOne(d => d.FkPriceNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkPrice)
                .HasConstraintName("order__fk_price_fkey");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("price_pkey");

            entity.ToTable("price");

            entity.Property(e => e.PriceId)
                .ValueGeneratedNever()
                .HasColumnName("price_id");
            entity.Property(e => e.Cost).HasColumnName("cost_");
            entity.Property(e => e.FkProvider).HasColumnName("fk_provider");

            entity.HasOne(d => d.FkProviderNavigation).WithMany(p => p.Prices)
                .HasForeignKey(d => d.FkProvider)
                .HasConstraintName("price_fk_provider_fkey");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("provider_pkey");

            entity.ToTable("provider");

            entity.Property(e => e.ProviderId)
                .ValueGeneratedNever()
                .HasColumnName("provider_id");
            entity.Property(e => e.FkAddres).HasColumnName("fk_addres");
            entity.Property(e => e.FkCoalType).HasColumnName("fk_coal_type");
            entity.Property(e => e.Name).HasColumnName("name_");

            entity.HasOne(d => d.FkAddresNavigation).WithMany(p => p.Providers)
                .HasForeignKey(d => d.FkAddres)
                .HasConstraintName("provider_fk_addres_fkey");

            entity.HasOne(d => d.FkCoalTypeNavigation).WithMany(p => p.Providers)
                .HasForeignKey(d => d.FkCoalType)
                .HasConstraintName("provider_fk_coal_type_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
