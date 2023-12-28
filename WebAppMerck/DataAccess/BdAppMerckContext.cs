using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAppMerck.Models.Entities;

namespace WebAppMerck.DataAccess;

public partial class BdAppMerckContext : DbContext
{
    public BdAppMerckContext()
    {
    }

    public BdAppMerckContext(DbContextOptions<BdAppMerckContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Localidad> Localidades { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }
    public virtual DbSet<Clinica> Clinicas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clinicas__3214EC0716015FE0");

            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Latitud).HasColumnType("decimal(10, 7)");
            entity.Property(e => e.Longitud).HasColumnType("decimal(10, 7)");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Provincia).HasMaxLength(255);
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Localidad__3213E83FF1A23E3D");

            entity.ToTable("Localidad");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");
            entity.Property(e => e.Localidades)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("localidades");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("FK__Localidad__id_pr__398D8EEE");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provincia__3213E83F1873CD31");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Provincias)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("provincias");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
