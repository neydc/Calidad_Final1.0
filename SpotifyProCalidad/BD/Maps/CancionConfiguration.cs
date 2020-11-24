using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class CancionConfiguration : IEntityTypeConfiguration<Cancion>
    {
        public void Configure(EntityTypeBuilder<Cancion> builder)
        {
            builder.ToTable("Cancion");
            builder.HasKey(o => o.Id);
            
            
            //DetalleListaReproduccionCancion
            builder.HasMany(o => o.DetalleListaReproduccionCanciones).
                WithOne(o=>o.Cancion).
                HasForeignKey(o => o.IdCancion);
            //DetalleCancionArtista
            builder.HasMany(o => o.DetalleCancionArtistas).
                WithOne(o=>o.Cancion).
                HasForeignKey(o => o.IdArtista);
            
            //Album
            builder.HasOne(o => o.Album).WithMany(o => 
                o.Canciones).HasForeignKey(o => o.IdAlbum);
            
            //Genero
            builder.HasOne(o => o.Genero).WithMany(o => 
                o.Canciones).HasForeignKey(o => o.IdGenero);

        }
    }
}