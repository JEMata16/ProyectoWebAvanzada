using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int? RolId { get; set; }

    public virtual ICollection<HistorialCurso> HistorialCursos { get; set; } = new List<HistorialCurso>();

    public virtual Role? Rol { get; set; }

    public virtual ICollection<SolicitudesInformacion> SolicitudesInformacions { get; set; } = new List<SolicitudesInformacion>();

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual ICollection<Curso> CursosNavigation { get; set; } = new List<Curso>();
}
