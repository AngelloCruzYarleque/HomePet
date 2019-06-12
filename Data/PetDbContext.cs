using HomePet.Models;
using Microsoft.EntityFrameworkCore;

namespace HomePet.Data
{
    public class PetDbContext : DbContext
    {
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Edad> MascotaEdad { get; set; }
        public DbSet<Tamano> MascotaTamano { get; set; }
        public DbSet<TipoPelo> MascotaTipoPelo { get; set; }
        public PetDbContext(DbContextOptions<PetDbContext> o) : base(o) {

        }
    }
}