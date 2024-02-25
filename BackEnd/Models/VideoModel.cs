namespace BackEnd.Models
{
    public class VideoModel
    {
        public int VideoId { get; set; }

        public string Titulo { get; set; } = null!;

        public string Url { get; set; } = null!;

        public int? CursoId { get; set; }

    }
}
