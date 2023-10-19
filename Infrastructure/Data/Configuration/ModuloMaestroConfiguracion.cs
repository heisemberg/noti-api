using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class ModuloMaestroConfiguration : IEntityTypeConfiguration<ModuloMaestro>
     {
         public void Configure(EntityTypeBuilder<ModuloMaestro> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("ModuloMaestro");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

             builder.Property(e => e.NombreModulo)
                .IsRequired()
                .HasMaxLength(100);

             builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime");
            
             builder.Property(e => e.FechaModificacion)
                .HasColumnType("datetime");
             }
         }
     }