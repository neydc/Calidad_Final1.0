using Microsoft.EntityFrameworkCore;
using SpotifyProCalidad.BD.Maps;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD
{
    public class SpotifyContext : DbContext
    {
        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<ListaRepoduccion> ListaReproducciones { get; set; }
        
        public DbSet<Usser> Ussers { get; set; }
        public DbSet<DetalleListaReproduccionCancion> DetalleListaReproduccionCanciones { get; set; }

        public DbSet<Album> Albumnes { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<DetalleCancionArtista> DetalleCancionArtistas { get; set; }
        public DbSet<Genero> Generos { get; set; }

        public DbSet<Amistad> Amistades { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<DetalleListaReproduccionComentario> DetalleListaReproduccionComentarios { get; set; }

        public SpotifyContext(DbContextOptions<SpotifyContext> options)
            : base(options) { }

          // optionsBuilder.UseSqlServer("Server=DESKTOP-6AL815O\\SQLEXPRESS; DataBase=SpotifyProCalidad;Trusted_Connection=True;MultipleActiveResultSets=true");
          //optionsBuilder.UseSqlServer("Data Source=SQL5080.site4now.net;Initial Catalog=DB_A6707F_SpotifyProCalidad;User Id=DB_A6707F_SpotifyProCalidad_admin;Password=Locosport24@");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
          modelBuilder.ApplyConfiguration(new CancionConfiguration());
          modelBuilder.ApplyConfiguration(new ListaReproduccionConfiguration());  
          modelBuilder.ApplyConfiguration(new DetalleListaReproduccionCancionConfiguration());
          modelBuilder.ApplyConfiguration(new UsserConfiguration());
          //
          modelBuilder.ApplyConfiguration(new ArtistaConfiguration());
          modelBuilder.ApplyConfiguration(new AlbumConfiguration());
          modelBuilder.ApplyConfiguration(new DetalleCancionArtistaConfiguration());
          modelBuilder.ApplyConfiguration(new GeneroConfiguration());
            modelBuilder.ApplyConfiguration(new AmistadConfiguration());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleListaReproduccionComentarioConfiguration());


        }
    }
}