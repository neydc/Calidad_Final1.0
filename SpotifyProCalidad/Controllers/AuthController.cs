using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Extensions;
using SpotifyProCalidad.Models;
using SpotifyProCalidad.Repositorio;
using SpotifyProCalidad.Service;

public class AuthController : Controller
{
    private readonly IUsser _usser;
    private readonly ICookieAuthService _cookieAuthService;
    private readonly IListaReproduccion _listaReproduccion;

    public AuthController(IUsser _usser, ICookieAuthService _cookieAuthService, IListaReproduccion _listaReproduccion)
    {
        this._listaReproduccion = _listaReproduccion;
        this._usser = _usser;
        this._cookieAuthService = _cookieAuthService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string usern, string pass)
    {
        var usuario = _usser.EncontrarUsuario(usern, pass);
        if (usuario != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usern)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            _cookieAuthService.SetHttpContext(HttpContext);
            _cookieAuthService.Login(claimsPrincipal);


            return RedirectToAction("Perfil", "PaginaPrincipal");
        }

        ViewBag.Validation = "Usuario y/o contraseña incorrecta";
        return View();
    }

    [HttpGet]
    public IActionResult Registrarse()
    {
        return View(new Usser());
    }

    [HttpPost]
    public IActionResult Registrarse(Usser usuario)
    {
        usuario.FechaCreacionUsuario = DateTime.Now;

        usuario.Imagen = "UserNew.png";


        if (ModelState.IsValid)
        {
            _usser.AgregarUsuario(usuario);

            _listaReproduccion.CrewarFavoritoPorDefecto(usuario);

            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("Index", "Home");
    }

    public ActionResult Logout()
    {
        HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }
}