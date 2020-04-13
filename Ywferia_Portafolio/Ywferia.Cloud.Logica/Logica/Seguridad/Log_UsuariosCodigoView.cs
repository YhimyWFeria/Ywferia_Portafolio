using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Logica.ILogica.ISeguridad;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Seguridad;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Logica.Logica.Seguridad
{
    public class Log_UsuariosCodigoView : ILog_UsuariosCodigoView
    {
        private readonly IAD_UsuariosCodigoView _UsuariosCodigoView;

        public Log_UsuariosCodigoView(IAD_UsuariosCodigoView UsuariosCodigoView)
        {
            _UsuariosCodigoView = UsuariosCodigoView;
        }
        public string Editar(string esquema, C_UsuariosCodigoView item, AccionesMantenimiento accion)
        {
            return _UsuariosCodigoView.Modificar(esquema, item);
        }

        public string Eliminar(string esquema, string codigo)
        {
            return _UsuariosCodigoView.Eliminar(esquema, codigo);
        }

        public CollectionPage<C_UsuariosCodigoView> Listado(string esquema, C_UsuariosCodigoView criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc)
        {
            return _UsuariosCodigoView.Listado(esquema, criterio, pagina, elementosPorPagina, orden, DireccionOrden.Asc);
        }

        public C_UsuariosCodigoView ObtenerPorId(string esquema, string codigo)
        {
            return _UsuariosCodigoView.ObtenerPorId(esquema, codigo);
        }
    }
}
