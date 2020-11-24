using System;
using System.Collections.Generic;
using System.Linq;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface IListaReproduccion
    {
        public List<ListaRepoduccion> GetAllListaRepoduccion();
        public List<int> IdMiListaReproduccion(int IdLista);

        public void EliminarLista(int IdLista);
    
        public void AgregarLista(string NombreLista,int IdUser);

        public void CambioEStadoListaReproduccion(bool Estado, int IdLista);

        public ListaRepoduccion ListaFavoritos(Usser usuario);
        public List<ListaRepoduccion> MisListaRepoducciones(Usser usuario);

        public ListaRepoduccion BuscarLista(int IdLIsta);

        public void CrewarFavoritoPorDefecto(Usser usuario);
        public List<ListaRepoduccion> ListasDeReproducciones(int IdUsuario);


    }
    public class ListaReproduccionRepository : IListaReproduccion
    {
        private SpotifyContext _context;

        public ListaReproduccionRepository(SpotifyContext _context)
        {
            this._context = _context;
        }
        public List<ListaRepoduccion> GetAllListaRepoduccion()
        {
            var listaReproducciones = _context.ListaReproducciones.ToList();
            return listaReproducciones;
        }

        public List<int> IdMiListaReproduccion(int IdLista)
        {
            var detalleId=_context.DetalleListaReproduccionCanciones.ToList()
                .Where(o => o.IdListaReproduccion == IdLista).ToList().Select(o => o.IdCancion).ToList();
            return detalleId;
        }
//Nuevos metodos eliminar lista y agregar lista
        public void EliminarLista(int IdLista)
        {
            var listaAEliminar = BuscarLista(IdLista);
            _context.ListaReproducciones.Remove(listaAEliminar);
            _context.SaveChanges();
        }

        public void AgregarLista(string NombreLista, int IdUser)
        {
            ListaRepoduccion NuevaLista = new ListaRepoduccion();
            NuevaLista.Nombre = NombreLista;
            NuevaLista.FechaCreacion =DateTime.Now;
            NuevaLista.UsserId = IdUser;
            NuevaLista.Estado = false;
            _context.ListaReproducciones.Add(NuevaLista);
            _context.SaveChanges();
        }

        public void CambioEStadoListaReproduccion(bool Estado, int IdLista)
        {
            var ListaCambiarEstado = _context.ListaReproducciones.Where(o => o.Id == IdLista).FirstOrDefault();
            ListaCambiarEstado.Estado = Estado;
            _context.SaveChanges();

        }

        public ListaRepoduccion ListaFavoritos(Usser usuario)
        {
            return _context.ListaReproducciones
                .FirstOrDefault(o => o.Nombre == "Favoritos" && o.UsserId == usuario.Id);
        }

        public List<ListaRepoduccion> MisListaRepoducciones(Usser usuario)
        {
            return _context.ListaReproducciones.Where(o => o.UsserId == usuario.Id).ToList();
        }

        public ListaRepoduccion BuscarLista(int IdLIsta)
        {
            return _context.ListaReproducciones.FirstOrDefault(o => o.Id == IdLIsta);
        }

        public void CrewarFavoritoPorDefecto(Usser usuario)
        {
            var user = _context.Ussers.Where(o => o.Equals(usuario)).FirstOrDefault();
            ListaRepoduccion favoritos = new ListaRepoduccion();
            favoritos.Nombre = "Favoritos";
            favoritos.FechaCreacion =DateTime.Now;
            favoritos.UsserId = user.Id;
            favoritos.Estado = false;
            _context.ListaReproducciones.Add(favoritos);
            _context.SaveChanges();
        }

        public List<ListaRepoduccion> ListasDeReproducciones(int IdUsuario)
        {
            return _context.ListaReproducciones.Where(o => o.UsserId == IdUsuario).ToList();
        }
    }
}