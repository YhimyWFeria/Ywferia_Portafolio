using System;
using System.Text;

namespace Ywferia.Cloud.Utilitarios.Extenciones
{
    public static class Codificar
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string Codifica(string cadena)
        {
            return string.IsNullOrEmpty(cadena) ? string.Empty : BitConverter.ToString(Encoding.ASCII.GetBytes(Encriptar(cadena))).Replace("-", string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codificado">parametro encriptado</param>
        /// <returns></returns>
        public static string DeCodificar(string codificado)
        {
            if (codificado == "RESUMEN GENERAL") return string.Empty;

            if (string.IsNullOrEmpty(codificado)) return string.Empty;

            var arr = new String[codificado.Length / 2];// = codificado.Split('-');
            var j = 0;
            for (var i = 0; i < codificado.Length; i += 2)
            {
                arr[j] = codificado.Substring(i, 2);
                j++;
            }

            var array = new byte[arr.Length];
            for (var i = 0; i < arr.Length; i++) array[i] = Convert.ToByte(arr[i], 16);

            var nuevoOrigen = Encoding.ASCII.GetString(array);
            var desencriptado = DesEncriptar(nuevoOrigen);
            return desencriptado;
        }

        /// <summary>
        /// Encripta una cadena
        /// </summary>
        /// <param name="cadenaAencriptar"></param>
        /// <returns></returns>
        private static string Encriptar(string cadenaAencriptar)
        {
            var encryted = Encoding.Unicode.GetBytes(cadenaAencriptar);
            return Convert.ToBase64String(encryted);
        }

        /// <summary>
        /// Desencripta una cadena
        /// </summary>
        /// <param name="cadenaAdesencriptar"></param>
        /// <returns></returns>
        public static string DesEncriptar(string cadenaAdesencriptar)
        {
            var decryted = Convert.FromBase64String(cadenaAdesencriptar);
            return Encoding.Unicode.GetString(decryted);
        }
    }
}
