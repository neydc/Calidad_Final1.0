using System.Collections.Generic;
using System.Linq;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface IArtista
    {
        public List<Artista> GetAllArtistas();
        public Dictionary<int, string> DictionaryArtistas();
    }
    public class ArtistaRepository : IArtista
    {
        private SpotifyContext _context;

        public ArtistaRepository(SpotifyContext _context)
        {
            this._context = _context;
        }
        
        public List<Artista> GetAllArtistas()
        {
            var artistas = _context.Artistas.ToList();
            return artistas;
        }

        public Dictionary<int, string> DictionaryArtistas()
        {
            Dictionary<int, string> NombreArtista = new Dictionary<int, string>();
            var artistas = _context.Artistas.ToList();


            foreach (var VARIABLE in artistas)
            {
                NombreArtista.Add(VARIABLE.Id, " - " + VARIABLE.Nombre + " - ");
            }

            return NombreArtista;
        }
    }
}