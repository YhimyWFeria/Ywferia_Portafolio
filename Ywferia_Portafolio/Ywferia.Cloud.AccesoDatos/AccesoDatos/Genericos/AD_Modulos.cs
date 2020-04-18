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
    public class AD_Modulos : IAD_Modulos
    {
        public string Eliminar(string esquema, string id)
        {
            string retorno = "";
            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspDelModulos"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ModulosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = id });
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

        public string Guardar(string esquema, C_Modulos item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspInsertModulos"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@NombreModulo", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.NombreModulo });
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

        public CollectionPage<C_Modulos> Listado(string esquema, C_Modulos criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            List<C_Modulos> _ListModulos = new List<C_Modulos>();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListModulos"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _ListModulos.Add(new C_Modulos
                            {
                                ModulosId = DataUtility.ObjectToInt(dr["ModulosId"]),
                                NombreModulo = DataUtility.ObjectToString(dr["NombreModulo"]).Trim(),
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
            if (_ListModulos.Count > 0) { Varias.OrdenarPorColumna(_ListModulos, orden, direccion); }

            return new CollectionPage<C_Modulos>
            {
                ItemsPorPagina = elementosPorPagina.GetHashCode(),
                Items = _ListModulos

            };
        }

        public string Modificar(string esquema, C_Modulos item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspUpdModulos"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@ModulosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.ModulosId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@NombreModulo", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.NombreModulo });
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

        public C_Modulos ObtenerPorId(string esquema, string codigo)
        {
            C_Modulos modulos = new C_Modulos();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListModulosbyId"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.Add(new SqlParameter() { ParameterName = "@TipoCorreoId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = codigo });

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            modulos.ModulosId = DataUtility.ObjectToInt(dr["TipoCorreoId"]);
                            modulos.NombreModulo = DataUtility.ObjectToString(dr["NombreTipo"]).Trim();
                            modulos.DateInsert = DataUtility.ObjectToDateTimeNull(dr["DateInsert"]);
                            modulos.DateUpdate = DataUtility.ObjectToDateTimeNull(dr["DateUpdate"]);
                            modulos.DateDelete = DataUtility.ObjectToDateTimeNull(dr["DateDelete"]);
                            modulos.ActivoRows = DataUtility.ObjectToBool(dr["ActivoRows"]);

                        }
                    }

                }
                finally
                {
                    cn.Close();
                }
            }
            return modulos;
        }
    }
}
