using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Seguridad;
using Ywferia.Cloud.Utilitarios.Enumerados; 
using Ywferia.Cloud.Logica.ILogica.ISeguridad;

namespace Ywferia.Cloud.Logica.Logica.Seguridad
{
    public class Log_Usuarios : ILog_Usuarios
    {
        private readonly IAD_usuario _aDUsuario;

        public Log_Usuarios(IAD_usuario aDUsuario)
        {
            _aDUsuario = aDUsuario;
        }

        public string Editar(string esquema, C_usuario item, AccionesMantenimiento accion)
        {
            return _aDUsuario.Modificar(esquema, item);
        }

        public string Eliminar(string esquema, string codigo)
        {
            return _aDUsuario.Eliminar(esquema, codigo);
        }

        public C_usuario GetSeguridadUsuario(string usuario)
        {
            return _aDUsuario.GetSeguridadUsuario(usuario);
        }

        public CollectionPage<C_usuario> Listado(string esquema, C_usuario criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc)
        {
            return _aDUsuario.Listado(esquema, criterio, pagina, elementosPorPagina, orden, DireccionOrden.Asc);
        }

   

        public C_usuario ObtenerPorId(string esquema, string codigo)
        {
            return _aDUsuario.ObtenerPorId(esquema, codigo);
        } 

        public int SeguridadLogin(string usuario, string pass)
        {
            return _aDUsuario.SeguridadLogin(usuario, pass);
        }
    }
}
