using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ywferia.Cloud.Inyeccion;
using Ywferia.Cloud.Logica.ILogica.IGenericos;

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
    }
}