using Microsoft.AspNetCore.Mvc;
using Ywferia.Cloud.AppWeb.Models.Genericos;
using Ywferia.Cloud.Inyeccion;
using Ywferia.Cloud.Logica.ILogica.IGenericos;
using Ywferia.Cloud.Utilitarios.Enumerados;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ywferia.Cloud.Modelo.Genericos;
using Ywferia.Cloud.AppWeb.Models.Models.Genericos;

namespace Ywferia.Cloud.AppWeb.Controllers
{
    public class GenericosController : Controller
    {
        private readonly ILog_TipoCorreo _TipoCorreo;
        private readonly IConfiguration _configuration;

        public GenericosController(IConfiguration configuration)
        {
            _TipoCorreo = Dependencia.Resolve<ILog_TipoCorreo>();
            _configuration = configuration;
        }

        public IActionResult TipoCorreo(TipoCorreoVM p_criterio)
        {
            return View(CreaModelo(p_criterio));
        }
        public IActionResult HistorialPuesto()
        {
            return View();
        }
        public IActionResult HistorialCorreo()
        {
            return View();
        }

        public ListTipoCorreoVM CreaModelo(TipoCorreoVM p_criterio = null, int pagina = 1,
                                                ColumnasJerarquiaUnidadFuncional orden = ColumnasJerarquiaUnidadFuncional.DescripcionNivelJerarquico,
                                                DireccionOrden direccion = DireccionOrden.Asc,
                                                RespuestaMantenimiento respuesta = RespuestaMantenimiento.Cancelar)
        {
            ViewData[AtributosPaginacion.Pagina.ToString()] = pagina;
            ViewData[AtributosPaginacion.Orden.ToString()] = orden;
            ViewData[AtributosPaginacion.DireccionOrden.ToString()] = direccion;

            var ListModelo = _TipoCorreo.Listado(esquema: _configuration.GetSection("ConfiguracionWebApp").GetSection("Genericosquema").Value, new C_TipoCorreo()
            {
                TipoCorreoId = p_criterio.TipoCorreoId,
                NombreTipo = p_criterio.NombreTipo,
                ActivoRows = p_criterio.ActivoRows
            });
            return new ListTipoCorreoVM(ListModelo);
        }

    }
}