using Microsoft.Data.SqlClient;
using System;
using System.Data;
using Ywferia.Cloud.AccesoDatos.DAccesoDatosConf;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Seguridad;
using Ywferia.Cloud.Utilitarios.DataUtil;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Seguridad
{
    public class AD_UsuariosCodigoPermisos : IAD_UsuariosCodigoPermisos
    {
        public string Eliminar(string esquema, string id)
        {
            string retorno = "";
            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspDelUsuariosCodigoPermisos"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UsuariosCodigoPermisosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = id });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@as_error", DbType = DbType.String, Direction = ParameterDirection.Output });
                    command.ExecuteNonQuery();
                    retorno = command.Parameters["@as_error"].Value == null ? string.Empty : command.Parameters["@as_error"].Value.ToString();
                }
                finally
                {
                    cn.Close();
                }
            }
            return retorno;
        }

        public string Guardar(string esquema, C_UsuariosCodigoPermisos item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspInsertTipoCorreo"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UsuariosCodigoViewId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.UsuariosCodigoView.UsuariosCodigoViewId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ModulosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.Modulos.ModulosId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@as_error", DbType = DbType.String, Direction = ParameterDirection.Output });
                    command.ExecuteNonQuery();
                    retorno = command.Parameters["@as_error"].Value == null ? string.Empty : command.Parameters["@as_error"].Value.ToString();
                }
                finally
                {
                    cn.Close();
                }
            }

            return retorno;
        }

        public CollectionPage<C_UsuariosCodigoPermisos> Listado(string esquema, C_UsuariosCodigoPermisos criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            throw new NotImplementedException();
        }

        public string Modificar(string esquema, C_UsuariosCodigoPermisos item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspUpdUsuariosCodigoPermisos"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UsuariosCodigoPermisosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.UsuariosCodigoPermisosId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UsuariosCodigoViewId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.UsuariosCodigoView.UsuariosCodigoViewId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ModulosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.Modulos.ModulosId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@as_error", DbType = DbType.String, Direction = ParameterDirection.Output });
                    command.ExecuteNonQuery();
                    retorno = command.Parameters["@as_error"].Value == null ? string.Empty : command.Parameters["@as_error"].Value.ToString();
                }
                finally
                {
                    cn.Close();
                }
            }

            return retorno;
        }

        public C_UsuariosCodigoPermisos ObtenerPorId(string esquema, string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
