using System.Collections.Generic;

namespace HomePet.Models
{
    public class Tamano
    {
        public int Id { get; set; }
        public string NombreTamano { get; set; }
        public List<Mascota> MascotaTamano { get; set; }
    }
}