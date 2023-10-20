using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotiApi.Dtos
{
    public class ModuloMaestroDto
    {
        public int Id { get; set; }
        public string NombreModulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}