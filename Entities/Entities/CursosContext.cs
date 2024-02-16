using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class CursosContext : DbContext
{
    public CursosContext()
    {
    }

    public CursosContext(DbContextOptions<CursosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<HistorialCurso> HistorialCursos { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SolicitudesInformacion> SolicitudesInformacions { get; set; }

    public virtual DbSet<Tema> Temas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MR1I6VLI\\SQLEXPRESS;Database=Cursos;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E023A37BB185F80");

            entity.Property(e => e.CursoId)
                .ValueGeneratedNever()
                .HasColumnName("CursoID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.Eventos).WithMany(p => p.Cursos)
                .UsingEntity<Dictionary<string, object>>(
                    "CursosEvento",
                    r => r.HasOne<Evento>().WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CursosEve__Event__5BE2A6F2"),
                    l => l.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CursosEve__Curso__5AEE82B9"),
                    j =>
                    {
                        j.HasKey("CursoId", "EventoId").HasName("PK__CursosEv__7FEC8FA7CE60621C");
                        j.ToTable("CursosEventos");
                        j.IndexerProperty<int>("CursoId").HasColumnName("CursoID");
                        j.IndexerProperty<int>("EventoId").HasColumnName("EventoID");
                    });

            entity.HasMany(d => d.Temas).WithMany(p => p.Cursos)
                .UsingEntity<Dictionary<string, object>>(
                    "CursosTema",
                    r => r.HasOne<Tema>().WithMany()
                        .HasForeignKey("TemaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CursosTem__TemaI__440B1D61"),
                    l => l.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CursosTem__Curso__4316F928"),
                    j =>
                    {
                        j.HasKey("CursoId", "TemaId").HasName("PK__CursosTe__05F2145A3441CF23");
                        j.ToTable("CursosTemas");
                        j.IndexerProperty<int>("CursoId").HasColumnName("CursoID");
                        j.IndexerProperty<int>("TemaId").HasColumnName("TemaID");
                    });
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Eventos__1EEB59017831CA72");

            entity.Property(e => e.EventoId)
                .ValueGeneratedNever()
                .HasColumnName("EventoID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.NombreEvento)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialCurso>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__975206EF38068B15");

            entity.Property(e => e.HistorialId)
                .ValueGeneratedNever()
                .HasColumnName("HistorialID");
            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.FechaVisualizacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Curso).WithMany(p => p.HistorialCursos)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__Historial__Curso__5070F446");

            entity.HasOne(d => d.Usuario).WithMany(p => p.HistorialCursos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Historial__Usuar__4F7CD00D");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__Ratings__FCCDF85CD62435D6");

            entity.Property(e => e.RatingId)
                .ValueGeneratedNever()
                .HasColumnName("RatingID");
            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.Rating1)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("Rating");

            entity.HasOne(d => d.Curso).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__Ratings__CursoID__403A8C7D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D111CBC721");

            entity.Property(e => e.RolId)
                .ValueGeneratedNever()
                .HasColumnName("RolID");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SolicitudesInformacion>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DA7142AD334");

            entity.ToTable("SolicitudesInformacion");

            entity.Property(e => e.SolicitudId)
                .ValueGeneratedNever()
                .HasColumnName("SolicitudID");
            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.EventoId).HasColumnName("EventoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Evento).WithMany(p => p.SolicitudesInformacions)
                .HasForeignKey(d => d.EventoId)
                .HasConstraintName("FK__Solicitud__Event__4CA06362");

            entity.HasOne(d => d.Usuario).WithMany(p => p.SolicitudesInformacions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Solicitud__Usuar__4BAC3F29");
        });

        modelBuilder.Entity<Tema>(entity =>
        {
            entity.HasKey(e => e.TemaId).HasName("PK__Temas__BF02E6D6ECA280E6");

            entity.Property(e => e.TemaId)
                .ValueGeneratedNever()
                .HasColumnName("TemaID");
            entity.Property(e => e.NombreTema)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE798F4CCBAFD");

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("UsuarioID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Usuarios__RolID__398D8EEE");

            entity.HasMany(d => d.Cursos).WithMany(p => p.Estudiantes)
                .UsingEntity<Dictionary<string, object>>(
                    "EstudiantesCurso",
                    r => r.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Estudiant__Curso__5812160E"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Estudiant__Estud__571DF1D5"),
                    j =>
                    {
                        j.HasKey("EstudianteId", "CursoId").HasName("PK__Estudian__0896A09BCBBBA417");
                        j.ToTable("EstudiantesCursos");
                        j.IndexerProperty<int>("EstudianteId").HasColumnName("EstudianteID");
                        j.IndexerProperty<int>("CursoId").HasColumnName("CursoID");
                    });

            entity.HasMany(d => d.CursosNavigation).WithMany(p => p.Profesors)
                .UsingEntity<Dictionary<string, object>>(
                    "ProfesoresCurso",
                    r => r.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Profesore__Curso__5441852A"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Profesore__Profe__534D60F1"),
                    j =>
                    {
                        j.HasKey("ProfesorId", "CursoId").HasName("PK__Profesor__2A13D38BBB1C0501");
                        j.ToTable("ProfesoresCursos");
                        j.IndexerProperty<int>("ProfesorId").HasColumnName("ProfesorID");
                        j.IndexerProperty<int>("CursoId").HasColumnName("CursoID");
                    });
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.VideoId).HasName("PK__Videos__BAE5124AAEA5B190");

            entity.Property(e => e.VideoId)
                .ValueGeneratedNever()
                .HasColumnName("VideoID");
            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("URL");

            entity.HasOne(d => d.Curso).WithMany(p => p.Videos)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__Videos__CursoID__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
