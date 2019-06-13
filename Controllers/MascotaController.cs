using System.IO;
using HomePet.Data;
using HomePet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HomePet.Controllers
{
    public class MascotaController : Controller
    {
        private PetDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        public MascotaController(PetDbContext c,IHostingEnvironment h ) {
            this._context = c;
            this.hostingEnvironment = h;
        }
        public IActionResult RegistrarMascota()
        {          
          return View();
        }
        [HttpPost]
        public IActionResult RegistrarMascota(Mascota m)
        {
          
          if(ModelState.IsValid && m.TipoPelo!="0" && m.Sexo!="0" && m.Tamano!="0" && m.Edad!="0"){
              var uploads = Path.Combine(hostingEnvironment.WebRootPath, "imagenes");
              var fullPath = Path.Combine(uploads,m.photofile.FileName);
              m.photofile.CopyTo(new FileStream(fullPath, FileMode.Create));  
              m.Foto = m.photofile.FileName;                     
              _context.Add(m);
              _context.SaveChanges();
              return RedirectToAction("Index","Home");
          }          
          return View();        
          
        }
        public IActionResult AdoptarMascota(int id)
        {
          var mascotaEspecifica = _context.Mascotas.Where(x=>x.Id==id).ToList();
          ViewBag.mE = mascotaEspecifica;
          return View();
        }

    }
}