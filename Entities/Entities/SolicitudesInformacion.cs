using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class SolicitudesInformacion
{
    public int SolicitudId { get; set; }

    public int? UsuarioId { get; set; }

    public int? EventoId { get; set; }

    public string? Comentario { get; set; }

    public virtual Evento? Evento { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
