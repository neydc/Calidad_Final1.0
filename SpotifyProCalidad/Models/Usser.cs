using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpotifyProCalidad.Models
{
    public class Usser
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
  
        public string Apellido { get; set; }
     
        public string Correo { get; set; }
        
        public DateTime FechaNacimiento { get; set; } 
        public DateTime FechaCreacionUsuario { get; set; } 
       
        public string Password { get; set; }
   
        public string Nickname { get; set; }
        public string Imagen{ get; set; }
        
        
        public List<ListaRepoduccion> ListaReproducciones { get; set; }
        public List<Amistad> locales { get; set; }
        public List<Amistad> destinos { get; set; }

    }
}