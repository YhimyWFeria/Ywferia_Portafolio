using System; 

namespace Ywferia.Cloud.Modelo.Seguridad
{
   public class C_UsuariosCodigoView
    {
        public int UsuariosCodigoViewId { get; set; }
        public C_usuario Usuario { get; set; }
        public string CodigoGenerado { get; set; }
        public string Tip_NombreTipo { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime? DateDelete { get; set; }
        public bool ActivoRows { get; set; }
    }
}
