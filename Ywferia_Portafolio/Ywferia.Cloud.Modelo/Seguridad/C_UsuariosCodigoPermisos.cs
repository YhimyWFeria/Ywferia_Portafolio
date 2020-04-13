using System; 
using Ywferia.Cloud.Modelo.Genericos;

namespace Ywferia.Cloud.Modelo.Seguridad
{
   public class C_UsuariosCodigoPermisos
    {
        public int UsuariosCodigoPermisosId { get; set; }
        public C_UsuariosCodigoView UsuariosCodigoView { get; set; }
        public C_Modulos  Modulos { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime? DateDelete { get; set; }
        public bool ActivoRows { get; set; }
    }
}
