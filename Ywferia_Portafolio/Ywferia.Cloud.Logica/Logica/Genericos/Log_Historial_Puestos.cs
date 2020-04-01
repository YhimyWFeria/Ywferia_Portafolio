using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IGenericos;
using Ywferia.Cloud.Logica.ILogica.IGenericos;
using Ywferia.Cloud.Modelo.Genericos;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Logica.Logica.Genericos
{
    public class Log_Historial_Puestos : ILog_Historial_Puestos
    {
        private readonly IAD_Historial_Puestos _Historial_Puestos;
        
        public Log_Historial_Puestos(IAD_Historial_Puestos Historial_Puestos)
        {
            _Historial_Puestos = Historial_Puestos;
        }

        public string Editar(string esquema, C_Historial_Puestos item, AccionesMantenimiento accion)
        {
            return _Historial_Puestos.Modificar(esquema, item);
        }

        public string Eliminar(string esquema, string codigo)
        {
            return _Historial_Puestos.Eliminar(esquema, codigo);
        }

        public CollectionPage<C_Historial_Puestos> Listado(string esquema, C_Historial_Puestos criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc)
        {
            return _Historial_Puestos.Listado(esquema, criterio, pagina, elementosPorPagina, orden, direccion);
        }

        public C_Historial_Puestos ObtenerPorId(string esquema, string codigo)
        {
            return _Historial_Puestos.ObtenerPorId(esquema, codigo);
        }
    }
}
