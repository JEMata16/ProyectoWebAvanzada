namespace BackEnd.Models
{
    public class SolicitudInfoModel
    {
        public int SolicitudId { get; set; }

        public int? UsuarioId { get; set; }

        public int? EventoId { get; set; }

        public string? Comentario { get; set; }

    }
}
