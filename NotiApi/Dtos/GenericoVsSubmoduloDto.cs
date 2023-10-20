using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotiApi.Dtos
{
    public class GenericoVsSubmoduloDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdPermisoGenerico { get; set; }
        public int IdMaestroSubmodulo { get; set; }
        public int IdRol { get; set; }
    }
}