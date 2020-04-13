using System;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Seguridad;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Seguridad
{
    public class AD_UsuariosCodigoPermisos : IAD_UsuariosCodigoPermisos
    {
        public string Eliminar(string esquema, string id)
        {
            throw new NotImplementedException();
        }

        public string Guardar(string esquema, C_UsuariosCodigoPermisos item)
        {
            throw new NotImplementedException();
        }

        public CollectionPage<C_UsuariosCodigoPermisos> Listado(string esquema, C_UsuariosCodigoPermisos criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            throw new NotImplementedException();
        }

        public string Modificar(string esquema, C_UsuariosCodigoPermisos item)
        {
            throw new NotImplementedException();
        }

        public C_UsuariosCodigoPermisos ObtenerPorId(string esquema, string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
