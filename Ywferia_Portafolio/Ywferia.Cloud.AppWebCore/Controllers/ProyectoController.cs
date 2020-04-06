using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ywferia.Cloud.AppWebCore.Controllers
{
    public class ProyectoController : Controller
    {
        public IActionResult Perfil()
        {
            return View();
        }
        public IActionResult Proyecto()
        {
            return View();
        }
        public IActionResult ViewProyectoGeneral()
        {
            return View();
        }
        public IActionResult ViewPerfilGeneral()
        {
            return View();
        }
    }
}