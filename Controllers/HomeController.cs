using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomePet.Models;
using HomePet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace HomePet.Controllers
{
    public class HomeController : Controller
    {
        private PetDbContext _context;
        
        public HomeController(PetDbContext c ) {
            this._context = c;
            
        }
        public IActionResult Index(string edad, string tamano, string sexo, int tipo)
        {            
            var TipoMascotas =_context.TipoMascotas.OrderByDescending(x=>x.Id).ToList();
            var mascotas = _context.Mascotas.Where(x=> x.UserName==null).OrderByDescending(x=>x.Id).ToList();              
                 if(edad!="0" && edad!=null){
                    mascotas = mascotas.Where(x=>x.Sexo==sexo).ToList();
                }if(tamano!="0" && edad!=null){
                    mascotas = mascotas.Where(x=>x.Tamano==tamano).ToList();
                }if(sexo!="0" && edad!=null){
                    mascotas = mascotas.Where(x=>x.Edad==edad).ToList();
                }if(tipo!=0){
                    mascotas = _context.Mascotas.Where(x=>x.IdTipoMascota==tipo).ToList();
                }                
            ViewBag.m = mascotas;
            ViewBag.tipo =TipoMascotas;
            return View();
        }
        public IActionResult Contacto()
        {
          return View();
        }
        public IActionResult Detalles(int id)
        {
          var mascotaEspecifica = _context.Mascotas.Where(x=>x.Id==id).ToList();
          ViewBag.mE = mascotaEspecifica;
          
          return View();
        }
        
        [HttpPost]
        public IActionResult Contacto(Contacto c)
        {
           if(ModelState.IsValid){                    
              _context.Add(c);
              _context.SaveChanges();
              return RedirectToAction("Index","Home");
          }     
          return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
