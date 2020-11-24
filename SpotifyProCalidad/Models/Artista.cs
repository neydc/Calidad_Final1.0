using System.Collections.Generic;

namespace SpotifyProCalidad.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        //
        public List<Album> Albumnes  { get; set; }
        public List<DetalleCancionArtista> DetalleCancionArtistas { get; set; }

    }
}