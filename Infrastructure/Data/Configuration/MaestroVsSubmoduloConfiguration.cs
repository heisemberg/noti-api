using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class MaestroVsSubmoduloConfiguration : IEntityTypeConfiguration<MaestroVsSubmodulo>
     {
         public void Configure(EntityTypeBuilder<MaestroVsSubmodulo> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("MaestroVsSubmodulo");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

            builder.HasOne(p => p.ModulosMaestros)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdModuloMaestro);

            builder.HasOne(p => p.SubModulos)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdSubModulo);

            builder.Property(e => e.FechaCreacion)
            .HasColumnType("datetime");
            
            builder.Property(e => e.FechaModificacion)
            .HasColumnType("datetime");
             }
         }
     }