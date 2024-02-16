using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class HistorialCurso
{
    public int HistorialId { get; set; }

    public int? UsuarioId { get; set; }

    public int? CursoId { get; set; }

    public DateTime? FechaVisualizacion { get; set; }

    public virtual Curso? Curso { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
