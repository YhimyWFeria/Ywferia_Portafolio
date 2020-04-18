 
using Ywferia.Cloud.Modelo.Interfaces.Logica.Base;
using Ywferia.Cloud.Modelo.Seguridad;

namespace Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad
{
    public interface IAD_UsuariosCodigoView : IRepositorio<C_UsuariosCodigoView>
    {
         C_UsuariosCodigoView ObtenerPorId(string esquema, string codigo1,string codigo2);
    }
}
