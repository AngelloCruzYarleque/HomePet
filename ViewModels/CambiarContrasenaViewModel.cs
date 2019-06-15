using System.ComponentModel.DataAnnotations;

namespace HomePet.ViewModels
{
    public class CambiarContrasenaViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string ContrasenaActual { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ContrasenaNueva { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("ContrasenaNueva", ErrorMessage = "Las contraseñas no coinciden")]
        public string ContrasenaConfirmacion { get; set; }
    }
}