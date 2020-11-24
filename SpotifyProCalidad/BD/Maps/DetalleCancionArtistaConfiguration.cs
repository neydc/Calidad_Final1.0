using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class DetalleCancionArtistaConfiguration : IEntityTypeConfiguration<DetalleCancionArtista>
    {
        public void Configure(EntityTypeBuilder<DetalleCancionArtista> builder)
        {
            builder.ToTable("DetalleCancionArtista");
            builder.HasKey(o => o.Id);

             //Cancion
            builder.HasOne(o => o.Cancion).WithMany(o => 
                o.DetalleCancionArtistas).HasForeignKey(o => o.IdCancion);
            //Artista
            builder.HasOne(o => o.Artista)
                .WithMany(o => o.DetalleCancionArtistas).
                HasForeignKey(o => o.IdArtista);

        }
    }
}