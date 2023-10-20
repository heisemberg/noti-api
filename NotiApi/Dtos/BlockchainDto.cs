using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotiApi.Dtos
{
    public class BlockchainDto
    {
        public int Id { get; set; }
        public string HashGenerado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdTipoNotificacion { get; set; }
        public int IdHiloRespuestaNotificacion { get; set; }
        public int IdAuditoria { get; set; } 
    }
}