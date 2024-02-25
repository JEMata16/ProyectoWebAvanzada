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
        => optionsBuilder.UseSqlServer("Server=YARI\\SQLEXPRESS;Database=Cursos;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E023A37B1B0B793");

            entity.Property(e => e.CursoId).HasColumnName("CursoID");
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
                        .HasConstraintName("FK__CursosEve__Event__6E01572D"),
                    l => l.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CursosEve__Curso__6D0D32F4"),
                    j =>
                    {
                        j.HasKey("CursoId", "EventoId").HasName("PK__CursosEv__7FEC8FA789CF3DBC");
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
                        .HasConstraintName("FK__CursosTem__TemaI__5629CD9C"),
                    l => l.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CursosTem__Curso__5535A963"),
                    j =>
                    {
                        j.HasKey("CursoId", "TemaId").HasName("PK__CursosTe__05F2145AB9CB6785");
                        j.ToTable("CursosTemas");
                        j.IndexerProperty<int>("CursoId")
                            .ValueGeneratedOnAdd()
                            .HasColumnName("CursoID");
                        j.IndexerProperty<int>("TemaId").HasColumnName("TemaID");
                    });
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Eventos__1EEB5901D08965C4");

            entity.Property(e => e.EventoId).HasColumnName("EventoID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.NombreEvento)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialCurso>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__975206EF65CE2BCC");

            entity.Property(e => e.HistorialId).HasColumnName("HistorialID");
            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.FechaVisualizacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Curso).WithMany(p => p.HistorialCursos)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__Historial__Curso__628FA481");

            entity.HasOne(d => d.Usuario).WithMany(p => p.HistorialCursos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Historial__Usuar__619B8048");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__Ratings__FCCDF85C7E0CF978");

            entity.Property(e => e.RatingId).HasColumnName("RatingID");
            entity.Property(e => e.CursoId).HasColumnName("CursoID");
            entity.Property(e => e.Rating1)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("Rating");

            entity.HasOne(d => d.Curso).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__Ratings__CursoID__52593CB8");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D13D09FF7C");

            entity.Property(e => e.RolId)
                .ValueGeneratedNever()
                .HasColumnName("RolID");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SolicitudesInformacion>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DA7D2E58BB3");

            entity.ToTable("SolicitudesInformacion");

            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");
            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.EventoId).HasColumnName("EventoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Evento).WithMany(p => p.SolicitudesInformacions)
                .HasForeignKey(d => d.EventoId)
                .HasConstraintName("FK__Solicitud__Event__5EBF139D");

            entity.HasOne(d => d.Usuario).WithMany(p => p.SolicitudesInformacions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Solicitud__Usuar__5DCAEF64");
        });

        modelBuilder.Entity<Tema>(entity =>
        {
            entity.HasKey(e => e.TemaId).HasName("PK__Temas__BF02E6D6C1EF2D3E");

            entity.Property(e => e.TemaId).HasColumnName("TemaID");
            entity.Property(e => e.NombreTema)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7985771E362");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
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
                .HasConstraintName("FK__Usuarios__RolID__4BAC3F29");

            entity.HasMany(d => d.Cursos).WithMany(p => p.Estudiantes)
                .UsingEntity<Dictionary<string, object>>(
                    "EstudiantesCurso",
                    r => r.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Estudiant__Curso__6A30C649"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Estudiant__Estud__693CA210"),
                    j =>
                    {
                        j.HasKey("EstudianteId", "CursoId").HasName("PK__Estudian__0896A09B76A3C3E4");
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
                        .HasConstraintName("FK__Profesore__Curso__66603565"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Profesore__Profe__656C112C"),
                    j =>
                    {
                        j.HasKey("ProfesorId", "CursoId").HasName("PK__Profesor__2A13D38B91B3EA4A");
                        j.ToTable("ProfesoresCursos");
                        j.IndexerProperty<int>("ProfesorId").HasColumnName("ProfesorID");
                        j.IndexerProperty<int>("CursoId").HasColumnName("CursoID");
                    });
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.VideoId).HasName("PK__Videos__BAE5124A1FB7DA60");

            entity.Property(e => e.VideoId).HasColumnName("VideoID");
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
                .HasConstraintName("FK__Videos__CursoID__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}