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
        public int EdadId { get; set; }    
        public Edad Edad { get; set; }
        [Required] 
        public string Sexo { get; set; }   
        [Required]
        public int TamanoId{ get; set; }  
        public Tamano Tamano { get; set; }
        public float Peso { get; set; }
        [Required]
        public int TipoPeloId { get; set; }
        public TipoPelo TipoPelo { get; set; }
        public string Foto { get; set; }
        [NotMapped]
        public IFormFile  photofile { get; set; }
    }
}