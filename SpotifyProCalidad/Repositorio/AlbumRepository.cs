using System.Collections.Generic;
using System.Linq;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface IAlbum
    {
        public List<Album> GetAllAlbumnes();
    }
    
    public class AlbumRepository : IAlbum
    {
        private SpotifyContext _context;

        public AlbumRepository(SpotifyContext _context)
        {
            this._context = _context;
        }
        
      

        public List<Album> GetAllAlbumnes()
        {
            var Albumes= _context.Albumnes.ToList();
            return Albumes;
        }
    }
}