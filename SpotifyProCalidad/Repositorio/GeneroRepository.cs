using System.Collections.Generic;
using System.Linq;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface IGenero
    {
        public List<Genero> GetAllGeneros();
    }
    public class GeneroRepository : IGenero
    {
        private SpotifyContext _context;

        public GeneroRepository(SpotifyContext _context)
        {
            this._context = _context;
        }
        
        public List<Genero> GetAllGeneros()
        {
            var generos = _context.Generos.ToList();
            return generos;
        }
    }
}