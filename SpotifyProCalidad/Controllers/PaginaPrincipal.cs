using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Extensions;
using SpotifyProCalidad.Models;
using SpotifyProCalidad.Repositorio;
using SpotifyProCalidad.Service;


namespace SpotifyProCalidad.Controllers
{
    // [Authorize]
    public class PaginaPrincipal : Controller
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

        public PaginaPrincipal(IAlbum _album, IArtista _artista, ICancion _cancion,
            IDetalleCancionArtista _detalleCancionArtista, IAmistad _amistad, IComentario _comentario,
            IDetalleListaReproduccionCancion _detalleListaReproduccionCancion, IGenero _genero,
            IListaReproduccion _listaReproduccion, ICookieAuthService _cookieAuthService, IUsser _usser)
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
       public IActionResult Perfil2(string busqueda, int IdLista = 0)
       {
            var sesion = LoggedUser();
            var detalleLista = _listaReproduccion.ListaFavoritos(sesion);
            var cancionesBuesquedaQuery = _cancion.BusquedaCancion(busqueda);

            var DetalleListaReproduccion = _detalleListaReproduccionCancion.DetalleListaReproduccionCancionesIndices(detalleLista);
            var MisListas = _listaReproduccion.MisListaRepoducciones(sesion);
            ViewBag.DetalleCancionArtista = _detalleCancionArtista.GetAllDetalleCancionArtista();
            ViewBag.Generos = _genero.GetAllGeneros();
        
            ViewBag.Albumnes = _album.GetAllAlbumnes();
            ViewBag.Artista = _artista.DictionaryArtistas();
            ViewBag.DetalleNumeros = DetalleListaReproduccion;
            ViewBag.Busqueda = busqueda;
            ViewBag.Mislistas = MisListas;
            return View(cancionesBuesquedaQuery);
        }

            public IActionResult Perfil(string busqueda,int IdLista=0)
        {
            var sesion = LoggedUser();

            var cancionesBuesquedaQuery = _cancion.BusquedaCancion(busqueda);


            var detalleLista = _listaReproduccion.ListaFavoritos(sesion);

            var MisListas = _listaReproduccion.MisListaRepoducciones(sesion);

            var DetalleListaReproduccion =
                _detalleListaReproduccionCancion.DetalleListaReproduccionCancionesIndices(detalleLista);


            List<Comentario>  detalleComentarios = new List<Comentario>();

             if (IdLista!=0)
               {
                  detalleComentarios = _comentario.comentariosLista(IdLista);
            

             }
            ViewBag.ComentariosLista = detalleComentarios;

            ViewBag.Amigos = _usser.MisAmigos(sesion);
            ViewBag.AllUsers = _usser.GetAllUsers().ToList();
            ViewBag.Mislistas = MisListas;
            ViewBag.Busqueda = busqueda;
            ViewBag.Artista = _artista.DictionaryArtistas();
            ViewBag.Usser = sesion;
            ViewBag.Generos = _genero.GetAllGeneros();
            ViewBag.DetalleCancionArtista = _detalleCancionArtista.GetAllDetalleCancionArtista();
            ViewBag.Albumnes = _album.GetAllAlbumnes();
            ViewBag.Favoritos = detalleLista;
            ViewBag.DetalleNumeros = DetalleListaReproduccion;
            ViewBag.ListasReproduccion = _listaReproduccion.GetAllListaRepoduccion();

            return View(cancionesBuesquedaQuery);
        }

        //playlistAmigos


        public IActionResult PlaylistAmigos(int IdAmigo)
        {
            
            ViewBag.ListasReproducciones = _listaReproduccion.ListasDeReproducciones(IdAmigo);
            
            return View();
        }

        //Agregar comentario
        public IActionResult AgregarComentario(int IdLista, string descripcion)
        {
            
            var sesion =LoggedUser();
            _comentario.GuardarCOmentario(IdLista, descripcion, sesion.Id);


            return RedirectToAction("Perfil", "PaginaPrincipal");
        }


        [HttpGet]
        public IActionResult AddFriend(int IdAmigo)
        {
            var sesion = LoggedUser();
            _amistad.AgregarAmigo(IdAmigo, sesion.Id);
            
            
            return RedirectToAction("Perfil", "PaginaPrincipal");
        }
        public IActionResult MisAmigos(int IdLista = 0)
        {
            var sesion = LoggedUser();
            ViewBag.Amigos = _usser.MisAmigos(sesion);

            var detalleLista = _listaReproduccion.ListaFavoritos(sesion);
            ViewBag.Favoritos = detalleLista;

            var MisListas = _listaReproduccion.MisListaRepoducciones(sesion);
            ViewBag.Mislistas = MisListas;
            ViewBag.Usser = sesion;
            ViewBag.AllUsers = _usser.GetAllUsers().ToList();


            List<Comentario> detalleComentarios = new List<Comentario>();

            if (IdLista != 0)
            {
                detalleComentarios = _comentario.comentariosLista(IdLista);


            }
            ViewBag.ComentariosLista = detalleComentarios;
            return View();
        }
        public IActionResult AgregarAmigos(int IdLista = 0)
        {
            var sesion = LoggedUser();
            ViewBag.Amigos = _usser.MisAmigos(sesion);

            var detalleLista = _listaReproduccion.ListaFavoritos(sesion);
            ViewBag.Favoritos = detalleLista;

            var MisListas = _listaReproduccion.MisListaRepoducciones(sesion);
            ViewBag.Mislistas = MisListas;
            ViewBag.Usser = sesion;
            ViewBag.AllUsers = _usser.GetAllUsers().ToList();


            List<Comentario> detalleComentarios = new List<Comentario>();

            if (IdLista != 0)
            {
                detalleComentarios = _comentario.comentariosLista(IdLista);


            }
            ViewBag.ComentariosLista = detalleComentarios;

            ViewBag.AllUsers = _usser.GetAllUsers();
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