using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Evento
{
    public int EventoId { get; set; }

    public string NombreEvento { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual ICollection<SolicitudesInformacion> SolicitudesInformacions { get; set; } = new List<SolicitudesInformacion>();

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
