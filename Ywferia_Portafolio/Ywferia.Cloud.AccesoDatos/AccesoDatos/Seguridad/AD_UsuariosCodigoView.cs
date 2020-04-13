using System; 
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Seguridad;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Seguridad
{
    public class AD_UsuariosCodigoView : IAD_UsuariosCodigoView
    {
        public string Eliminar(string esquema, string id)
        {
            throw new NotImplementedException();
        }

        public string Guardar(string esquema, C_UsuariosCodigoView item)
        {
            throw new NotImplementedException();
        }

        public CollectionPage<C_UsuariosCodigoView> Listado(string esquema, C_UsuariosCodigoView criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            throw new NotImplementedException();
        }

        public string Modificar(string esquema, C_UsuariosCodigoView item)
        {
            throw new NotImplementedException();
        }

        public C_UsuariosCodigoView ObtenerPorId(string esquema, string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
