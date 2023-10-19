using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class MaestrosVsSubmodulos : BaseEntity
{
    [Required]
    public int IdModulosMaestros {get; set;}
    public ModulosMaestros ModulosMaestros {get; set;}

    [Required]
    public int IdSubModulos {get; set;}
    public SubModulos SubModulos {get; set;}

    public DateTime FechaCreacion {get; set;}
    public DateTime FechaModificacion {get; set;}

    public ICollection<GenericosVsSubmodulos> GenericosVsSubmodulos {get; set;}
}
