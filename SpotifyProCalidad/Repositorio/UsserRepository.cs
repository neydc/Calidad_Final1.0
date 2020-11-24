using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface IUsser
    {
        public List<Usser> GetAllUsers();
        public Usser EncontrarUsuario(string Nickname, string password);
        public Usser UsuarioLogeado(Claim claim);
        public List<Usser> MisAmigos(Usser usuario);

        public void AgregarUsuario(Usser usuario);
    }
    public class UsserRepository : IUsser
    {
        private SpotifyContext _context;

        public UsserRepository(SpotifyContext _context)
        {
            this._context = _context;
        }

        public List<Usser> GetAllUsers()
        {

            var usuarios = _context.Ussers.ToList();
            return usuarios;
        }

        public Usser EncontrarUsuario(string Nickname, string password)
        {
            var usuario =_context.Ussers.FirstOrDefault(o => o.Nickname == Nickname && o.Password == password);
            return usuario;
        }

        public Usser UsuarioLogeado(Claim claim)
        {
            var user = _context.Ussers.FirstOrDefault(o => o.Nickname == claim.Value);
            return user;
        }

        public List<Usser> MisAmigos(Usser usuario)
        {
            List<Usser> MisAmigos = new List<Usser>();
            var UsuariosAmigosIndice = _context.Amistades.Where(o => o.idLocal == usuario.Id).ToList().Select(a=>a.idAmigo).ToList();
                
           
            var usuarios = _context.Ussers.ToList();
      
            foreach (var item in usuarios)
            {
                if (UsuariosAmigosIndice.Contains(item.Id))
                {
                    MisAmigos.Add(item);
                }
            }

            return MisAmigos;
        }

        public void AgregarUsuario(Usser usuario)
        {
            _context.Ussers.Add(usuario);
            _context.SaveChanges();
        }
    }
}