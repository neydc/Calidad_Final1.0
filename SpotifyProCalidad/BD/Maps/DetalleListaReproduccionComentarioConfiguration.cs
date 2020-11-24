

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class DetalleListaReproduccionComentarioConfiguration: IEntityTypeConfiguration<DetalleListaReproduccionComentario>
    {
        public void Configure(EntityTypeBuilder<DetalleListaReproduccionComentario> builder)
        {
            
            builder.ToTable("DetalleListaReproduccionComentario");
            builder.HasKey(o => o.Id);
            
           
            builder.HasOne(o => o.comentario)
                .WithMany(o => o.DetalleListaReproduccionComentarios).
                HasForeignKey(o => o.IdComentario);

            builder.HasOne(o => o.listaRepoduccion)
               .WithMany(o => o.DetalleListaReproduccionComentarios).
               HasForeignKey(o => o.IdListaReproduccion);
        }
    }
}