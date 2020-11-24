using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(o => o.Id);
            
            //Artista
            builder.HasOne(o => o.Artista).WithMany(o => 
                o.Albumnes).HasForeignKey(o => o.IdArtista);

            //Canciones
            builder.HasMany(o => o.Canciones).
                WithOne(o=>o.Album).
                HasForeignKey(o => o.IdAlbum);

        }
    }
}