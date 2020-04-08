using System;
using System.Collections.Generic;
using System.Linq;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Utilitarios.DataUtil
{
    public static class Varias
    {
        public const string FechaInicial = "01/01/0001";
        public const string FechaInicial2 = "01/01/1900";

        public static string FormatObjectSQL(string esquema, string ObjectSQL)
        {
            return string.Format("{0}.{1}", esquema, ObjectSQL);
        }
        public static IEnumerable<T> OrdenarPorColumna<T>(this IEnumerable<T> lista, string orden = "", DireccionOrden direccion = DireccionOrden.Asc) where T : class
        {
            IEnumerable<T> listaAux = lista;
            if (orden == "") return listaAux;
            var campoOrden = orden;
            var delegado = typeof(T).GetProperty(campoOrden);

            listaAux = direccion == DireccionOrden.Asc ? listaAux.OrderBy(x => delegado.GetValue(x, null)).ToList() : listaAux.OrderByDescending(x => delegado.GetValue(x, null)).ToList();

            return listaAux;
        }
        public static string ConvierteACadena(this DateTime? valor)
        {
            //if (valor == null) return string.Empty;
            if (valor.ToString().Contains(FechaInicial) || valor.ToString().Contains(FechaInicial2))
                return string.Empty;
            return valor.Value.ToString("dd/MM/yyyy");
        }

        public static string ConvierteACadena(this DateTime valor)
        {
            //if (valor == null) return string.Empty;
            if (valor.ToString().Contains(FechaInicial) || valor.ToString().Contains(FechaInicial2))
                return string.Empty;
            return valor.ToString("dd/MM/yyyy");
        }
        public static string ConvierteACadena(this decimal? valor)
        {
            var resultado = "0";

            if (valor != null)
                resultado = valor.ToString();

            return resultado;
        }

        public static string ConvierteACadena(this byte? valor)
        {
            var resultado = "0";

            if (valor != null)
                resultado = valor.ToString();

            return resultado;
        }

        public static string ConvierteACadena(this float? valor)
        {
            var resultado = "0";

            if (valor != null)
                resultado = valor.ToString();

            return resultado;
        }

    }
}
