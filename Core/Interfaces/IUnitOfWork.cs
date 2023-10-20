using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuditoria Auditorias { get; }
        IBlockchain Blockchains { get; }
        IEstadoNotificacion EstadoNotificaciones { get; }
        IFormato Formatos { get; }
        IHiloRespuestaNotificacion HiloRespuestaNotificaciones {get; }
        IModuloNotificacion ModuloNotificaciones { get; }
        IRadicado Radicados { get; }
        ITipoNotificacion TipoNotificaciones { get; }
        ITipoRequerimiento TipoRequerimientos { get; }
        IGenericoVsSubmodulo GenericosVsSubmodulos { get; }
        IMaestroVsSubmodulo MaestrosVsSubModulos { get; }
        IModuloMaestro ModulosMaestros { get; }
        IPermisoGenerico PermisosGenericos { get; }
        IRol Roles { get; }
        IRolVsMaestro RolesVsMaestros { get; }
        ISubModulo SubModulos { get; }
        Task<int> SaveAsync();
    }
}