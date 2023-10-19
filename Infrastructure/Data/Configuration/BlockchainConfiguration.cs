using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class BlockchainConfiguration : IEntityTypeConfiguration<Blockchain>
     {
         public void Configure(EntityTypeBuilder<Blockchain> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("Blockchain");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

             builder.Property(h => h.HashGenerado)
             .IsRequired()
             .HasMaxLength(100);
 
             builder.Property(e => e.FechaCreacion)
             .HasColumnType("datetime");
 
             builder.Property(e => e.FechaModificacion)
             .HasColumnType("datetime");
 
             builder.HasOne(p => p.TipoNotificaciones)
             .WithMany(p => p.Blockchains)
             .HasForeignKey(p => p.IdTipoNotificacion);
 
             builder.HasOne(p => p.HiloRespuestaNotificaciones)
             .WithMany(p => p.Blockchains)
             .HasForeignKey(p => p.IdHiloRespuesta);
 
             builder.HasOne(p => p.Auditorias)
             .WithMany(p => p.Blockchains)
             .HasForeignKey(p => p.IdAuditoria);

             }
         }
     }