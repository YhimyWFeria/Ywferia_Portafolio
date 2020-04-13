using Microsoft.Data.SqlClient;
using System;
using System.Data;
using Ywferia.Cloud.AccesoDatos.DAccesoDatosConf;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Seguridad;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Seguridad
{
    public class AD_usuario : IAD_usuario
    {

        public string Eliminar(string esquema, string id)
        {
            return "";
        }
        public C_usuario GetSeguridadUsuario(string usuario)
        {
            C_usuario _Usuario = new C_usuario();

            using (SqlConnection connection = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(string.Format("{0}.{1}", AccesConfig.Esquema_seguridad, "uspGetTSeguridadUsuario"), connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter("@p_usuario", usuario));
                    var data = command.ExecuteReader();
                    if (data.HasRows)
                    {
                        while (data.Read())
                        {
                            _Usuario = new C_usuario
                            {
                                Seg_usuariosId = (int)data["Seg_usuariosId"],
                                Usu_Nombre = data["Usu_Nombre"].ToString(),
                                Usu_Contrasena = data["Usu_Contrasena"].ToString(),
                                Usu_TipoUsuario = data["Usu_TipoUsuario"].ToString()
                            };
                            _Usuario.TipoUsuario.Seg_TipoUsuarioId = (int)data["Seg_TipoUsuarioId"];
                            _Usuario.TipoUsuario.Tip_NombreTipo = data["Tip_NombreTipo"].ToString();
                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
            }

            return _Usuario;
        }

        public string Guardar(string esquema, C_usuario item)
        {
            return "";
        }

        public CollectionPage<C_usuario> Listado(string esquema, C_usuario criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            var mamam = new CollectionPage<C_usuario>();

            return mamam;
        }
        public string Modificar(string esquema, C_usuario item)
        {
            return "";
        }

        public C_usuario ObtenerPorId(string esquema, string codigo)
        {
            C_usuario _Usuario = new C_usuario();
            return _Usuario;
        }

        public C_usuario ObtenerPorId(string esquema, C_usuario item)
        {
            C_usuario _Usuario = new C_usuario();
            return _Usuario;
        }

        public int SeguridadLogin(string usuario, string pass)
        {
            int Output = 0;

            using (SqlConnection connection = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(string.Format("{0}.{1}", AccesConfig.Esquema_seguridad, "uspSeguridadLogin"), connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter("@p_usuario", usuario));
                    command.Parameters.Add(new SqlParameter("@p_pass", pass));
                    SqlParameter pvNewId = new SqlParameter
                    {
                        ParameterName = "@p_ValOutput",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(pvNewId);
                    command.ExecuteNonQuery();
                    Output = (int)command.Parameters["@p_ValOutput"].Value;
                }
                catch (Exception)
                {

                }
                finally
                {
                    connection.Close();
                }
            }

            return Output;
        }
    }
}
