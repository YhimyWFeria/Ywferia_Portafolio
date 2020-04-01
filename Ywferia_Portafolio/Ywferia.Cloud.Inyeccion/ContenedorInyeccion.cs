using Unity;
using Unity.Lifetime;
using Ywferia.Cloud.AccesoDatos.AccesoDatos.Genericos;
using Ywferia.Cloud.AccesoDatos.AccesoDatos.Proyecto;
using Ywferia.Cloud.AccesoDatos.AccesoDatos.Seguridad;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IGenericos;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IProyecto;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Logica.ILogica.IGenericos;
using Ywferia.Cloud.Logica.ILogica.IProyecto;
using Ywferia.Cloud.Logica.ILogica.ISeguridad;
using Ywferia.Cloud.Logica.Logica.Genericos;
using Ywferia.Cloud.Logica.Logica.Proyecto;
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
            container.RegisterType<ILog_TipoCorreo, Log_TipoCorreo>(new TransientLifetimeManager());
            container.RegisterType<ILog_Historial_Puestos, Log_Historial_Puestos>(new TransientLifetimeManager());
            container.RegisterType<ILog_Historial_correos, Log_Historial_correos>(new TransientLifetimeManager());
            container.RegisterType<ILog_Proj_Perfil, Log_Proj_Perfil>(new TransientLifetimeManager());
            container.RegisterType<ILog_Proj_Proyectos, Log_Proj_Proyectos>(new TransientLifetimeManager());
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
            container.RegisterType<IAD_Historial_correos, AD_Historial_correos>(new TransientLifetimeManager());
            container.RegisterType<IAD_Historial_Puestos, AD_Historial_Puestos>(new TransientLifetimeManager());
            container.RegisterType<IAD_TipoCorreo, AD_TipoCorreo>(new TransientLifetimeManager());
            container.RegisterType<IAD_Proj_Perfil, AD_Proj_Perfil>(new TransientLifetimeManager());
            container.RegisterType<IAD_Proj_Proyectos, AD_Proj_Proyectos>(new TransientLifetimeManager());
        }
        #endregion
    }
}
