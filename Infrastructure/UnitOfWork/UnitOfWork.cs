using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NotiContext _context;
        private IAuditoria _auditorias;
        private IBlockchain _blockchains;
        private IEstadoNotificacion _estadonotificaciones;
        private IFormato _formatos;
        private IHiloRespuestaNotificacion _hilorespuestanotificaciones;
        private IModuloNotificacion _modulonotificaciones;
        private IRadicado _radicados;
        private ITipoNotificacion _tiponotificaciones;
        private ITipoRequerimiento _tiporequerimientos;
        private IGenericoVsSubmodulo _genericosvssubmodulos;
        private IMaestroVsSubmodulo _maestrosvssubmodulos;
        private IModuloMaestro _modulosmaestros;
        private IPermisoGenerico _permisosgenericos;
        private IRol _roles;
        private IRolVsMaestro _rolesvsmaestros;
        private ISubModulo _submodulos;

        public UnitOfWork(NotiContext context)
        {
            _context = context;
        }

        public IAuditoria Auditorias{
            get{
                if(_auditorias == null){
                    _auditorias = new AuditoriaRepository(_context);
                }
                return _auditorias;
            }
        }
        public IBlockchain Blockchains{
            get{
                if(_blockchains == null){
                    _blockchains = new BlockchainRepository(_context);
                }
                return _blockchains;
            }
        }
        public IEstadoNotificacion EstadoNotificaciones{
            get{
                if(_estadonotificaciones == null){
                    _estadonotificaciones = new EstadoNotificacionRepository(_context);
                }
                return _estadonotificaciones;
            }
        }
        public IFormato Formatos{
            get{
                if(_formatos == null){
                    _formatos = new FormatoRepository(_context);
                }
                return _formatos;
            }
        }
        public IHiloRespuestaNotificacion HiloRespuestaNotificaciones{
            get{
                if(_hilorespuestanotificaciones == null){
                    _hilorespuestanotificaciones = new HiloRespuestaNotiRepository(_context);
                }
                return _hilorespuestanotificaciones;
            }
        }
        public IModuloNotificacion ModuloNotificaciones{
            get{
                if(_modulonotificaciones == null){
                    _modulonotificaciones = new ModuloNotificacionRepository(_context);
                }
                return _modulonotificaciones;
            }
        }
        public IRadicado Radicados{
            get{
                if(_radicados == null){
                    _radicados = new RadicadoRepository(_context);
                }
                return _radicados;
            }
        }
        public ITipoNotificacion TipoNotificaciones{
            get{
                if(_tiponotificaciones == null){
                    _tiponotificaciones = new TipoNotificacionRepository(_context);
                }
                return _tiponotificaciones;
            }
        }
        public ITipoRequerimiento TipoRequerimientos{
            get{
                if(_tiporequerimientos == null){
                    _tiporequerimientos = new TipoRequerimientoRepository(_context);
                }
                return _tiporequerimientos;
            }
        }
        public IGenericoVsSubmodulo GenericosVsSubmodulos{
            get{
                if(_genericosvssubmodulos == null){
                    _genericosvssubmodulos = new GenericoVsSubmoduloRepository(_context);
                }
                return _genericosvssubmodulos;
            }
        }
        public IMaestroVsSubmodulo MaestrosVsSubModulos{
            get{
                if(_maestrosvssubmodulos == null){
                    _maestrosvssubmodulos = new MaestroVsSubModuloRepository(_context);
                }
                return _maestrosvssubmodulos;
            }
        }
        public IModuloMaestro ModulosMaestros{
            get{
                if(_modulosmaestros == null){
                    _modulosmaestros = new ModuloMaestroRepository(_context);
                }
                return _modulosmaestros;
            }
        }
        public IPermisoGenerico PermisosGenericos{
            get{
                if(_permisosgenericos == null){
                    _permisosgenericos = new PermisoGenericoRepository(_context);
                }
                return _permisosgenericos;
            }
        }
        public IRol Roles{
            get{
                if(_roles == null){
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }
        public IRolVsMaestro RolesVsMaestros{
            get{
                if(_rolesvsmaestros == null){
                    _rolesvsmaestros = new RolVsMaestroRepository(_context);
                }
                return _rolesvsmaestros;
            }
        }
        public ISubModulo SubModulos{
            get{
                if(_submodulos == null){
                    _submodulos = new SubModuloRepository(_context);
                }
                return _submodulos;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}