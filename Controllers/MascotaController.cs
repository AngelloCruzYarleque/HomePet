using HomePet.Data;
using HomePet.Models;
using Microsoft.AspNetCore.Mvc;


namespace HomePet.Controllers
{
    public class MascotaController : Controller
    {
        private PetDbContext _context;
        public MascotaController(PetDbContext c) {
            this._context = c;
        }
        public IActionResult RegistrarMascota()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }
        [HttpPost]
        public IActionResult RegistrarMascota(Mascota m)
        {
          if(ModelState.IsValid){
              _context.Add(m);
              _context.SaveChanges();
              return RedirectToAction("Index","Home");
          }
          return View();
        }

    }
}