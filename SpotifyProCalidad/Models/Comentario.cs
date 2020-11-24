using System.Collections.Generic;

namespace SpotifyProCalidad.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
       
        public List<DetalleListaReproduccionComentario> DetalleListaReproduccionComentarios { get; set; }
    }
}