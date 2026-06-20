using System.ComponentModel.DataAnnotations;

namespace SecurityServiceBackend.ViewModel
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;
    }
}
