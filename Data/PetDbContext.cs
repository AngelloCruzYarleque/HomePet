using HomePet.Models;
using Microsoft.EntityFrameworkCore;

namespace HomePet.Data
{
    public class PetDbContext : DbContext
    {
        public DbSet<Mascota> Mascotas { get; set; }
        public PetDbContext(DbContextOptions<PetDbContext> o) : base(o) {

        }
    }
}