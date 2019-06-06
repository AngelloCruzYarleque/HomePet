using System.ComponentModel.DataAnnotations;

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
        public string Tamano{ get; set; }  
        public float Peso { get; set; }
        [Required]
        public string TipoPelo { get; set; }
        public string Foto { get; set; }
    }
}