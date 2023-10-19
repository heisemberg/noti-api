using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class RolVsMaestro : BaseEntity
{
    [Required]
    public int IdRol {get; set;}
    public Rol Roles {get; set;}

    [Required]
    public int IdModuloMaestro {get; set;}
    public ModuloMaestro ModulosMaestros {get; set;}

    public DateTime FechaCreacion {get; set;}
    public DateTime FechaModificacion {get; set;}
}
