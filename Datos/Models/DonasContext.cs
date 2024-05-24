using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Datos.Models;

public partial class DonasContext : DbContext
{
    public DonasContext()
    {
    }

    public DonasContext(DbContextOptions<DonasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DonaCobertura> DonaCoberturas { get; set; }

    public virtual DbSet<DonaRelleno> DonaRellenos { get; set; }

    public virtual DbSet<DonaTamaño> DonaTamaños { get; set; }

    public virtual DbSet<DonaTipo> DonaTipos { get; set; }

    public virtual DbSet<DonaTopping> DonaToppings { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=happydonuts;user=laurac;password=Camila2011", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<DonaCobertura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dona_cobertura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioAdicional)
                .HasPrecision(5, 2)
                .HasColumnName("precio_adicional");
        });

        modelBuilder.Entity<DonaRelleno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dona_relleno");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioAdicional)
                .HasPrecision(5, 2)
                .HasColumnName("precio_adicional");
        });

        modelBuilder.Entity<DonaTamaño>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dona_tamaño");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioAdicional)
                .HasPrecision(5, 2)
                .HasColumnName("precio_adicional");
        });

        modelBuilder.Entity<DonaTipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dona_tipo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioBase)
                .HasPrecision(5, 2)
                .HasColumnName("precio_base");
        });

        modelBuilder.Entity<DonaTopping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dona_topping");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioAdicional)
                .HasPrecision(5, 2)
                .HasColumnName("precio_adicional");
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("transacciones");

            entity.HasIndex(e => e.CoberturaId, "cobertura_id");

            entity.HasIndex(e => e.RellenoId, "relleno_id");

            entity.HasIndex(e => e.TamanoId, "tamano_id");

            entity.HasIndex(e => e.TipoDonaId, "tipo_dona_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cambio)
                .HasPrecision(10, 2)
                .HasColumnName("cambio");
            entity.Property(e => e.CoberturaId).HasColumnName("cobertura_id");
            entity.Property(e => e.DineroIngresado)
                .HasPrecision(10, 2)
                .HasColumnName("dinero_ingresado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha");
            entity.Property(e => e.RellenoId).HasColumnName("relleno_id");
            entity.Property(e => e.TamanoId).HasColumnName("tamano_id");
            entity.Property(e => e.TipoDonaId).HasColumnName("tipo_dona_id");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Cobertura).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.CoberturaId)
                .HasConstraintName("transacciones_ibfk_4");

            entity.HasOne(d => d.Relleno).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.RellenoId)
                .HasConstraintName("transacciones_ibfk_3");

            entity.HasOne(d => d.Tamano).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.TamanoId)
                .HasConstraintName("transacciones_ibfk_2");

            entity.HasOne(d => d.TipoDona).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.TipoDonaId)
                .HasConstraintName("transacciones_ibfk_1");

            entity.HasMany(d => d.Toppings).WithMany(p => p.Transaccions)
                .UsingEntity<Dictionary<string, object>>(
                    "TransaccionTopping",
                    r => r.HasOne<DonaTopping>().WithMany()
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("transaccion_topping_ibfk_2"),
                    l => l.HasOne<Transaccione>().WithMany()
                        .HasForeignKey("TransaccionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("transaccion_topping_ibfk_1"),
                    j =>
                    {
                        j.HasKey("TransaccionId", "ToppingId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("transaccion_topping");
                        j.HasIndex(new[] { "ToppingId" }, "topping_id");
                        j.IndexerProperty<int>("TransaccionId").HasColumnName("transaccion_id");
                        j.IndexerProperty<int>("ToppingId").HasColumnName("topping_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
