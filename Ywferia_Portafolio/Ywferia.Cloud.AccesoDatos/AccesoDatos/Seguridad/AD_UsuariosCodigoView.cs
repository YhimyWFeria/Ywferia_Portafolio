using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Ywferia.Cloud.AccesoDatos.DAccesoDatosConf;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.ISeguridad;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Seguridad;
using Ywferia.Cloud.Utilitarios.DataUtil;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Seguridad
{
    public class AD_UsuariosCodigoView : IAD_UsuariosCodigoView
    {
        public string Eliminar(string esquema, string id)
        {
            string retorno = "";
            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspInsertUsuariosCodigoView"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UsuariosCodigoViewId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = id });
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

        public string Guardar(string esquema, C_UsuariosCodigoView item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspInsertUsuariosCodigoView"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Seg_usuarioId", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Usuario.Seg_usuariosId });
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

        public CollectionPage<C_UsuariosCodigoView> Listado(string esquema, C_UsuariosCodigoView criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            List<C_UsuariosCodigoView> _LisTipoCorreos = new List<C_UsuariosCodigoView>();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListUsuariosCodigoView"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Seg_usuarioId", DbType = DbType.String, Direction = ParameterDirection.Input, Value = criterio.Usuario.Seg_usuariosId });
                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _LisTipoCorreos.Add(new C_UsuariosCodigoView
                            {
                                UsuariosCodigoViewId = DataUtility.ObjectToInt(dr["UsuariosCodigoViewId"]),
                                CodigoGenerado = DataUtility.ObjectToString(dr["CodigoGenerado"]).Trim(),
                                DateInsert = DataUtility.ObjectToDateTimeNull(dr["DateInsert"]),
                                DateUpdate = DataUtility.ObjectToDateTimeNull(dr["DateUpdate"]),
                                DateDelete = DataUtility.ObjectToDateTimeNull(dr["DateDelete"]),
                                ActivoRows = DataUtility.ObjectToBool(dr["ActivoRows"]),
                                Usuario = new C_usuario() { Usu_Nombre = DataUtility.ObjectToString(dr["Usu_Nombre"]).Trim(), Usu_Contrasena = DataUtility.ObjectToString(dr["Usu_Contrasena"]).Trim(), TipoUsuario = new C_TipoUsuario { Seg_TipoUsuarioId = DataUtility.ObjectToInt(dr["Usu_TipoUsuario"]), Tip_NombreTipo = DataUtility.ObjectToString(dr["Tip_NombreTipo"]).Trim() } }

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

            return new CollectionPage<C_UsuariosCodigoView>
            {
                ItemsPorPagina = elementosPorPagina.GetHashCode(),
                Items = _LisTipoCorreos

            };
        }

        public string Modificar(string esquema, C_UsuariosCodigoView item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspUpdUsuariosCodigoView"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UsuariosCodigoViewId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.UsuariosCodigoViewId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Seg_usuarioId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.Usuario.Seg_usuariosId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@CodigoGenerado", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.CodigoGenerado });
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

        public C_UsuariosCodigoView ObtenerPorId(string esquema, string codigo)
        {
            throw new NotImplementedException();
        }

        public C_UsuariosCodigoView ObtenerPorId(string esquema, string codigo1, string codigo2)
        {
            C_UsuariosCodigoView UsuariosCodigoView = new C_UsuariosCodigoView();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListTipoCorreobyId"), cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Seg_usuariosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = codigo1 });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UsuariosCodigoViewId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = codigo2 });

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            UsuariosCodigoView.UsuariosCodigoViewId = DataUtility.ObjectToInt(dr["UsuariosCodigoViewId"]);
                            UsuariosCodigoView.CodigoGenerado = DataUtility.ObjectToString(dr["CodigoGenerado"]).Trim();
                            UsuariosCodigoView.DateInsert = DataUtility.ObjectToDateTimeNull(dr["DateInsert"]);
                            UsuariosCodigoView.DateUpdate = DataUtility.ObjectToDateTimeNull(dr["DateUpdate"]);
                            UsuariosCodigoView.DateDelete = DataUtility.ObjectToDateTimeNull(dr["DateDelete"]);
                            UsuariosCodigoView.ActivoRows = DataUtility.ObjectToBool(dr["ActivoRows"]);
                            UsuariosCodigoView.Usuario = new C_usuario() { Usu_Nombre = DataUtility.ObjectToString(dr["Usu_Nombre"]).Trim(), Usu_Contrasena = DataUtility.ObjectToString(dr["Usu_Contrasena"]).Trim(), TipoUsuario = new C_TipoUsuario { Seg_TipoUsuarioId = DataUtility.ObjectToInt(dr["Usu_TipoUsuario"]), Tip_NombreTipo = DataUtility.ObjectToString(dr["Tip_NombreTipo"]).Trim() } };

                        }
                    }

                }
                finally
                {
                    cn.Close();
                }
            }
            return UsuariosCodigoView;
        }
    }
}
