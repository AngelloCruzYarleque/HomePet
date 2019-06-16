using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace HomePet.Models
{
    public class TipoMascota
    {
         public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}