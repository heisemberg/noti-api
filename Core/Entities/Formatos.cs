using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class Formatos : BaseEntity
{
    public string NombreFormato {get; set;}
    public DateTime FechaCreacion {get; set;}
    public DateTime FechaModificacion {get; set;}

    public ICollection<ModuloNotificaciones> ModuloNotificaciones {get; set;}
}
