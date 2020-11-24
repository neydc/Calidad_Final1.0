using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class DetalleListaReproduccionCancionConfiguration: IEntityTypeConfiguration<DetalleListaReproduccionCancion>
    {
        public void Configure(EntityTypeBuilder<DetalleListaReproduccionCancion> builder)
        {
            
            builder.ToTable("DetalleListaReproduccionCancion");
            builder.HasKey(o => o.Id);
            
           
            builder.HasOne(o => o.Cancion).WithMany(o => 
                o.DetalleListaReproduccionCanciones).HasForeignKey(o => o.IdCancion);
            
            builder.HasOne(o => o.ListaReproduccion)
                .WithMany(o => o.DetalleListaReproduccionCanciones).
                HasForeignKey(o => o.IdListaReproduccion);
        }
    }
}