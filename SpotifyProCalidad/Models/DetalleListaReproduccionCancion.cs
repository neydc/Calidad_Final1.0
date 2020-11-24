namespace SpotifyProCalidad.Models
{
    public class DetalleListaReproduccionCancion
    {
        public int Id { get; set; }
        public int IdListaReproduccion { get; set; }
        public int IdCancion { get; set; }
        
        public ListaRepoduccion ListaReproduccion { get; set; }
        public Cancion Cancion { get; set; }


    }
}