using HomePet.Models;
using HomePet.Data;
using HomePet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    }
}