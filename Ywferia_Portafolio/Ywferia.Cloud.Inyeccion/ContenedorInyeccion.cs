using System;
using Unity;
using Unity.Lifetime;
using Ywferia.Cloud.AccesoDatos.AccesoDatos.Seguridad;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Logica.ILogica.ISeguridad;
using Ywferia.Cloud.Logica.Logica.Seguridad;

namespace Ywferia.Cloud.Inyeccion
{
    class ContenedorInyeccion
    {
        public static void ObtenerRegistros(IUnityContainer container)
        {
            RegistroRepositorios(container);

            RegistroLogicas(container); 
        }
 
        #region LOGICA

        /// <summary>
        /// RegistroLogicas
        /// </summary>
        /// <param name="container">container</param>
        private static void RegistroLogicas(IUnityContainer container)
        {
            container.RegisterType<ILog_Usuarios, Log_Usuarios>(new TransientLifetimeManager());
        }
        #endregion
        #region REPOSITORIO 
        /// <summary>
        /// RegistroRepositorios
        /// </summary>
        /// <param name="container">container</param>
        private static void RegistroRepositorios(IUnityContainer container)
        {
            container.RegisterType<IAD_usuario, AD_usuario>(new TransientLifetimeManager());
        }
        #endregion
    }
}
