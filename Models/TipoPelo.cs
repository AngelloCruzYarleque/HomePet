using System.Collections.Generic;

namespace HomePet.Models
{
    public class TipoPelo
    {
        public int Id { get; set; }
        public string NombreTipoPelo { get; set; }
        public List<Mascota> MascotaTipoPelo { get; set; }
    }
}