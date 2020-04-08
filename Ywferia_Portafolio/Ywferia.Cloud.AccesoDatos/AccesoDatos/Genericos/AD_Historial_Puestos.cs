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
    public class AD_Historial_Puestos : IAD_Historial_Puestos
    {
        public string Eliminar(string esquema, string id)
        {
            string retorno = "";
            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspDelHistorial_Puestos"), cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_PuestosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = id });
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

        public string Guardar(string esquema, C_Historial_Puestos item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspInsertHistorial_Puestos"), cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre_HistoriaPuesto", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Nombre_HistoriaPuesto });
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

        public CollectionPage<C_Historial_Puestos> Listado(string esquema, C_Historial_Puestos criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            List<C_Historial_Puestos> _LisHistorial_Puestos = new List<C_Historial_Puestos>();

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "uspListHistorial_Puestos"), cn);
                    command.CommandType = CommandType.StoredProcedure;

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _LisHistorial_Puestos.Add(new C_Historial_Puestos
                            {
                                Historial_PuestosId = DataUtility.ObjectToInt(dr["Historial_PuestosId"]),
                                Nombre_HistoriaPuesto = DataUtility.ObjectToString(dr["Nombre_HistoriaPuesto"]).Trim()
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

            return new CollectionPage<C_Historial_Puestos>
            {
                ItemsPorPagina = elementosPorPagina.GetHashCode(),
                Items = _LisHistorial_Puestos
            };
        }

        public string Modificar(string esquema, C_Historial_Puestos item)
        {
            string retorno = "";

            using (SqlConnection cn = new SqlConnection(AccesConfig.Cadena_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand(Varias.FormatObjectSQL(esquema, "usUpdHistorial_Puestos"), cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Historial_PuestosId", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = item.Historial_PuestosId });
                    command.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre_HistoriaPuesto", DbType = DbType.String, Direction = ParameterDirection.Input, Value = item.Nombre_HistoriaPuesto });
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

        public C_Historial_Puestos ObtenerPorId(string esquema, string codigo)
        {
            C_Historial_Puestos historial_Puestos = new C_Historial_Puestos();

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
                            historial_Puestos.Historial_PuestosId = DataUtility.ObjectToInt(dr["Historial_PuestosId"]);
                            historial_Puestos.Nombre_HistoriaPuesto = DataUtility.ObjectToString(dr["Nombre_HistoriaPuesto"]).Trim();

                        }
                    }

                }
                finally
                {
                    cn.Close();
                }
            }
            return historial_Puestos;
        }
    }
}
