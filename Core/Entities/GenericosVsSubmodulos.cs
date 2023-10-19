using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class GenericosVsSubmodulos : BaseEntity
{
    [Required]
    public int IdPermisosGenericos { get; set; }
    public PermisosGenericos PermisosGenericos { get; set; }

    [Required]
    public int IdMaestrosSubModulos { get; set; }
    public MaestrosVsSubmodulos MaestrosVsSubmodulos { get; set; }

    [Required]
    public int IdRol { get; set; }
    public Rol Rol { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
