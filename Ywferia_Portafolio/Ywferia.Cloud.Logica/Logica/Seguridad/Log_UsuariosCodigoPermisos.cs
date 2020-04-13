using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Logica.ILogica.ISeguridad;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Seguridad;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Logica.Logica.Seguridad
{
    public class Log_UsuariosCodigoPermisos : ILog_UsuariosCodigoPermisos
    {
        private readonly IAD_UsuariosCodigoPermisos _UsuariosCodigoPermisos;
        public Log_UsuariosCodigoPermisos(IAD_UsuariosCodigoPermisos UsuariosCodigoPermisos)
        {
            _UsuariosCodigoPermisos = UsuariosCodigoPermisos;
        }

        public string Editar(string esquema, C_UsuariosCodigoPermisos item, AccionesMantenimiento accion)
        {
            return _UsuariosCodigoPermisos.Modificar(esquema, item);
        }

        public string Eliminar(string esquema, string codigo)
        {
            return _UsuariosCodigoPermisos.Eliminar(esquema, codigo);
        }

        public CollectionPage<C_UsuariosCodigoPermisos> Listado(string esquema, C_UsuariosCodigoPermisos criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc)
        {
            return _UsuariosCodigoPermisos.Listado(esquema, criterio, pagina, elementosPorPagina, orden, DireccionOrden.Asc);
        }

        public C_UsuariosCodigoPermisos ObtenerPorId(string esquema, string codigo)
        {
            return _UsuariosCodigoPermisos.ObtenerPorId(esquema, codigo);
        }
    }
}
