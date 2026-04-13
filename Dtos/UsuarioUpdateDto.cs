using System.ComponentModel.DataAnnotations;

namespace SisColegio.Dtos
{
    public class UsuarioUpdateDto
    {
        [Required] public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Clave { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Rol { get; set; } = string.Empty;
    }

}
