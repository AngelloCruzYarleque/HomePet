using System.ComponentModel.DataAnnotations;
namespace HomePet.ViewModels
{
    public class RegistroViewModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}