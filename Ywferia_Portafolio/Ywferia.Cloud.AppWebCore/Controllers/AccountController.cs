
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
                var ResponseLogin = _aDUsuario.SeguridadLogin(model.Input.Usu_Nombre, model.Input.Usu_Contrasena);

                if (ResponseLogin == 1)
                {

                    var ResponseGetDate = _aDUsuario.GetSeguridadUsuario(model.Input.Usu_Nombre);

                    Microsoft.AspNetCore.Identity.SignInResult actionResult;
                    if (ResponseGetDate.TipoUsuario.Seg_TipoUsuarioId == 1)
                    {
                       // IdentityUser identity = new IdentityUser() { EmailConfirmed = false, UserName = "yferia@sapia.com.pe", Email = "yferia@sapia.com.pe", PhoneNumber = "9", PhoneNumberConfirmed = false  };
                        actionResult = await _signInManager.PasswordSignInAsync("yferia@sapia.com.pe", "P@ssw0rd", false, false);
                    }
                    else
                    {
                        actionResult = await _signInManager.PasswordSignInAsync("invitado@ver.com.pe", "P@ssw0rd", false, false);
                    }
                    if (actionResult.Succeeded)
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
                    ModelState.AddModelError("", "Invalid login attempt");
                    model.ErrorMessage = "Usuario o contraseña Incorrecta.";
                    return View("Index", model);
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            model.ErrorMessage = "Login falido intentalo nuevamente";
            return View("Index", model);
        }
    }
}