using Ywferia.Cloud.Modelo.Interfaces.Logica.Base;
using Ywferia.Cloud.Modelo.Seguridad;
namespace Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad
{
  public  interface IAD_usuario : IRepositorio<C_usuario>
    {
        int SeguridadLogin(string usuario, string pass);
        C_usuario GetSeguridadUsuario(string usuario);
         

         
    }
}