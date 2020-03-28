
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Ywferia.Cloud.AppWebCore.Models;
using Ywferia.Cloud.Inyeccion;
using Ywferia.Cloud.Logica.ILogica.ISeguridad;

namespace Ywferia.Cloud.AppWebCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ILog_Usuarios _aDUsuario;
        public AccountController(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
            _aDUsuario = Dependencia.Resolve<ILog_Usuarios>();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                var data = _aDUsuario.SeguridadLogin(model.Input.Usu_Nombre, model.Input.Usu_Contrasena);

                if( data == 1)
                {
                    var result = await _signInManager.PasswordSignInAsync("yferia@sapia.com.pe", "P@ssw0rd", false, false);

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
                else
                {

                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            model.ErrorMessage = "Login fallido intentalo nuevamente";
            return View(model);
        }
    }
}