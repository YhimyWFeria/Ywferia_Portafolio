using System;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IGenericos;
using Ywferia.Cloud.Logica.ILogica.IGenericos;
using Ywferia.Cloud.Modelo.Genericos;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Logica.Logica.Genericos
{
    public class Log_Historial_correos : ILog_Historial_correos
    {
        private readonly IAD_Historial_correos _iAD_Historial;

        public Log_Historial_correos(IAD_Historial_correos  iAD_Historial)
        {
            _iAD_Historial = iAD_Historial;
        }

        public string Editar(string esquema, C_Historial_correos item, AccionesMantenimiento accion)
        {
            return _iAD_Historial.Modificar(esquema, item);
        }

        public string Eliminar(string esquema, string codigo)
        {
            return _iAD_Historial.Eliminar(esquema, codigo);
        }

        public CollectionPage<C_Historial_correos> Listado(string esquema, C_Historial_correos criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc)
        {
            return _iAD_Historial.Listado(esquema, criterio, pagina, elementosPorPagina, orden, direccion);
        }

        public C_Historial_correos ObtenerPorId(string esquema, string codigo)
        {
            return _iAD_Historial.ObtenerPorId(esquema, codigo);
        }
    }
}
