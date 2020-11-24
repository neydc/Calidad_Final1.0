using System.Collections.Generic;
using System.Linq;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface IDetalleListaReproduccionCancion
    {
        public List<DetalleListaReproduccionCancion> GetAllDetalleListaReproduccionCancion();

        public List<DetalleListaReproduccionCancion> DetalleListaReproduccionCanciones(
            ListaRepoduccion listaRepoduccion);

        public List<int> DetalleListaReproduccionCancionesIndices(ListaRepoduccion listaRepoduccion);
    }
    public class DetalleListaReproduccionCancionRepository : IDetalleListaReproduccionCancion
    {
        private SpotifyContext _context;

        public DetalleListaReproduccionCancionRepository(SpotifyContext _context)
        {
            this._context = _context;
        }
        
        
        public List<DetalleListaReproduccionCancion> GetAllDetalleListaReproduccionCancion()
        {
            var detalleListaReproduccionCanciones = _context.DetalleListaReproduccionCanciones.ToList();
            return detalleListaReproduccionCanciones;
        }

        public List<DetalleListaReproduccionCancion> DetalleListaReproduccionCanciones(ListaRepoduccion listaRepoduccion)
        {
            return _context.DetalleListaReproduccionCanciones.Where(o => o.IdListaReproduccion == listaRepoduccion.Id)
                .ToList();
        }

        public List<int> DetalleListaReproduccionCancionesIndices(ListaRepoduccion listaRepoduccion)
        {

            return _context.DetalleListaReproduccionCanciones.Where(o => o.IdListaReproduccion == listaRepoduccion.Id)
                .ToList().Select(o => o.IdCancion).ToList();
        }
    }
}