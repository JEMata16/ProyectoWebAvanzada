namespace BackEnd.Models
{
    public class HistorialCursoModel
    {
        public int HistorialId { get; set; }

        public int? UsuarioId { get; set; }

        public int? CursoId { get; set; }

        public DateTime? FechaVisualizacion { get; set; }

    }
}
