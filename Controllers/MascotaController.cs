using System.IO;
using HomePet.Data;
using HomePet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;

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
          return View();
        }
        [HttpPost]
        public IActionResult RegistrarMascota(Mascota m)
        {
          var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
          if(ModelState.IsValid && m.TipoPelo!="0" && m.Sexo!="0" && m.Tamano!="0" && m.Edad!="0"){
            
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "imagenes");
                var fullPath = Path.Combine(uploads,m.photofile.FileName);
                m.photofile.CopyTo(new FileStream(fullPath, FileMode.Create));  
                m.Foto = m.photofile.FileName;    
                m.exDueno=user.UserName;                 
                _context.Add(m);
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
            
          }          
          return View();        
          
        }
        

    }
}