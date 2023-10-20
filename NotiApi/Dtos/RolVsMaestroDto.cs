using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotiApi.Dtos
{
    public class RolVsMaestroDto
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdModuloMaestro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        
    }
}