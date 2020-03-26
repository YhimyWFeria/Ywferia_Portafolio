using System;
using System.Collections.Generic;
using System.Text;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.Modelo.Interfaces.Logica.Base
{
    public interface IRepositorio<T> where T : class
    {
        /// <summary>
        /// Crea un nuevo registro
        /// </summary>
        /// <param name="esquema"></param>
        /// <param name="item">objeto a registrar</param>
        /// <returns>codigo de error</returns>
        string Guardar(string esquema, T item);

        /// <summary>
        /// Modifica un registro
        /// </summary>
        /// <param name="esquema"></param>
        /// <param name="item">objeto a registrar</param>
        /// <returns>codigo de error</returns>
        string Modificar(string esquema, T item);

        /// <summary>
        /// Elimina un registro
        /// </summary>
        /// <param name="esquema"></param>
        /// <param name="id">codigo a eliminar</param>
        /// <returns>codigo de error</returns>
        string Eliminar(string esquema, string id);

    
        /// <summary>
        /// Consulta una lista de objetos
        /// </summary>
        /// <param name="esquema"></param>
        /// <param name="criterio">parametros de busqueda</param>
        /// <param name="pagina">nro de pagina a mostrar</param>
        /// <param name="elementosPorPagina">nro de elementos a mostrar</param>
        /// <param name="orden">orden de la consulta</param>
        /// <param name="direccion">direccion del orden</param>
        /// <returns>Lista de obajetos</returns>
        CollectionPage<T> Listado(string esquema, T criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc);

        /// <summary>
        /// Obtiene un registro
        /// </summary>
        /// <param name="esquema"></param>
        /// <param name="codigo">codigo de registro</param>
        /// <returns>objeto resultante</returns>
        T ObtenerPorId(string esquema, string codigo);
         

    }
}
