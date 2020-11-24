using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class ArtistaConfiguration :IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("Artista");
            builder.HasKey(o => o.Id);
            
            //Albumnes
            builder.HasMany(o => o.Albumnes).
                WithOne(o=>o.Artista).
                HasForeignKey(o => o.IdArtista);
            
            //DetalleArtistaCancion
            builder.HasMany(o => o.DetalleCancionArtistas).
                WithOne(o=>o.Artista).
                HasForeignKey(o => o.IdArtista);

        }
    }
}