using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class ComentarioConfiguration: IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(o => o.Id);
            
            //DetalleListaReproduccionComentARIO
            builder.HasMany(o => o.DetalleListaReproduccionComentarios).
                WithOne(o=>o.comentario).
                HasForeignKey(o => o.IdComentario);
        }
    }
}
