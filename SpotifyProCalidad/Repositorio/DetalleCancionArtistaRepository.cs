using System.Collections.Generic;
using System.Linq;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface IDetalleCancionArtista
    {
        public List<DetalleCancionArtista> GetAllDetalleCancionArtista();
    }
    public class DetalleCancionArtistaRepository : IDetalleCancionArtista
    {
        private SpotifyContext _context;

        public DetalleCancionArtistaRepository(SpotifyContext _context)
        {
            this._context = _context;
        }
        
        public List<DetalleCancionArtista> GetAllDetalleCancionArtista()
        {
            var detalleCancionArtista = _context.DetalleCancionArtistas.ToList();
            return detalleCancionArtista;
        }
    }
}