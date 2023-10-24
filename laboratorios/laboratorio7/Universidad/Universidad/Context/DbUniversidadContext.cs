using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Universidad.Models;

namespace Universidad.Context;

public partial class DbUniversidadContext : DbContext
{
    public DbUniversidadContext()
    {
    }

    public DbUniversidadContext(DbContextOptions<DbUniversidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistente> Asistentes { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Comision> Comisions { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Escuela> Escuelas { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Facultad> Facultads { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Investigacion> Investigacions { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TRESOL-PC\\SQLEXPRESS;Initial Catalog=DB_Universidad;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;");

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
            entity.HasOne(d => d.CodEscuelaNavigation).WithMany(p => p.Carreras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carrera__CodEscu__5CD6CB2B");
        });


        modelBuilder.Entity<Escuela>(entity =>
        {
            entity.HasOne(d => d.CodFacultadNavigation).WithMany(p => p.Escuelas)
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

            entity.HasOne(d => d.CedAsistNavigation).WithMany(p => p.Grupos).HasConstraintName("FK_Grupo_Asist");

            entity.HasOne(d => d.CedProfNavigation).WithMany(p => p.Grupos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grupo_Prof");

            entity.HasOne(d => d.SiglaCursoNavigation).WithMany(p => p.Grupos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grupo_Curso");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.Property(e => e.Cedula).IsFixedLength();
            entity.Property(e => e.Sexo).IsFixedLength();
            entity.Property(e => e.Teléfono).IsFixedLength();
        });
        // basado en https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?source=recommendations&tabs=vs
        // Configuración entre `Curso` y `Carrera`:
        modelBuilder.Entity<Curso>()
            .HasMany(c => c.Carreras) // La entidad `Curso` tiene muchas `Carreras`.
            .WithMany(ca => ca.Cursos) // La entidad `Carrera` tiene muchos `Cursos`.
            .UsingEntity<Dictionary<string, object>>(
                "Pertenece_a", // Nombre de la tabla de unión.
                l => l.HasOne<Carrera>().WithMany().HasForeignKey("CodCarrera"), // En la tabla `Pertenece_a`, hay una clave externa `CodCarrera` que referencia a `Carrera`.
                r => r.HasOne<Curso>().WithMany().HasForeignKey("SiglaCurso"),  // En la tabla `Pertenece_a`, hay una clave externa `SiglaCurso` que referencia a `Curso`.
                j =>
                {
                    j.HasKey("SiglaCurso", "CodCarrera");  // La tabla tiene una clave compuesta: `SiglaCurso` y `CodCarrera`.
                    j.Property<byte?>("NivelPlanEstudios");  // Propiedad opcional `NivelPlanEstudios`.
                    j.ToTable("Pertenece_a");  // Confirmación del nombre de la tabla de unión.
                });

        // Configuración entre `Estudiante` y `Carrera`:
        modelBuilder.Entity<Estudiante>()
            .HasMany(e => e.Carreras) // La entidad `Estudiante` tiene muchas `Carreras`.
            .WithMany(c => c.Estudiantes) // La entidad `Carrera` tiene muchos `Estudiantes`.
            .UsingEntity<Dictionary<string, object>>(
                "Empadronado_en", // Nombre de la tabla de unión.
                l => l.HasOne<Carrera>().WithMany().HasForeignKey("CodCarrera"), // En la tabla `Empadronado_en`, hay una clave externa `CodCarrera` que referencia a `Carrera`.
                r => r.HasOne<Estudiante>().WithMany().HasForeignKey("CedEstudiante"), // En la tabla `Empadronado_en`, hay una clave externa `CedEstudiante` que referencia a `Estudiante`.
                j =>
                {
                    j.HasKey("CedEstudiante", "CodCarrera");  // La tabla tiene una clave compuesta: `CedEstudiante` y `CodCarrera`.

                    // Detalles adicionales para la tabla `Empadronado_en`:
                    j.Property<string>("CedEstudiante").HasColumnType("char(10)").IsRequired(); // `CedEstudiante` es una columna obligatoria de tipo `char(10)`.
                    j.Property<string>("CodCarrera").HasColumnType("varchar(10)").IsRequired(); // `CodCarrera` es una columna obligatoria de tipo `varchar(10)`.
                    j.Property<DateTime?>("FechaIngreso").HasColumnType("date");  // Columna opcional `FechaIngreso` de tipo `date`.
                    j.Property<DateTime>("FechaGraduacion").HasColumnType("date").IsRequired();  // Columna obligatoria `FechaGraduacion` de tipo `date`.
                });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
