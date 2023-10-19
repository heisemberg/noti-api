using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class SubModuloConfiguration : IEntityTypeConfiguration<SubModulo>
     {
         public void Configure(EntityTypeBuilder<SubModulo> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("SubModulo");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

             builder.Property(e => e.NombreSubmodulo)
                .IsRequired()
                .HasMaxLength(80);

             builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime");
            
             builder.Property(e => e.FechaModificacion)
                .HasColumnType("datetime");
             }
         }
     }