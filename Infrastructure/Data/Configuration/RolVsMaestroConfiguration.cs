using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
     public class RolVsMaestroConfiguration : IEntityTypeConfiguration<RolVsMaestro>
     {
         public void Configure(EntityTypeBuilder<RolVsMaestro> builder)
         {
             // Aquí puedes configurar las propiedades de la entidad
             // utilizando el objeto builder
             builder.ToTable("RolVsMaestro");

             builder.HasKey(e => e.Id);
             builder.Property(e => e.Id);

             builder.HasOne(p => p.Roles)
                .WithMany(p => p.RolesVsMaestros)
                .HasForeignKey(p => p.IdRol);
 
             builder.HasOne(p => p.ModulosMaestros)
                .WithMany(p => p.RolesVsMaestros)
                .HasForeignKey(p => p.IdModuloMaestro);
 
            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime");
             
             builder.Property(e => e.FechaModificacion)
                .HasColumnType("datetime");
             }
         }
     }