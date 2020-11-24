namespace SpotifyProCalidad.Models
{
    public class DetalleListaReproduccionComentario
    {
        public int Id { get; set; }
        public int IdListaReproduccion { get; set; }
        public int IdComentario { get; set; }

        public Comentario comentario { get; set; }
        public ListaRepoduccion listaRepoduccion { get; set; }
    }
}