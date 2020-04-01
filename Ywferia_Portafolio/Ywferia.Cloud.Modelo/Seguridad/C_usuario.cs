
using System.ComponentModel.DataAnnotations;

namespace Ywferia.Cloud.Modelo.Seguridad
{
    public class C_usuario
    {
        public C_usuario()
        {
            TipoUsuario = new C_TipoUsuario();
        }
        public int Seg_usuariosId { get; set; }

        [Required(ErrorMessage = "<font color:'White'> Ingresar Nombre </font>")]
        public string Usu_Nombre { get; set; }
        [Required(ErrorMessage = "<font color:'White'> Ingresar Contraseña </font>")]
        [DataType(DataType.Password)]
        public string Usu_Contrasena { get; set; }
        public string Usu_TipoUsuario { get; set; }
        public C_TipoUsuario TipoUsuario { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
