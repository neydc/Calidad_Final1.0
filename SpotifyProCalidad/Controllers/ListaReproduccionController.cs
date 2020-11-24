using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Extensions;
using SpotifyProCalidad.Models;
using SpotifyProCalidad.Repositorio;
using SpotifyProCalidad.Service;

namespace SpotifyProCalidad.Controllers
{
    [Authorize]
    public class ListaReproduccionController : Controller
    {


        private readonly IAlbum _album;
        private readonly IArtista _artista;
        private readonly ICancion _cancion;
        private readonly IDetalleCancionArtista _detalleCancionArtista;
        private readonly IAmistad _amistad;
        private readonly IComentario _comentario;
        private readonly IDetalleListaReproduccionCancion _detalleListaReproduccionCancion;
        private readonly IGenero _genero;
        private readonly IListaReproduccion _listaReproduccion;

        private readonly ICookieAuthService _cookieAuthService;
        private readonly IUsser _usser;

        public ListaReproduccionController(IAlbum _album, IArtista _artista, ICancion _cancion, IDetalleCancionArtista _detalleCancionArtista, IAmistad _amistad, IComentario _comentario, IDetalleListaReproduccionCancion _detalleListaReproduccionCancion, IGenero _genero, IListaReproduccion _listaReproduccion, ICookieAuthService _cookieAuthService, IUsser _usser)
        {
            this._album = _album;
            this._artista = _artista;
            this._cancion = _cancion;
            this._detalleCancionArtista = _detalleCancionArtista;
            this._amistad = _amistad;
            this._comentario = _comentario;
            this._detalleListaReproduccionCancion = _detalleListaReproduccionCancion;
            this._genero = _genero;
            this._listaReproduccion = _listaReproduccion;
            this._cookieAuthService = _cookieAuthService;
            this._usser = _usser;
        }


        public IActionResult Index()
        {
            var sesion = LoggedUser();

            var ListasDeReproducciones = _listaReproduccion.MisListaRepoducciones(sesion);
            //return Json(ListasDeReproducciones);
            return View(ListasDeReproducciones);
            // return RedirectToAction("DetalleListaReproduccion");
        }

        public IActionResult DetalleListaReproduccion(int IdLista)
        {
            var sesion = LoggedUser();
            var ListaCanciones = _listaReproduccion.IdMiListaReproduccion(IdLista);
            var listasRep = _listaReproduccion.BuscarLista(IdLista);

            ViewBag.DetalleDeCanciones = _cancion.MisCanciones(ListaCanciones);
            ViewBag.Artista = _artista.DictionaryArtistas();
            ViewBag.Usser = sesion;
            ViewBag.Mislistas = _listaReproduccion.MisListaRepoducciones(sesion);
            ViewBag.Generos = _genero.GetAllGeneros();
            ViewBag.DetalleCancionArtista = _detalleCancionArtista.GetAllDetalleCancionArtista();
            ViewBag.Albumnes =  _album.GetAllAlbumnes();
            ViewBag.ListasReproduccion = listasRep.Nombre;
            ViewBag.IdlistasReproduccion = listasRep.Id;

            ViewBag.Favoritos = _listaReproduccion.ListaFavoritos(sesion);
            return View();
        }

        public IActionResult AgregarCancionFavoritos(int IdCancion)
        {
            //var sesion = HttpContext.Session.Get<Usser>("sessionUser");
            var sesion = LoggedUser();
            var ListaFavoritos = _listaReproduccion.ListaFavoritos(sesion);
            _cancion.AgregarCancion(IdCancion, ListaFavoritos);
            
            return RedirectToAction("Perfil", "PaginaPrincipal");

        }

        public IActionResult EliminarLista(int IdLista)
        {
            _listaReproduccion.EliminarLista(IdLista);
            return RedirectToAction("Perfil", "PaginaPrincipal");

        }
        [HttpGet]
        public IActionResult AgregarLista()
        {
            return View();
        }
            [HttpPost]
        public IActionResult AgregarLista (string NombreLista)
        {
           
            var sesion = LoggedUser();
           
            _listaReproduccion.AgregarLista(NombreLista,sesion.Id);
            return RedirectToAction("Perfil", "PaginaPrincipal");
        }
        public IActionResult CambiarEstadoLista (bool Estado, int IdLista)
        {
            _listaReproduccion.CambioEStadoListaReproduccion(Estado, IdLista);
            
            return RedirectToAction("Perfil", "PaginaPrincipal");
        }
        public IActionResult AgregarCancionAListaReproduccion (int IdCancion, int IdLista)
        {
            _cancion.AgregarCancionAListaReproduccion(IdCancion,IdLista);
            
            return RedirectToAction("Perfil", "PaginaPrincipal");
        }
        
        public IActionResult EliminarCancionAListaReproduccion (int IdCancion, int IdLista)
        {
            _cancion.EliminarCancionAListaReproduccion(IdCancion,IdLista);
            
            return RedirectToAction("Perfil", "PaginaPrincipal");
        }
        public IActionResult ListaDeReproducciones (int IdUsuario)
        {
            
           ViewBag.listaReproducciones= _listaReproduccion.ListasDeReproducciones(IdUsuario);
            
            return View();
        }
        
        
        private Usser LoggedUser()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var claim = _cookieAuthService.ObetenerClaim();
            var user = _usser.UsuarioLogeado(claim);
            return user;
        }
        

    }
}
