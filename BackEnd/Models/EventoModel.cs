namespace BackEnd.Models
{
    public class EventoModel
    {
        public int EventoId { get; set; }

        public string NombreEvento { get; set; } = null!;

        public string? Descripcion { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }
    }
}
