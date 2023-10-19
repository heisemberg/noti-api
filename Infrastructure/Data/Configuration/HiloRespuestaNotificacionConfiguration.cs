using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class HiloRespuestaNotificacionConfiguration : IEntityTypeConfiguration<HiloRespuestaNotificacion>
     {
         public void Configure(EntityTypeBuilder<HiloRespuestaNotificacion> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("HiloRespuestaNotificacion");

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