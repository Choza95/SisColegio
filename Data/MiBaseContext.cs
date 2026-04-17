using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SisColegio.Models;

namespace SisColegio.Data;

public partial class MiBaseContext : DbContext
{
    public MiBaseContext()
    {
    }

     public MiBaseContext(DbContextOptions<MiBaseContext> options)
    : base(options)
    {
    }

    public virtual DbSet<Asignacione> Asignaciones { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Disciplina> Disciplinas { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Evaluacione> Evaluaciones { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }

    public virtual DbSet<Padre> Padres { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    public virtual DbSet<Trimestre> Trimestres { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Asignaci__3214EC078EA2383D");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__Asignacio__IdCur__45F365D3");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__Asignacio__IdMat__44FF419A");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("FK__Asignacio__IdPro__440B1D61");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cursos__3214EC07B142591F");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Disciplina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discipli__3214EC073AC5158D");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAsignacionNavigation).WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.IdAsignacion)
                .HasConstraintName("FK__Disciplin__IdAsi__60A75C0F");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK__Disciplin__IdEst__5FB337D6");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC070FE426DB");

            entity.HasIndex(e => e.IdUsuario, "UQ__Estudian__5B65BF96134DD949").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Ci)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPadreNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdPadre)
                .HasConstraintName("FK__Estudiant__IdPad__37A5467C");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Estudiante)
                .HasForeignKey<Estudiante>(d => d.IdUsuario)
                .HasConstraintName("FK__Estudiant__IdUsu__36B12243");
        });

        modelBuilder.Entity<Evaluacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evaluaci__3214EC074CE0B0BE");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAsignacionNavigation).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdAsignacion)
                .HasConstraintName("FK__Evaluacio__IdAsi__5441852A");

            entity.HasOne(d => d.IdTrimestreNavigation).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdTrimestre)
                .HasConstraintName("FK__Evaluacio__IdTri__5535A963");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inscripc__3214EC07372D2144");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__Inscripci__IdCur__4BAC3F29");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK__Inscripci__IdEst__4AB81AF0");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materias__3214EC0782D14F78");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notas__3214EC0713A90A31");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nota1)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Nota");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK__Notas__IdEstudia__59FA5E80");

            entity.HasOne(d => d.IdEvaluacionNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdEvaluacion)
                .HasConstraintName("FK__Notas__IdEvaluac__5AEE82B9");
        });

        modelBuilder.Entity<Padre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Padres__3214EC070654A83A");

            entity.HasIndex(e => e.IdUsuario, "UQ__Padres__5B65BF96757DD8C5").IsUnique();

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Ci)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Padre)
                .HasForeignKey<Padre>(d => d.IdUsuario)
                .HasConstraintName("FK__Padres__IdUsuari__2B3F6F97");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3214EC079B2A5ABE");

            entity.HasIndex(e => e.IdUsuario, "UQ__Profesor__5B65BF9612C2DEAD").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Ci)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Profesore)
                .HasForeignKey<Profesore>(d => d.IdUsuario)
                .HasConstraintName("FK__Profesore__IdUsu__30F848ED");
        });

        modelBuilder.Entity<Trimestre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trimestr__3214EC07914E8A71");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07CE0F5CDA");

            entity.Property(e => e.Borrado).HasDefaultValue(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
