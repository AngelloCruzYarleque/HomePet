using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomePet.Models;
using HomePet.Data;

namespace HomePet.Controllers
{
    public class HomeController : Controller
    {
        private PetDbContext _context;
        
        public HomeController(PetDbContext c ) {
            this._context = c;
            
        }
        public IActionResult Index(string sexo, string tamano, string tipo)
        {
            var mascotas = _context.Mascotas.ToList();
            /* if(sexo!="0" && tamano!="0" && tipo!="0"){
                mascotas = _context.Mascotas.Where(x => x.Sexo == sexo && x.Tamano==tamano && x.TipoPelo==tipo).ToList(); 
            }else if(sexo!="0" && tamano!="0" && tipo=="0"){
                mascotas = _context.Mascotas.Where(x => x.Sexo == sexo && x.Tamano==tamano).ToList();
            }else if(sexo!="0" && tamano=="0" && tipo!="0"){
                mascotas = _context.Mascotas.Where(x => x.Sexo == sexo && x.TipoPelo==tipo).ToList();
            }else if(sexo=="0" && tamano!="0" && tipo!="0"){
                mascotas = _context.Mascotas.Where(x => x.TipoPelo == tipo && x.Tamano==tamano).ToList();
            }else if(sexo!="0" && tamano=="0" && tipo=="0"){
                mascotas = _context.Mascotas.Where(x => x.Sexo == sexo).ToList();
            }else if(sexo=="0" && tamano!="0" && tipo=="0"){
                mascotas = _context.Mascotas.Where(x => x.Tamano == tamano).ToList();
            }else if(sexo=="0" && tamano=="0" && tipo!="0"){
                mascotas = _context.Mascotas.Where(x => x.TipoPelo == tipo).ToList();
            }               
             */
                     
            ViewBag.m = mascotas;
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
