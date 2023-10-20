using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotiApi.Dtos
{
    public class MaestroVsSubmoduloDto
    {
       public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdModuloMaestro { get; set; }
        public int IdSubModulo { get; set; } 
    }
}