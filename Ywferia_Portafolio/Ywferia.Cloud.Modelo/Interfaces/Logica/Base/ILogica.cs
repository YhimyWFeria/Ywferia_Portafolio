using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Utilitarios.Enumerados;
namespace Ywferia.Cloud.Modelo.Interfaces.Logica.Base
{
    public interface ILogica<T> where T : class
    {
        /// <summary>
        /// crea o modifica un objeto
        /// </summary>
        /// <param name="esquema"></param>
        /// <param name="item">Objeto a registrar o modificar</param>
        /// <param name="accion"></param>
        /// <returns>codigo de error</returns>
        string Editar(string esquema, T item, AccionesMantenimiento accion);

        /// <summary>
        /// Elimina un registro
        /// </summary>
        /// <param name="esquema"></param>
        /// <param name="codigo">codigo a eliminar</param>        
        /// <returns>codigo de error</returns>
        string Eliminar(string esquema, string codigo);



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
        CollectionPage<T> Listado(string esquema, T criterio = null, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "", DireccionOrden direccion = DireccionOrden.Asc);

        /// <summary>
        /// Obtiene un registro
        /// </summary>
        /// <param name="esquema"></param>
        /// <param name="codigo">codigo de registro</param>
        /// <returns>objeto resultante</returns>
        T ObtenerPorId(string esquema, string codigo);
    }
}
