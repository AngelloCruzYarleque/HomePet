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
        public IActionResult Index(string edad, string tamano, string sexo)
        {            
            
            var mascotas = _context.Mascotas.Where(x=> x.UserName==null).ToList();
            if(sexo==null && edad==null && tamano==null){
                mascotas = _context.Mascotas.Where(x=> x.UserName==null).OrderByDescending(x=>x.Id).ToList();
            }else{     
                if(sexo=="0" && edad=="0" && tamano=="0"){
                    mascotas = _context.Mascotas.Where(x=> x.UserName==null).OrderByDescending(x=>x.Id).ToList();              
                }else if(edad=="0" && tamano=="0" && sexo!="0"){
                    mascotas = _context.Mascotas.Where(x=>x.Sexo==sexo && x.UserName==null).ToList();
                }else if(edad=="0" && tamano!="0" && sexo=="0"){
                    mascotas = _context.Mascotas.Where(x=>x.Tamano==tamano && x.UserName==null).ToList();
                }else if(edad!="0" && tamano=="0" && sexo=="0"){
                    mascotas = _context.Mascotas.Where(x=>x.Edad==edad && x.UserName==null).ToList();
                }else if(edad=="0"){
                    mascotas = _context.Mascotas.Where(x=>x.Tamano==tamano && x.Sexo==sexo && x.UserName==null).ToList();
                }else if(tamano=="0"){
                    mascotas = _context.Mascotas.Where(x=>x.Edad==edad && x.Sexo==sexo && x.UserName==null).ToList();
                }else if(sexo=="0"){
                    mascotas = _context.Mascotas.Where(x=>x.Tamano==tamano && x.Edad==edad && x.UserName==null).ToList();
                }else{
                    mascotas = _context.Mascotas.Where(x=>x.Tamano==tamano && x.Edad==edad && x.Sexo==sexo && x.UserName==null).ToList();
                }
            }
            ViewBag.m = mascotas;
            
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
