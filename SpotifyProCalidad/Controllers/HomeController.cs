using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Extensions;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SpotifyContext _context;

       

        public HomeController(ILogger<HomeController> _logger,SpotifyContext _context)
        {
            
            this._logger = _logger;
            this._context = _context;
        }

        
        public IActionResult Index()
        {
            var siEstaLogueado = User.Identity.IsAuthenticated;
            if (siEstaLogueado)
            {
                return RedirectToAction("Perfil", "PaginaPrincipal");
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}