using System.Collections.Generic;
using System.Linq;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface ICancion
    {
        public List<Cancion> GetAllCanciones();
        public IQueryable<Cancion> GetAllCancionesIQueryable();

        public List<Cancion> BusquedaCancion(string busqueda);

        public void AgregarCancion(int IdCancion, ListaRepoduccion ListaFavoritos);

        public List<Cancion> MisCanciones(List<int> ListaCanciones);
        
        public void AgregarCancionAListaReproduccion(int IdCancion, int IdLista);
        
        public void EliminarCancionAListaReproduccion(int IdCancion, int IdLista);
    }
    public class CancionRepository : ICancion
    {
        private SpotifyContext _context;

        public CancionRepository(SpotifyContext _context)
        {
            this._context = _context;
        }
        
        public List<Cancion> GetAllCanciones()
        {
            var canciones = _context.Canciones.ToList();
            return canciones;
        }

        public IQueryable<Cancion> GetAllCancionesIQueryable()
        {
            var cancionesIquerable = _context.Canciones.AsQueryable();
            return cancionesIquerable;
        }

        public List<Cancion> BusquedaCancion(string busqueda)
        {
            var cancionesBuesquedaQuery = new List<Cancion>();
            if (!string.IsNullOrEmpty(busqueda))
            {
                cancionesBuesquedaQuery = _context.DetalleCancionArtistas
                    .Where(o => o.Cancion.Nombre.ToLower().Contains(busqueda) ||
                                o.Artista.Nombre.ToLower().Contains(busqueda))
                    .Select(o => o.Cancion).ToList();
            }
            else
            {
                cancionesBuesquedaQuery = _context.Canciones.ToList();
            }

            return cancionesBuesquedaQuery;
        }

        public void AgregarCancion(int IdCancion, ListaRepoduccion ListaFavoritos)
        {
            DetalleListaReproduccionCancion Agregando = new DetalleListaReproduccionCancion();
            Agregando.IdCancion = IdCancion;
            Agregando.IdListaReproduccion = ListaFavoritos.Id;
            _context.DetalleListaReproduccionCanciones.Add(Agregando);
            _context.SaveChanges();
        }

        public List<Cancion> MisCanciones(List<int> ListaCanciones)
        {
            List<Cancion> CancionesDetalle = new List<Cancion>();
            var cancionesTotal = _context.Canciones.ToList();

            foreach (var item in cancionesTotal)
            {
                if (ListaCanciones.Contains(item.Id))
                {
                    CancionesDetalle.Add(item);
                }
            }
            
            return CancionesDetalle;
        }

        public void AgregarCancionAListaReproduccion(int IdCancion, int IdLista)
        {
            DetalleListaReproduccionCancion NuevoDetalle = new DetalleListaReproduccionCancion();
            NuevoDetalle.IdCancion = IdCancion;
            NuevoDetalle.IdListaReproduccion = IdLista;
            _context.DetalleListaReproduccionCanciones.Add(NuevoDetalle);
            _context.SaveChanges();
        }

        //public void EliminarCancionAListaReproduccion(int IdCancion, int IdLista)
        //{
        //    DetalleListaReproduccionCancion DetalleEliminar = new DetalleListaReproduccionCancion();
        //    DetalleEliminar.IdCancion = IdCancion;
        //    DetalleEliminar.IdListaReproduccion = IdLista;
        //    _context.DetalleListaReproduccionCanciones.Remove(DetalleEliminar);
        //    _context.SaveChanges();
        //}
        public void EliminarCancionAListaReproduccion(int IdCancion, int IdLista)
        {
            var detalleElinimar = _context.DetalleListaReproduccionCanciones.Where(o => o.IdCancion == IdCancion && o.IdListaReproduccion == IdLista).FirstOrDefault();

            _context.DetalleListaReproduccionCanciones.Remove(detalleElinimar);
            _context.SaveChanges();
        }
    }
}