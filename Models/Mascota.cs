using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace HomePet.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }        
        [Required] 
        public string Edad { get; set; }
        [Required] 
        public string Sexo { get; set; }   
        [Required]      
        public string Tamano { get; set; }
        public float Peso { get; set; }
        [Required]    
        public string TipoPelo { get; set; }
        public string Foto { get; set; }
        [NotMapped]
        public IFormFile  photofile { get; set; }
        public string UserName { get; set; }
        public string exDueno { get; set; }
    }
}