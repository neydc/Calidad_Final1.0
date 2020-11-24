using System.Collections.Generic;

namespace SpotifyProCalidad.Models
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Musica { get; set; }
        public int IdAlbum{ get; set; }
        public int IdGenero{ get; set; }
        
        //
       public Album Album{ get; set; }
       public Genero Genero{ get; set; }
       
       public List<DetalleCancionArtista> DetalleCancionArtistas { get; set; }
        public List<DetalleListaReproduccionCancion> DetalleListaReproduccionCanciones { get; set; }
    }
}