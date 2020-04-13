using Microsoft.AspNetCore.Mvc;
using Ywferia.Cloud.AppWebCore.Models.Genericos;
using Ywferia.Cloud.Inyeccion;
using Ywferia.Cloud.Logica.ILogica.IGenericos;
using Ywferia.Cloud.Utilitarios.Enumerados;
using System.Security.Claims;

namespace Ywferia.Cloud.AppWebCore.Controllers
{
    public class GenericosController : Controller
    {
        private readonly ILog_TipoCorreo _TipoCorreo;

        public GenericosController()
        {
            _TipoCorreo = Dependencia.Resolve<ILog_TipoCorreo>();
        }

        public IActionResult TipoCorreo()
        { 
            return View();
        }
        public IActionResult HistorialPuesto()
        {
            return View();
        }
        public IActionResult HistorialCorreo()
        {
            return View();
        }

        public C_TipoCorreoVM CreaModelo(C_TipoCorreoVM p_criterio, int pagina = 1,
                                                ColumnasJerarquiaUnidadFuncional orden = ColumnasJerarquiaUnidadFuncional.DescripcionNivelJerarquico,
                                                DireccionOrden direccion = DireccionOrden.Asc,
                                                RespuestaMantenimiento respuesta = RespuestaMantenimiento.Cancelar)
        {
            C_TipoCorreoVM criterio = p_criterio;

            ViewData[AtributosPaginacion.Pagina.ToString()] = pagina;
            ViewData[AtributosPaginacion.Orden.ToString()] = orden;
            ViewData[AtributosPaginacion.DireccionOrden.ToString()] = direccion;

             

            return criterio;
        }
    }
}