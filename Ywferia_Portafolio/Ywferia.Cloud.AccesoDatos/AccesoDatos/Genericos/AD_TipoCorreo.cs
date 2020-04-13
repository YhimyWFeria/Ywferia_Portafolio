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
    public class AD_TipoCorreo : IAD_TipoCorreo
    {
        public string Eliminar(string esquema, string id)
        {
            string retorno = "";
            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspDelTipoCorreo"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@TipoCorreoId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = id });
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

        public string Guardar(string esquema, C_TipoCorreo item)
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
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@NombreTipo", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.NombreTipo });
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

        public CollectionPage<C_TipoCorreo> Listado(string esquema, C_TipoCorreo criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "TipoCorreoId", DireccionOrden direccion = DireccionOrden.Asc)
        {
            List<C_TipoCorreo> _LisTipoCorreos = new List<C_TipoCorreo>();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListTipoCorreo"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _LisTipoCorreos.Add(new C_TipoCorreo
                            {
                                TipoCorreoId = DataUtility.ObjectToInt(dr["TipoCorreoId"]),
                                NombreTipo = DataUtility.ObjectToString(dr["NombreTipo"]).Trim(),
                                DateInsert = DataUtility.ObjectToDateTimeNull(dr["DateInsert"]),
                                DateUpdate = DataUtility.ObjectToDateTimeNull(dr["DateUpdate"]),
                                DateDelete = DataUtility.ObjectToDateTimeNull(dr["DateDelete"]),
                                ActivoRows = DataUtility.ObjectToBool(dr["ActivoRows"])
                            });
                        }
                    }
                }
                finally
                {
                    cn.Close();
                }
            }
            if (_LisTipoCorreos.Count > 0) { Varias.OrdenarPorColumna(_LisTipoCorreos, orden, direccion); }

            return new CollectionPage<C_TipoCorreo>
            {
                ItemsPorPagina = elementosPorPagina.GetHashCode(),
                Items = _LisTipoCorreos

            };
        }

        public string Modificar(string esquema, C_TipoCorreo item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspUpdTipoCorreo"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@TipoCorreoId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.TipoCorreoId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@NombreTipo", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.NombreTipo });
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

        public C_TipoCorreo ObtenerPorId(string esquema, string codigo)
        {
            C_TipoCorreo tipoCorreo = new C_TipoCorreo();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListTipoCorreobyId"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.Add(new SqlParameter() { ParameterName = "@TipoCorreoId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = codigo });

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tipoCorreo.TipoCorreoId = DataUtility.ObjectToInt(dr["TipoCorreoId"]);
                            tipoCorreo.NombreTipo = DataUtility.ObjectToString(dr["NombreTipo"]).Trim();
                            tipoCorreo.DateInsert = DataUtility.ObjectToDateTimeNull(dr["DateInsert"]);
                            tipoCorreo.DateUpdate = DataUtility.ObjectToDateTimeNull(dr["DateUpdate"]);
                            tipoCorreo.DateDelete = DataUtility.ObjectToDateTimeNull(dr["DateDelete"]);
                            tipoCorreo.ActivoRows = DataUtility.ObjectToBool(dr["ActivoRows"]);

                        }
                    }

                }
                finally
                {
                    cn.Close();
                }
            }
            return tipoCorreo;
        }
    }
}
