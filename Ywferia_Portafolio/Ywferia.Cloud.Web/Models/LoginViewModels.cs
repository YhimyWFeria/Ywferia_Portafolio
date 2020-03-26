using Microsoft.AspNetCore.Mvc; 
using Ywferia.Cloud.Modelo.Seguridad;

namespace Ywferia.Cloud.Web.Models
{
    public class LoginViewModels
    {
        [BindProperty]
        public C_usuario Input { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
    }
}
