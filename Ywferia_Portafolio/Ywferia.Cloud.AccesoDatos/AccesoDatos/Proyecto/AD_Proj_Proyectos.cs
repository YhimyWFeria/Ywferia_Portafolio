using System;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IProyecto;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Proyecto;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Proyecto
{
    public class AD_Proj_Proyectos : IAD_Proj_Proyectos
    {
        public string Eliminar(string esquema, string id)
        {
            throw new NotImplementedException();
        }

        public string Guardar(string esquema, C_Proj_Proyectos item)
        {
            throw new NotImplementedException();
        }

        public CollectionPage<C_Proj_Proyectos> Listado(string esquema, C_Proj_Proyectos criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            throw new NotImplementedException();
        }

        public string Modificar(string esquema, C_Proj_Proyectos item)
        {
            throw new NotImplementedException();
        }

        public C_Proj_Proyectos ObtenerPorId(string esquema, string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
