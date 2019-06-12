using System.Collections.Generic;

namespace HomePet.Models
{
    public class Edad
    {
        public int Id { get; set; }
        public string NombreEdad { get; set; }
        public List<Mascota> MascotaEdad { get; set; }
    }
}