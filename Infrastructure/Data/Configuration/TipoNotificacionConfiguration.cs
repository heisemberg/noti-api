using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class TipoNotificacionConfiguration : IEntityTypeConfiguration<TipoNotificacion>
     {
         public void Configure(EntityTypeBuilder<TipoNotificacion> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("TipoNotificacion");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

             builder.Property(e => e.NombreTipo)
                .IsRequired()
                .HasMaxLength(50);

             builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime");
            
             builder.Property(e => e.FechaModificacion)
                .HasColumnType("datetime");
             }
         }
     }