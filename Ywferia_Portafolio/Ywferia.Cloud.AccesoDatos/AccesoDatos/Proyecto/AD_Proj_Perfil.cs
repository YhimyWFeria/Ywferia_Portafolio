using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Ywferia.Cloud.AccesoDatos.DAccesoDatosConf;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IProyecto;
using Ywferia.Cloud.Modelo.Genericos;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Modelo.Proyecto;
using Ywferia.Cloud.Utilitarios.DataUtil;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Proyecto
{
    public class AD_Proj_Perfil : IAD_Proj_Perfil
    {
        public string Eliminar(string esquema, string id)
        {
            string retorno = "";
            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspDelProj_Perfil"), cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Proj_PerfilId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = id });
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

        public string Guardar(string esquema, C_Proj_Perfil item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspInsertProj_Perfil"), cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_PuestosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.Historial_Puestos.Historial_PuestosId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UbicacionActual", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.UbicacionActual });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Descripcion_Perfil", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Descripcion_Perfil });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_correosId", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Historial_correos.Historial_correosId });
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

        public CollectionPage<C_Proj_Perfil> Listado(string esquema, C_Proj_Perfil criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            List<C_Proj_Perfil> _LisHistorial_Puestos = new List<C_Proj_Perfil>();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListProj_Perfil"), cn);
                    command.CommandType = CommandType.StoredProcedure;

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _LisHistorial_Puestos.Add(new C_Proj_Perfil
                            {
                                Proj_PerfilId = DataUtility.ObjectToInt(dr["Proj_PerfilId"]),
                                Historial_Puestos = new C_Historial_Puestos() { Historial_PuestosId = DataUtility.ObjectToInt(dr["Historial_PuestosId"]), Nombre_HistoriaPuesto = DataUtility.ObjectToString(dr["Nombre_HistoriaPuesto"]) },
                                UbicacionActual = DataUtility.ObjectToString(dr["UbicacionActual"]),
                                Descripcion_Perfil = DataUtility.ObjectToString(dr["Descripcion_Perfil"]),
                                Historial_correos = new C_Historial_correos() { Historial_correosId = DataUtility.ObjectToInt(dr["Historial_correosId"]), Mail = DataUtility.ObjectToString(dr["mail"]), Prioridad = DataUtility.ObjectToInt(dr["prioridad"]), V_TipoCorreos = new C_TipoCorreo() { TipoCorreoId = DataUtility.ObjectToInt(dr["TipoCorreoId"]), NombreTipo = DataUtility.ObjectToString(dr["NombreTipo"]) } }
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

            return new CollectionPage<C_Proj_Perfil>
            {
                ItemsPorPagina = elementosPorPagina.GetHashCode(),
                Items = _LisHistorial_Puestos
            };
        }

        public string Modificar(string esquema, C_Proj_Perfil item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "usUpdProj_Perfil"), cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Proj_PerfilId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.Proj_PerfilId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_PuestosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.Historial_Puestos.Historial_PuestosId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@UbicacionActual", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.UbicacionActual });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Descripcion_Perfil", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Descripcion_Perfil });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_correosId", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Historial_correos.Historial_correosId });
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

        public C_Proj_Perfil ObtenerPorId(string esquema, string codigo)
        {
            C_Proj_Perfil Proj_Perfil = new C_Proj_Perfil();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListHistorial_PuestoSbyId"), cn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_PuestosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = codigo });

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Proj_Perfil = new C_Proj_Perfil()
                            {
                                Proj_PerfilId = DataUtility.ObjectToInt(dr["Proj_PerfilId"]),
                                Historial_Puestos = new C_Historial_Puestos() { Historial_PuestosId = DataUtility.ObjectToInt(dr["Historial_PuestosId"]), Nombre_HistoriaPuesto = DataUtility.ObjectToString(dr["Nombre_HistoriaPuesto"]) },
                                UbicacionActual = DataUtility.ObjectToString(dr["UbicacionActual"]),
                                Descripcion_Perfil = DataUtility.ObjectToString(dr["Descripcion_Perfil"]),
                                Historial_correos = new C_Historial_correos() { Historial_correosId = DataUtility.ObjectToInt(dr["Historial_correosId"]), Mail = DataUtility.ObjectToString(dr["mail"]), Prioridad = DataUtility.ObjectToInt(dr["prioridad"]), V_TipoCorreos = new C_TipoCorreo() { TipoCorreoId = DataUtility.ObjectToInt(dr["TipoCorreoId"]), NombreTipo = DataUtility.ObjectToString(dr["NombreTipo"]) } }

                            };
                        }
                    }

                }
                finally
                {
                    cn.Close();
                }
            }
            return Proj_Perfil;
        }
    }
}
