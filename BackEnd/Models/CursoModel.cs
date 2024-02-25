namespace BackEnd.Models
{
    public class CursoModel
    {
        public int CursoId { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? DuracionHoras { get; set; }
    }
}
