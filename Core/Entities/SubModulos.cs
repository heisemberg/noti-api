using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class SubModulos : BaseEntity
{
    public string NombreSubmodulo {get; set;}
    public DateTime FechaCreacion {get; set;}
    public DateTime FechaModificacion {get; set;}

    public ICollection<MaestrosVsSubmodulos> MaestrosVsSubmodulos {get; set;}
}
