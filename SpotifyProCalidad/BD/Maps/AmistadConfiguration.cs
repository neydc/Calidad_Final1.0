using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class AmistadConfiguration : IEntityTypeConfiguration<Amistad>
    {
        public void Configure(EntityTypeBuilder<Amistad> builder)
        {
            builder.ToTable("Amistad");
            builder.HasKey(o => o.Id);


        }
    }
}