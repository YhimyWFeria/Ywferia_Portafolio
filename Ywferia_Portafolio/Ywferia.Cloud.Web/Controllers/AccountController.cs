using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ywferia.Cloud.Inyeccion;
using Ywferia.Cloud.Logica.ILogica.ISeguridad;
using Ywferia.Cloud.Web.Models;
namespace Ywferia.Cloud.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILog_Usuarios _aDUsuario;

        private readonly SignInManager<LoginViewModels> SignManager;

        // GET: Account  
        public AccountController(SignInManager<LoginViewModels> _signManager)
        {
            _aDUsuario = Dependencia.Resolve<ILog_Usuarios>();
            this.SignManager = _signManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                var data = _aDUsuario.SeguridadLogin(model.Input.Usu_Nombre, model.Input.Usu_Contrasena);

                if (data == 1)
                {
                    var LoginAcccesData = new LoginViewModels
                    {
                        Input = _aDUsuario.GetSeguridadUsuario(model.Input.Usu_Nombre)
                    };

                    var result = await SignManager.PasswordSignInAsync(model.Input.Usu_Nombre, model.Input.Usu_Contrasena, false, false);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(model.Input.ReturnUrl) && Url.IsLocalUrl(model.Input.ReturnUrl))
                        {
                            return Redirect(model.Input.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}