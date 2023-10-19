using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class ModuloNotificacionConfiguration : IEntityTypeConfiguration<ModuloNotificacion>
     {
         public void Configure(EntityTypeBuilder<ModuloNotificacion> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("ModuloNotificacion");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

              builder.Property(e => e.AsuntoNotificacion)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(e => e.TextoNotificacion)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(p => p.TipoRequerimientos)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdTipoRequerimiento);

            builder.HasOne(p => p.Radicados)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdRadicado);

            builder.HasOne(p => p.EstadoNotificaciones)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdEstadoNotificacion);

            builder.HasOne(p => p.HiloRespuestaNotificaciones)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdHiloRespuesta);

            builder.HasOne(p => p.Formatos)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdFormato);

            builder.HasOne(p => p.TipoNotificaciones)
            .WithMany(p => p.ModuloNotificaciones)
            .HasForeignKey(p => p.IdTipoNotificacion);

            
            builder.Property(e => e.FechaCreacion)
            .HasColumnType("datetime");
            
            builder.Property(e => e.FechaModificacion)
            .HasColumnType("datetime");
             }
         }
     }