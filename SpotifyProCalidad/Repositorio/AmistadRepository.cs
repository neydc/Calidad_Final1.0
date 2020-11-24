using System.Collections.Generic;
using System.Linq;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface IAmistad
    {
        public List<Amistad> MisAmistades();
        public void AgregarAmigo(int IdAmigo, int IdUsuario);

    }
    public class AmistadRepository : IAmistad
    {
        private SpotifyContext _context;

        public AmistadRepository(SpotifyContext _context)
        {
            this._context = _context;
        }

        public void AgregarAmigo(int IdAmigo, int IdUsuario)
        {
            Amistad nueva = new Amistad();
            nueva.idAmigo = IdAmigo;
            nueva.idLocal = IdUsuario;
            _context.Amistades.Add(nueva);
            _context.SaveChanges();
        }

        public List<Amistad> MisAmistades()
        {
            var MisAmistades = _context.Amistades.ToList();

            return MisAmistades;
        }
    }
}