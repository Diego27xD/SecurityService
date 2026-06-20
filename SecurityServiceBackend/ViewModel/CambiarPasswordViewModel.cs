using System.ComponentModel.DataAnnotations;

namespace SecurityServiceBackend.ViewModel
{
    public class CambiarPasswordViewModel
    {
        [Required(ErrorMessage = "Ingresa tu contraseña actual")]
        [DataType(DataType.Password)]
        public string PasswordActual { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingresa la nueva contraseña")]
        [MinLength(8, ErrorMessage = "Debe tener al menos 8 caracteres")]
        [DataType(DataType.Password)]
        public string PasswordNueva { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirma la nueva contraseña")]
        [DataType(DataType.Password)]
        [Compare(nameof(PasswordNueva), ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarPassword { get; set; } = string.Empty;
    }
}
