using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Curso
{
    public int CursoId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? DuracionHoras { get; set; }

    public virtual ICollection<HistorialCurso> HistorialCursos { get; set; } = new List<HistorialCurso>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();

    public virtual ICollection<Usuario> Estudiantes { get; set; } = new List<Usuario>();

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<Usuario> Profesors { get; set; } = new List<Usuario>();

    public virtual ICollection<Tema> Temas { get; set; } = new List<Tema>();
}
