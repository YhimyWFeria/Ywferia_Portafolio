using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IGenericos;
using Ywferia.Cloud.Logica.ILogica.IGenericos;
using Ywferia.Cloud.Modelo.Genericos;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Logica.Logica.Genericos
{
    public class Log_Modulos : ILog_Modulos
    {
        private readonly IAD_Modulos _aD_Modulos;

        public Log_Modulos(IAD_Modulos aDModulos)
        {
            _aD_Modulos = aDModulos;
        }

        public string Editar(string esquema, C_Modulos item, AccionesMantenimiento accion)
        {
            return _aD_Modulos.Modificar(esquema, item);
        }

        public string Eliminar(string esquema, string codigo)
        {
            return _aD_Modulos.Eliminar(esquema, codigo);
        }

        public CollectionPage<C_Modulos> Listado(string esquema, C_Modulos criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc)
        {
            return _aD_Modulos.Listado(esquema, criterio, pagina, elementosPorPagina, orden, direccion);
        }

        public C_Modulos ObtenerPorId(string esquema, string codigo)
        {
            return _aD_Modulos.ObtenerPorId(esquema, codigo);
        }
    }
}
