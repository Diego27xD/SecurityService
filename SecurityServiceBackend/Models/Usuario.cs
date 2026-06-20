using System.ComponentModel.DataAnnotations;

namespace SecurityServiceBackend.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // true mientras el usuario tenga la contraseña genérica asignada en el registro
        public bool RequiereCambioPassword { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
