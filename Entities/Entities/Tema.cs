using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Tema
{
    public int TemaId { get; set; }

    public string NombreTema { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
