using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotiApi.Dtos
{
    public class HiloRespuestaNotificacionDto
    {
        public int Id { get; set; }
        public string NombreTipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}