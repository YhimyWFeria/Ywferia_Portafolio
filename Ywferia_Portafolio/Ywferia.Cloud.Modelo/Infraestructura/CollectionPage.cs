using System;
using System.Collections.Generic;
using System.Text;

namespace Ywferia.Cloud.Modelo.Infraestructura
{
    /// <summary>
    /// Holds relevant information related to a page of a collection of information.
    /// </summary>
    public class CollectionPage<T>
    {
        /// <summary>
        /// A page of items.
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Total number of items, regardless of page.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// The number of items that should be shown per page.
        /// </summary>
        public int ItemsPorPagina { get; set; }

        /// <summary>
        /// The total number of pages.
        /// </summary>
        public int TotalPaginas()
        {
            return ItemsPorPagina == 0 ? 0 : Convert.ToInt32((Math.Ceiling(d: TotalItems / (Decimal)ItemsPorPagina)));
        }
    }
}
