namespace SpotifyProCalidad.Models
{
    public class DetalleCancionArtista
    {
        public int Id { get; set; }
        public int IdCancion { get; set; }
        public int IdArtista { get; set; }
       // 
        public Cancion Cancion{ get; set; }
        public Artista Artista { get; set; }
    }
}