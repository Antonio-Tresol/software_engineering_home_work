﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models;

public partial class DB_UniversidadContext : DbContext
{
    public DB_UniversidadContext(DbContextOptions<DB_UniversidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistente> Asistente { get; set; }

    public virtual DbSet<Carrera> Carrera { get; set; }

    public virtual DbSet<Comision> Comision { get; set; }

    public virtual DbSet<Curso> Curso { get; set; }

    public virtual DbSet<Escuela> Escuela { get; set; }

    public virtual DbSet<Estudiante> Estudiante { get; set; }

    public virtual DbSet<Facultad> Facultad { get; set; }

    public virtual DbSet<Grupo> Grupo { get; set; }

    public virtual DbSet<Investigacion> Investigacion { get; set; }

    public virtual DbSet<Profesor> Profesor { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistente>(entity =>
        {
            entity.Property(e => e.Cedula).IsFixedLength();

            entity.HasOne(d => d.CedulaNavigation).WithOne(p => p.Asistente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asist_Est");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasOne(d => d.CodEscuelaNavigation).WithMany(p => p.Carrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carrera__CodEscu__5CD6CB2B");
        });

        modelBuilder.Entity<Escuela>(entity =>
        {
            entity.HasOne(d => d.CodFacultadNavigation).WithMany(p => p.Escuela)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Escuela__CodFacu__5FB337D6");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.Property(e => e.Cedula).IsFixedLength();
            entity.Property(e => e.Estado).HasDefaultValueSql("('Activo')");
            entity.Property(e => e.Sexo).IsFixedLength();
            entity.Property(e => e.Teléfono).IsFixedLength();
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.Property(e => e.CedAsist).IsFixedLength();
            entity.Property(e => e.CedProf).IsFixedLength();

            entity.HasOne(d => d.CedAsistNavigation).WithMany(p => p.Grupo).HasConstraintName("FK_Grupo_Asist");

            entity.HasOne(d => d.CedProfNavigation).WithMany(p => p.Grupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grupo_Prof");

            entity.HasOne(d => d.SiglaCursoNavigation).WithMany(p => p.Grupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grupo_Curso");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.Property(e => e.Cedula).IsFixedLength();
            entity.Property(e => e.Sexo).IsFixedLength();
            entity.Property(e => e.Teléfono).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}