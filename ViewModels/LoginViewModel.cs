using System.ComponentModel.DataAnnotations;
namespace HomePet.ViewModels
{
    public class LoginViewModel
    {
         [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}