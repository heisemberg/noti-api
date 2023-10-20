using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class GenericoVsSubmodulo : BaseEntity
{
    [Required]
    public int IdPermisoGenerico { get; set; }
    public PermisoGenerico PermisosGenericos { get; set; }

    [Required]
    public int IdMaestroSubmodulo { get; set; }
    public MaestroVsSubmodulo MaestrosVsSubmodulos { get; set; }

    [Required]
    public int IdRol { get; set; }
    public Rol Roles { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
