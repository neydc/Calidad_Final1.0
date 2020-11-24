namespace SpotifyProCalidad.Models
{
    public class Amistad
    {
        public int Id { get; set; }
        public int idLocal { get; set; }
        public int idAmigo { get; set; }

        public Usser local { get; set; }
        public Usser amigo { get; set; }
    }
}