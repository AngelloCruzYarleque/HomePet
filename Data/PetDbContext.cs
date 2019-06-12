using HomePet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HomePet.Data
{
    public class PetDbContext : IdentityDbContext
    {
        public DbSet<Mascota> Mascotas { get; set; }        
        public PetDbContext(DbContextOptions<PetDbContext> o) : base(o) {

        }
    }
}