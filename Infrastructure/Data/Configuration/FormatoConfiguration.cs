using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class FormatoConfiguration : IEntityTypeConfiguration<Formato>
     {
         public void Configure(EntityTypeBuilder<Formato> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("Formato");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

             builder.Property(e => e.NombreFormato)
                 .IsRequired()
                 .HasMaxLength(50);

             builder.Property(f => f.FechaCreacion)
             .HasColumnType("datetime"); 
             builder.Property(f => f.FechaModificacion)
             .HasColumnType("datetime");

             }
         }
     }