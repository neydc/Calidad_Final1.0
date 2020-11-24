using System.Collections.Generic;
using System.Linq;
using SpotifyProCalidad.BD;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.Repositorio
{
    public interface IComentario
    {
        public void GuardarCOmentario(int IdLista, string descripcion, int Idusuario);
        public List<Comentario> GetALlComentarios();

        public List<Comentario> comentariosLista(int IdLista);
    }
    
    public class ComentarioRepository : IComentario
    {
        private SpotifyContext _context;

        public ComentarioRepository(SpotifyContext _context)
        {
            this._context = _context;
        }
        
        public void GuardarCOmentario(int IdLista, string descripcion, int Idusuario)
        {
            Comentario comentarioNuevo = new Comentario();
            comentarioNuevo.Descripcion = descripcion;
            _context.Comentarios.Add(comentarioNuevo);
        }

        public List<Comentario> GetALlComentarios()
        {
            var comentarios = _context.Comentarios.ToList();
            return comentarios;
        }

        public List<Comentario> comentariosLista(int IdLista)
        {
            var detalle = _context.DetalleListaReproduccionComentarios.Where(o => o.IdListaReproduccion == IdLista).ToList().
                Select(o=>o.IdComentario)
                .ToList();
            List<Comentario> comentariosLista = new List<Comentario>();
            var comentarios = _context.Comentarios.ToList();

            foreach (var item in comentarios)
            {
                if (detalle.Contains(item.Id))
                {
                    comentariosLista.Add(item);
                }
            }

            return comentariosLista;

        }
    }
}