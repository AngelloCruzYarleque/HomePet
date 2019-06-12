using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomePet.Models;
using HomePet.Data;
using Microsoft.EntityFrameworkCore;

namespace HomePet.Controllers
{
    public class HomeController : Controller
    {
        private PetDbContext _context;
        
        public HomeController(PetDbContext c ) {
            this._context = c;
            
        }
        public IActionResult Index(string sexo, int tamano, int tipoPelo)
        {
            ViewBag.TipoPelo=_context.MascotaTipoPelo.ToList();
            ViewBag.Edad=_context.MascotaEdad.ToList();
            ViewBag.Tamano=_context.MascotaTamano.ToList();
            var mascotas = _context.Mascotas.Include(x=>x.Edad).Include(x=>x.TipoPelo).Include(x=>x.Tamano).ToList();
            if(tipoPelo==0 && sexo==null && tamano==0){
                mascotas = _context.Mascotas.Include(x=>x.Edad).Include(x=>x.TipoPelo).Include(x=>x.Tamano).OrderByDescending(x=>x.Id).ToList();
            }else{
                if(sexo=="0" && tamano==0 && tipoPelo!=0){
                    mascotas = _context.Mascotas.Include(x=>x.Edad).Include(x=>x.TipoPelo).Include(x=>x.Tamano).Where(x=>x.TipoPeloId==tipoPelo).ToList();
                }else if(sexo=="0" && tamano!=0 && tipoPelo==0){
                    mascotas = _context.Mascotas.Include(x=>x.Edad).Include(x=>x.TipoPelo).Include(x=>x.Tamano).Where(x=>x.TamanoId==tamano).ToList();
                }else if(sexo!="0" && tamano==0 && tipoPelo==0){
                    mascotas = _context.Mascotas.Include(x=>x.Edad).Include(x=>x.TipoPelo).Include(x=>x.Tamano).Where(x=>x.Sexo==sexo).ToList();
                }else if(sexo=="0"){
                    mascotas = _context.Mascotas.Include(x=>x.Edad).Include(x=>x.TipoPelo).Include(x=>x.Tamano).Where(x=>x.TamanoId==tamano && x.TipoPeloId==tipoPelo).ToList();
                }else if(tamano==0){
                    mascotas = _context.Mascotas.Include(x=>x.Edad).Include(x=>x.TipoPelo).Include(x=>x.Tamano).Where(x=>x.Sexo==sexo && x.TipoPeloId==tipoPelo).ToList();
                }else if(tipoPelo==0){
                    mascotas = _context.Mascotas.Include(x=>x.Edad).Include(x=>x.TipoPelo).Include(x=>x.Tamano).Where(x=>x.TamanoId==tamano && x.Sexo==sexo ).ToList();
                }else{
                    mascotas = _context.Mascotas.Include(x=>x.Edad).Include(x=>x.TipoPelo).Include(x=>x.Tamano).Where(x=>x.TamanoId==tamano && x.Sexo==sexo && x.TipoPeloId==tipoPelo).ToList();
                }
            }
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
