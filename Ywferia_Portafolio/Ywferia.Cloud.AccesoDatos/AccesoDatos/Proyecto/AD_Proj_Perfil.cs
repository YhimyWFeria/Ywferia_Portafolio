using System;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IProyecto;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Proyecto;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Proyecto
{
    public class AD_Proj_Perfil : IAD_Proj_Perfil
    {
        public string Eliminar(string esquema, string id)
        {
            throw new NotImplementedException();
        }

        public string Guardar(string esquema, C_Proj_Perfil item)
        {
            throw new NotImplementedException();
        }

        public CollectionPage<C_Proj_Perfil> Listado(string esquema, C_Proj_Perfil criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            throw new NotImplementedException();
        }

        public string Modificar(string esquema, C_Proj_Perfil item)
        {
            throw new NotImplementedException();
        }

        public C_Proj_Perfil ObtenerPorId(string esquema, string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
