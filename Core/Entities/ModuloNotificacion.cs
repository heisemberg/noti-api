using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class ModuloNotificacion : BaseEntity
{
    public string AsuntoNotificacion { get; set; }
    public string TextoNotificacion { get; set; }

    [Required]
    public int IdTipoNotificacion { get; set; }
    public TipoNotificacion TipoNotificaciones { get; set; }

    [Required]
    public int IdRadicado { get; set; }
    public Radicado Radicados { get; set; }

    [Required]
    public int IdEstadoNotificacion { get; set; }
    public EstadoNotificacion EstadoNotificaciones { get; set; }

    [Required]
    public int IdHiloRespuesta { get; set; }
    public HiloRespuestaNotificacion HiloRespuestaNotificaciones { get; set; }

    [Required]
    public int IdFormato { get; set; }
    public Formato Formatos { get; set; }

    [Required]
    public int IdTipoRequerimiento { get; set; }
    public TipoRequerimiento TipoRequerimientos { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }

}
