using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyProCalidad.Models;

namespace SpotifyProCalidad.BD.Maps
{
    public class UsserConfiguration: IEntityTypeConfiguration<Usser>
    {
        public void Configure(EntityTypeBuilder<Usser> builder)
        {
            builder.ToTable("Usser");
            builder.HasKey(o => o.Id);
            
            
            //Cuenta
            builder.HasMany(o => o.ListaReproducciones).
                WithOne(o=>o.usser).
                HasForeignKey(o => o.UsserId);


            builder.HasMany(o => o.locales).WithOne(o => o.local).HasForeignKey(o => o.idLocal);
            builder.HasMany(o => o.destinos).WithOne(o => o.amigo).HasForeignKey(o => o.idAmigo);



        }
    }
}