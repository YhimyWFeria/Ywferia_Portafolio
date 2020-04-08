using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IProyecto;
using Ywferia.Cloud.Logica.ILogica.IProyecto;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Proyecto;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Logica.Logica.Proyecto
{
    public class Log_Proj_Proyectos : ILog_Proj_Proyectos
    {
        private readonly IAD_Proj_Proyectos _iAD_Proj;

        public Log_Proj_Proyectos(IAD_Proj_Proyectos iAD_Proj)
        {
            _iAD_Proj = iAD_Proj;
        }
        public string Editar(string esquema, C_Proj_Proyectos item, AccionesMantenimiento accion)
        {
            return _iAD_Proj.Modificar(esquema, item);
        }
        public string Eliminar(string esquema, string codigo)
        {
            return _iAD_Proj.Eliminar(esquema, codigo);
        }

        public CollectionPage<C_Proj_Proyectos> Listado(string esquema, C_Proj_Proyectos criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc)
        {
            return _iAD_Proj.Listado(esquema, criterio, pagina, elementosPorPagina, orden, direccion);
        }

        public C_Proj_Proyectos ObtenerPorId(string esquema, string codigo)
        {
            return _iAD_Proj.ObtenerPorId(esquema, codigo);
        }
    }
}
