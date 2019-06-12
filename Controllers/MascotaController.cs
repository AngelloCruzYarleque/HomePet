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
          ViewBag.TipoPelo=_context.MascotaTipoPelo.ToList();
          ViewBag.Edad=_context.MascotaEdad.ToList();
          ViewBag.Tamano=_context.MascotaTamano.ToList();
          return View();
        }
        [HttpPost]
        public IActionResult RegistrarMascota(Mascota m)
        {
          
          if(ModelState.IsValid){
              var uploads = Path.Combine(hostingEnvironment.WebRootPath, "imagenes");
              var fullPath = Path.Combine(uploads,m.photofile.FileName);
              m.photofile.CopyTo(new FileStream(fullPath, FileMode.Create));  
              m.Foto = m.photofile.FileName;                     
              _context.Add(m);
              _context.SaveChanges();
              return RedirectToAction("Index","Home");
          }
          ViewBag.TipoPelo=_context.MascotaTipoPelo.ToList();
          ViewBag.Edad=_context.MascotaEdad.ToList();
          ViewBag.Tamano=_context.MascotaTamano.ToList();
          return View();        
          
        }

    }
}