using System;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IProyecto;
using Ywferia.Cloud.Logica.ILogica.IProyecto;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Proyecto;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Logica.Logica.Proyecto
{
    public class Log_Proj_Perfil : ILog_Proj_Perfil
    {
        private readonly IAD_Proj_Perfil _Proj_Perfil;

        public Log_Proj_Perfil(IAD_Proj_Perfil roj_Perfil)
        {
            _Proj_Perfil = roj_Perfil;
        }

        public string Editar(string esquema, C_Proj_Perfil item, AccionesMantenimiento accion)
        {
            return _Proj_Perfil.Modificar(esquema, item);
        }

        public string Eliminar(string esquema, string codigo)
        {
            return _Proj_Perfil.Eliminar(esquema, codigo);
        }

        public CollectionPage<C_Proj_Perfil> Listado(string esquema, C_Proj_Perfil criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc)
        {
            return _Proj_Perfil.Listado(esquema, criterio, pagina, elementosPorPagina, orden, direccion);
        }

        public C_Proj_Perfil ObtenerPorId(string esquema, string codigo)
        {
            return _Proj_Perfil.ObtenerPorId(esquema, codigo);
        }
    }
}
