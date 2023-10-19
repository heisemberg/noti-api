using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class GenericoVsSubmoduloConfiguration : IEntityTypeConfiguration<GenericoVsSubmodulo>
     {
         public void Configure(EntityTypeBuilder<GenericoVsSubmodulo> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("GenericoVsSubmodulo");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

             builder.HasOne(p => p.PermisosGenericos)
                 .WithMany(p => p.GenericosVsSubmodulos)
                 .HasForeignKey(p => p.IdPermisoGenerico);

             builder.HasOne(p => p.MaestrosVsSubmodulos)
                 .WithMany(p => p.GenericosVsSubmodulos)
                 .HasForeignKey(p => p.IdMaestroSubModulo);

             builder.HasOne(p => p.Roles)
                 .WithMany(p => p.GenericosVsSubmodulos)
                 .HasForeignKey(p => p.Id);

             builder.Property(e => e.FechaCreacion)
             .HasColumnType("datetime");
            
             builder.Property(e => e.FechaModificacion)
             .HasColumnType("datetime");
             }
         }
     }