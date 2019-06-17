using HomePet.Models;
using HomePet.Data;
using HomePet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace HomePet.Controllers
{
    public class CuentaController: Controller
    {
        private PetDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager; 

        public CuentaController(PetDbContext p, UserManager<IdentityUser> um, 
        SignInManager<IdentityUser> sim){
            _context=p;
            _userManager=um;
            _signInManager=sim;
        }
        public IActionResult RegistrarUsuario()
        {
          return View();
        }

        [HttpPost]

        public IActionResult RegistrarUsuario(RegistroViewModel vm)
        {
          if (ModelState.IsValid) {
                var user = new IdentityUser();
                user.UserName = vm.Usuario;
                user.Email = vm.Email;

                var resultado = _userManager.CreateAsync(user, vm.Password);

                if (resultado.Result == IdentityResult.Success) {
                    
                    HttpContext.Session.SetString("valida","Su cuenta se ha Creado Correctamente");
                    return RedirectToAction("index", "home");
                }
                else {
                    foreach (var error in resultado.Result.Errors) {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            
            return View(vm);
        }

        public IActionResult Login()
        {
          return View();
        }

        public IActionResult Logout() {
            _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm) {
            if (ModelState.IsValid) {
                var resultado = _signInManager.PasswordSignInAsync(vm.Usuario, vm.Password, false, false);                
                if (resultado.Result.Succeeded) {                    
                    return RedirectToAction("index", "home");

                }
                else {
                    ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                }
            }

            return View(vm);
        }
        public IActionResult CambiarContrasena() {
            return View();
        }

        [HttpPost]
        public IActionResult CambiarContrasena(CambiarContrasenaViewModel vm) {
            if (ModelState.IsValid) {
                
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                var resultado = _userManager.ChangePasswordAsync(user, vm.ContrasenaActual, vm.ContrasenaNueva);

                if (resultado.Result == IdentityResult.Success) {                    
                    HttpContext.Session.SetString("valida","Su contraseña se Cambio con exito");
                    return RedirectToAction("Index", "Home");
                }
                else {
                    foreach (var error in resultado.Result.Errors) {
                        ModelState.AddModelError("", error.Description);
                    }
                }
               
            }
            
            return View(vm);
        }
        public IActionResult AdoptarMascota(int id)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var mascota = _context.Mascotas.FirstOrDefault(x=> x.Id==id);
            var tipomascota = _context.TipoMascotas.Where(x=>x.Id==mascota.IdTipoMascota).ToList();
            ViewBag.precio= tipomascota; 
            ViewBag.Id=id;    
          return View();
        }
        [HttpPost]
        public IActionResult AdoptarMascota(int id,Adopta a)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var mascota = _context.Mascotas.FirstOrDefault(x=> x.Id==id);
            var tipomascota = _context.TipoMascotas.Where(x=>x.Id==mascota.IdTipoMascota).ToList();
            if(ModelState.IsValid && a.Edad>=18 && a.EstadoCivil!="0"){
                if(user.UserName!=mascota.exDueno){                
                    mascota.UserName=user.UserName;
                    a.UserName=user.UserName;
                    _context.Add(a);
                    _context.SaveChanges();                   
                    HttpContext.Session.SetString("valida","Adopcion Tramitada con Exito");
                    return RedirectToAction("Index","Home");
                }else{
                   
                    HttpContext.Session.SetString("valida","Usted no puede Adoptar su Mascota");
                    return RedirectToAction("Index","Home");
                }  
            }          
            ViewBag.precio= tipomascota;         
            return View(); 
        }
        public IActionResult MisMascotas()
        {
          var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
          var mascotas = _context.Mascotas.Where(x=> x.UserName==user.UserName).ToList();           
            ViewBag.m = mascotas;
          ViewBag.usuario = user.UserName;
          return View();
        }
    }
}