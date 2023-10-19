using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class MaestroVsSubmodulo : BaseEntity
{
    [Required]
    public int IdModuloMaestro {get; set;}
    public ModuloMaestro ModulosMaestros {get; set;}

    [Required]
    public int IdSubModulo {get; set;}
    public SubModulo SubModulos {get; set;}

    public DateTime FechaCreacion {get; set;}
    public DateTime FechaModificacion {get; set;}

    public ICollection<GenericoVsSubmodulo> GenericosVsSubmodulos {get; set;}
}
