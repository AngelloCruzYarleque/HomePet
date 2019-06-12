using System.ComponentModel.DataAnnotations;
namespace HomePet.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        [Required]
        public string Mensaje { get; set; }

        [Required]
        public int TipoContacto { get; set; }
        
    }
}