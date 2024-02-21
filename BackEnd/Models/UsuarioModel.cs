using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public string CorreoElectronico { get; set; } = null!;
        [Required]
        public string Contraseña { get; set; } = null!;

        public int? RolId { get; set; }
        public UsuarioModel()
        {
            RolId = 2;
        }
    }
}
