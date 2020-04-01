using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Ywferia.Cloud.AccesoDatos.DAccesoDatosConf;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IGenericos;
using Ywferia.Cloud.Modelo.Genericos;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Utilitarios.DataUtil;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Genericos
{
    public class AD_Historial_correos : IAD_Historial_correos
    {
        public string Eliminar(string esquema, string id)
        {
            string retorno = "";
            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspDelHistorial_correos"), cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_correosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = id });
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

        public string Guardar(string esquema, C_Historial_correos item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspInsertHistorial_correos"), cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@mail", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Mail });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@prioridad", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Prioridad });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@TipoCorreoId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.V_TipoCorreos.TipoCorreoId });
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

        public CollectionPage<C_Historial_correos> Listado(string esquema, C_Historial_correos criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            List<C_Historial_correos> _LisHistorial_Puestos = new List<C_Historial_correos>();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListHistorial_correos"), cn);
                    command.CommandType = CommandType.StoredProcedure;

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _LisHistorial_Puestos.Add(new C_Historial_correos
                            {
                                Historial_correosId = DataUtility.ObjectToInt(dr["Historial_correosId"]),
                                Mail = DataUtility.ObjectToString(dr["mail"]).Trim(),
                                Prioridad = DataUtility.ObjectToInt(dr["prioridad"]),
                                V_TipoCorreos = new C_TipoCorreo() { TipoCorreoId = DataUtility.ObjectToInt(dr["TipoCorreoId"]), NombreTipo = DataUtility.ObjectToString(dr["NombreTipo"]).Trim() },

                            });
                        }
                    }
                }
                finally
                {
                    cn.Close();
                }
            }
            if (_LisHistorial_Puestos.Count > 0) { Varias.OrdenarPorColumna(_LisHistorial_Puestos, orden, direccion); }

            return new CollectionPage<C_Historial_correos>
            {
                ItemsPorPagina = elementosPorPagina.GetHashCode(),
                Items = _LisHistorial_Puestos
            };
        }

        public string Modificar(string esquema, C_Historial_correos item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "usUpdHistorial_correos"), cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_correosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.Historial_correosId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@mail", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Mail });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@prioridad", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Prioridad });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@TipoCorreoId", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.V_TipoCorreos.TipoCorreoId });
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

        public C_Historial_correos ObtenerPorId(string esquema, string codigo)
        {
            C_Historial_correos historial_correos = new C_Historial_correos();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListHistorial_correosbyId"), cn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_PuestosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = codigo });

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            historial_correos.Historial_correosId = DataUtility.ObjectToInt(dr["Historial_correosId"]);
                            historial_correos.Mail = DataUtility.ObjectToString(dr["mail"]).Trim();
                            historial_correos.Prioridad = DataUtility.ObjectToInt(dr["prioridad"]);
                            historial_correos.V_TipoCorreos = new C_TipoCorreo() { TipoCorreoId = DataUtility.ObjectToInt(dr["TipoCorreoId"]), NombreTipo = DataUtility.ObjectToString(dr["NombreTipo"]).Trim() };

                        }
                    }

                }
                finally
                {
                    cn.Close();
                }
            }
            return historial_correos;
        }
    }
}
