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
        public IActionResult Index()
        {
            var mascotas = _context.Mascotas.ToList(); 
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
