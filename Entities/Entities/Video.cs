using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Video
{
    public int VideoId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int? CursoId { get; set; }

    public virtual Curso? Curso { get; set; }
}
