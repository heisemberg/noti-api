using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class EstadoNotificacionConfiguration : IEntityTypeConfiguration<EstadoNotificacion>
     {
         public void Configure(EntityTypeBuilder<EstadoNotificacion> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("EstadoNotificacion");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

             builder.Property(e => e.NombreEstado)
                 .IsRequired()
                 .HasMaxLength(50);

             builder.Property(f => f.FechaCreacion)
             .HasColumnType("datetime"); 
             builder.Property(f => f.FechaModificacion)
             .HasColumnType("datetime");

             }
         }
     }