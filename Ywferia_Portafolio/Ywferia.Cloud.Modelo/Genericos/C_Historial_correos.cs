
using System;

namespace Ywferia.Cloud.Modelo.Genericos
{
    public class C_Historial_correos
    {
        public C_Historial_correos()
        {
            V_TipoCorreos = new C_TipoCorreo();
        }
        public int Historial_correosId { get; set; }
        public string Mail { get; set; }
        public int Prioridad { get; set; }
        public C_TipoCorreo V_TipoCorreos { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime? DateDelete { get; set; }
        public bool ActivoRows { get; set; }
    }
}
