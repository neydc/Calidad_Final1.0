using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SpotifyProCalidad.Controllers;
using SpotifyProCalidad.Models;
using SpotifyProCalidad.Repositorio;
using SpotifyProCalidad.Service;

namespace SpotifyProCalidadPruebas.controladoresTest
{
    public class PaginaPrincipalTests
    {
          [Test]
        public void UsuarioAndresAgregaUnComentarioAlaLista3()
        {
            var detalleComentario = new List<DetalleListaReproduccionComentario>();
            var detalleCanciones = new List<DetalleListaReproduccionCancion>();
            var listas = new List<ListaRepoduccion>();
            var locales = new List<Amistad>();
            var destinos = new List<Amistad>();
List<ListaRepoduccion> casa = new List<ListaRepoduccion>();
            var usuario = new Usser();
            usuario.Id = 1;
            usuario.Nombre = "Andres";
            usuario.Apellido = "Cisneros";
            usuario.Correo = "asf@hotmail.com";
            usuario.FechaNacimiento = DateTime.Now;
            usuario.FechaCreacionUsuario = DateTime.Now;
            usuario.Nickname = "admin";
            usuario.Password = "admin";
            usuario.Imagen = "rostro.jpg";
            usuario.ListaReproducciones = listas;
            usuario.locales = locales;
            usuario.destinos = destinos;

            var lista = new ListaRepoduccion();
            lista.Id = 3;
            lista.Nombre = "ListaDeRock";
            lista.FechaCreacion = DateTime.Now;
            lista.UsserId = 1;
            lista.Estado = false;
            lista.DetalleListaReproduccionComentarios = detalleComentario;
            lista.DetalleListaReproduccionCanciones = detalleCanciones;
            lista.usser = usuario;
            var comentMock = new Mock<IComentario>();
            comentMock.Setup(o => o.GuardarCOmentario(lista.Id, "Lista de rock clasico", usuario.Id));

            var userMock = new Mock<IUsser>();
            userMock.Setup(o => o.UsuarioLogeado(null)).Returns(new Usser { });

            var cookMock = new Mock<ICookieAuthService>();

            var pagCont = new PaginaPrincipal(null, null, null, null, null, comentMock.Object, null, null, null, cookMock.Object, userMock.Object);
            var guardarCom = pagCont.AgregarComentario(3, "Lista de rock clasico");

            Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
        }

        [Test]
        public void UsuarioAndresAgregaAmigoPedro()
        {
            var listas = new List<ListaRepoduccion>();
            var locales = new List<Amistad>();
            var destinos = new List<Amistad>();

            var usuario = new Usser();
            usuario.Id = 1;
            usuario.Nombre = "Andres";
            usuario.Apellido = "Cisneros";
            usuario.Correo = "asf@hotmail.com";
            usuario.FechaNacimiento = DateTime.Now;
            usuario.FechaCreacionUsuario = DateTime.Now;
            usuario.Nickname = "admin";
            usuario.Password = "admin";
            usuario.Imagen = "rostro.jpg";
            usuario.ListaReproducciones = listas;
            usuario.locales = locales;
            usuario.destinos = destinos;




            var listas1 = new List<ListaRepoduccion>();
            var locales1 = new List<Amistad>();
            var destinos1 = new List<Amistad>();

            var amigo = new Usser();
            usuario.Id = 5;
            usuario.Nombre = "Pedro";
            usuario.Apellido = "Castañeda";
            usuario.Correo = "asf@hotmail.com";
            usuario.FechaNacimiento = DateTime.Now;
            usuario.FechaCreacionUsuario = DateTime.Now;
            usuario.Nickname = "administrador";
            usuario.Password = "administrador";
            usuario.Imagen = "rostro.jpg";
            usuario.ListaReproducciones = listas1;
            usuario.locales = locales1;
            usuario.destinos = destinos1;

            var amistadMock = new Mock<IAmistad>();
            amistadMock.Setup(o => o.AgregarAmigo(amigo.Id, usuario.Id));

            var cookMock = new Mock<ICookieAuthService>();

            var userMock = new Mock<IUsser>();
            userMock.Setup(o => o.UsuarioLogeado(null)).Returns(new Usser { });

            var pagCont = new PaginaPrincipal(null, null, null, null, amistadMock.Object, null, null, null, null, cookMock.Object, userMock.Object);
            var agregar = pagCont.AddFriend(5);

            Assert.IsInstanceOf<RedirectToActionResult>(agregar);
        }
    }
}