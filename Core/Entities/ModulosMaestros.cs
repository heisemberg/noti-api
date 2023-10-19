using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class ModulosMaestros : BaseEntity
{
    public string NombreModulo {get; set;}
    public DateTime FechaCreacion {get; set;}
    public DateTime FechaModificacion {get; set;}
    public ICollection<RolVsMaestro> RolVsMaestro {get; set;}
    public ICollection<MaestrosVsSubmodulos> MaestrosVsSubmodulos {get; set;}
}
