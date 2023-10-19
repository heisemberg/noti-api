using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class Blockchain : BaseEntity
{
    [Required]
    public int IdTipoNotificaciones { get; set; }
    public TipoNotificaciones TipoNotificaciones { get; set; }

    [Required]
    public int IdHiloRespuesta { get; set; }
    public HiloRespuestaNotificacion HiloRespuestaNotificacion { get; set; }

    [Required]
    public int IdAuditoria { get; set; }
    public Auditoria Auditoria { get; set; }

    public string HashGenerado { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
