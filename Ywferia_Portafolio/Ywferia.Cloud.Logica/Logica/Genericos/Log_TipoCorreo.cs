using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IGenericos;
using Ywferia.Cloud.Logica.ILogica.IGenericos;
using Ywferia.Cloud.Modelo.Genericos;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Logica.Logica.Genericos
{
    public class Log_TipoCorreo : ILog_TipoCorreo
    {
        private readonly IAD_TipoCorreo _iAD_TipoCorreo;

        public Log_TipoCorreo(IAD_TipoCorreo iAD_TipoCorreo)
        {
            _iAD_TipoCorreo = iAD_TipoCorreo;
        }

        public string Editar(string esquema, C_TipoCorreo item, AccionesMantenimiento accion)
        {
            return _iAD_TipoCorreo.Modificar(esquema, item);
        }

        public string Eliminar(string esquema, string codigo)
        {
            return _iAD_TipoCorreo.Eliminar(esquema, codigo);
        }

        public CollectionPage<C_TipoCorreo> Listado(string esquema, C_TipoCorreo criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc)
        {
            return _iAD_TipoCorreo.Listado(esquema, criterio, pagina, elementosPorPagina, orden, direccion);
        }

        public C_TipoCorreo ObtenerPorId(string esquema, string codigo)
        {
            return _iAD_TipoCorreo.ObtenerPorId(esquema, codigo);
        }
    }
}
