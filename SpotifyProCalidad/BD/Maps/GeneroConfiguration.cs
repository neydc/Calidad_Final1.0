using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Genero");
            builder.HasKey(o => o.Id);
            
            //Canciones
            builder.HasMany(o => o.Canciones).
                WithOne(o=>o.Genero).
                HasForeignKey(o => o.IdGenero);
        }
    }
}
