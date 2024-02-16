using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Rating
{
    public int RatingId { get; set; }

    public int? CursoId { get; set; }

    public decimal? Rating1 { get; set; }

    public virtual Curso? Curso { get; set; }
}
