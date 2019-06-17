using System.IO;
using HomePet.Data;
using HomePet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Http;

namespace HomePet.Controllers
{
    public class MascotaController : Controller
    {
        private PetDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager; 
        private readonly IHostingEnvironment hostingEnvironment;
        public MascotaController(PetDbContext c,IHostingEnvironment h,UserManager<IdentityUser> um,SignInManager<IdentityUser> sim ) {
            this._context = c;
            this.hostingEnvironment = h;
            this._userManager=um;
            this._signInManager=sim;
        }
          
        public IActionResult RegistrarMascota()
        {          
          var TipoMascota = _context.TipoMascotas.OrderByDescending(x=>x.Id).ToList();          
          ViewBag.Tipo = TipoMascota;
          return View();
        }
        [HttpPost]
        public IActionResult RegistrarMascota(Mascota m)
        {
          var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
          if(ModelState.IsValid && m.TipoPelo!="0" && m.Sexo!="0" && m.Tamano!="0" && m.Edad!="0" && m.IdTipoMascota!=0 && m.photofile!=null){

                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "imagenes");
                var nombrearchivo = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
              var extension=Path.GetExtension(m.photofile.FileName);
                var photoName=nombrearchivo+extension;  
                var fullPath = Path.Combine(uploads,photoName);
                m.photofile.CopyTo(new FileStream(fullPath, FileMode.Create));  
                m.Foto = photoName;   
                m.exDueno=user.UserName;                 
                _context.Add(m);
                _context.SaveChanges();
                
                HttpContext.Session.SetString("valida","Mascota registrada con Exito");
                return RedirectToAction("Index","Home");
          }          
          var TipoMascota = _context.TipoMascotas.OrderByDescending(x=>x.Id).ToList();          
          ViewBag.Tipo = TipoMascota;
          return View();        
          
        }
        public IActionResult RegistrarTipoMascota()
        {          
          
          return View();
        }
        [HttpPost]
        public IActionResult RegistrarTipoMascota(TipoMascota tp) 
        {        
          if(ModelState.IsValid){                    
              _context.Add(tp);
              _context.SaveChanges();
              
              return RedirectToAction("Index","Home");
          }     
          
          return View();
        }
        

    }
}