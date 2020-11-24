using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SpotifyProCalidad.Models;
using SpotifyProCalidad.Repositorio;
using SpotifyProCalidad.Service;

namespace SpotifyProCalidadPruebas.controladoresTest
{
    public class AuthControllerTest
    {
         [Test]
        public void UsuarioAndresSeRegistra()
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

            var userMock = new Mock<IUsser>();
            userMock.Setup(o => o.AgregarUsuario(usuario));

            var cookMock = new Mock<ICookieAuthService>();

            var listaMock = new Mock<IListaReproduccion>();
            listaMock.Setup(o => o.CrewarFavoritoPorDefecto(usuario));


            var authCont = new AuthController(userMock.Object, cookMock.Object, listaMock.Object);
            var reg = authCont.Registrarse(usuario);

            Assert.IsInstanceOf<RedirectToActionResult>(reg);

        }

        [Test]
        public void UsuarioAndresSeLoguea()
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

            var userMock = new Mock<IUsser>();
            userMock.Setup(o => o.EncontrarUsuario(usuario.Nickname, usuario.Password)).Returns(new Usser { });

            var cookMock = new Mock<ICookieAuthService>();

            var authCont = new AuthController(userMock.Object, cookMock.Object, null);
            var log = authCont.Login("admin", "admin");

            Assert.IsInstanceOf<RedirectToActionResult>(log);
        }
    }
}