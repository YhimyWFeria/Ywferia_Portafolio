using System;
using System.Collections.Generic;
using System.Text;
using Ywferia.Cloud.AccesoDatos.IAccesosDatos.IGenericos;
using Ywferia.Cloud.Modelo.Genericos;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AccesoDatos.AccesoDatos.Genericos
{
    public class AD_Modulos : IAD_Modulos
    {
        public string Eliminar(string esquema, string id)
        {
            throw new NotImplementedException();
        }

        public string Guardar(string esquema, C_Modulos item)
        {
            throw new NotImplementedException();
        }

        public CollectionPage<C_Modulos> Listado(string esquema, C_Modulos criterio, int pagina = 0, TamanioPagina elementosPorPagina = TamanioPagina.Chico, string orden = "Id", DireccionOrden direccion = DireccionOrden.Asc)
        {
            throw new NotImplementedException();
        }

        public string Modificar(string esquema, C_Modulos item)
        {
            throw new NotImplementedException();
        }

        public C_Modulos ObtenerPorId(string esquema, string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
