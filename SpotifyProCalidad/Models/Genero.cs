using System.Collections.Generic;

namespace SpotifyProCalidad.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        //
        public List<Cancion> Canciones{ get; set; }
    }
}