using System.Collections.Generic;

namespace SpotifyProCalidad.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public int IdArtista { get; set; }
        
        //
        public Artista Artista { get; set; }
        public List<Cancion> Canciones{ get; set; }
        
        
        
    }
}