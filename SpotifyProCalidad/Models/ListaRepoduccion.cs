using System;
using System.Collections.Generic;

namespace SpotifyProCalidad.Models
{
    public class ListaRepoduccion
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }
        
        public int UsserId{ get; set; }

        public bool Estado { get; set; }

        public List<DetalleListaReproduccionComentario> DetalleListaReproduccionComentarios { get; set; }
       
        public List<DetalleListaReproduccionCancion> DetalleListaReproduccionCanciones { get; set; }
        public Usser usser { get; set; }
    }
}