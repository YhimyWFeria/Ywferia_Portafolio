using AutoMapper;
using System;
using Ywferia.Cloud.AppWeb.Models.Models.General;
using Ywferia.Cloud.Modelo.Genericos;
using Ywferia.Cloud.Modelo.Infraestructura;
using Ywferia.Cloud.Utilitarios.Enumerados;

namespace Ywferia.Cloud.AppWeb.Models.Genericos
{
    public class ListTipoCorreoVM : BaseFiltro
    {

        public C_TipoCorreo Filtro { get; set; }
        public CollectionPage<C_TipoCorreo> Elementos;
        public RespuestaMantenimiento respuesta;

        public ListTipoCorreoVM()
        {
            Filtro = new C_TipoCorreo();
        }

        public ListTipoCorreoVM(CollectionPage<C_TipoCorreo> elementos)
        {
            Elementos = elementos;
        }
    }
}
