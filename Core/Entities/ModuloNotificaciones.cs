using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class ModuloNotificaciones : BaseEntity
{
    public string AsuntoNotificacion { get; set; }

    [Required]
    public int IdTipoNotificaciones { get; set; }
    public TipoNotificaciones TipoNotificaciones { get; set; }

    [Required]
    public int IdRadicados { get; set; }
    public Radicados Radicados { get; set; }

    [Required]
    public int IdEstadoNotificacion { get; set; }
    public EstadoNotificacion EstadoNotificacion { get; set; }

    [Required]
    public int IdHiloRespuesta { get; set; }
    public HiloRespuestaNotificacion HiloRespuestaNotificacion { get; set; }

    [Required]
    public int IdFormatos { get; set; }
    public Formatos Formatos { get; set; }

    [Required]
    public int IdTipoRequerimiento { get; set; }
    public TipoRequerimiento TipoRequerimiento { get; set; }

    public string TextoNotificacion { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }

}
