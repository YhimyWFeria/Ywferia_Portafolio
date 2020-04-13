
using System;
using Ywferia.Cloud.Modelo.Genericos;

namespace Ywferia.Cloud.Modelo.Proyecto
{
    public class C_Proj_Perfil
    {
        public C_Proj_Perfil()
        {
            Historial_Puestos = new C_Historial_Puestos();
            Historial_correos = new C_Historial_correos();
        }
        public int Proj_PerfilId { get; set; }
        public C_Historial_Puestos Historial_Puestos { get; set; }
        public string UbicacionActual { get; set; }
        public string Descripcion_Perfil { get; set; }
        public C_Historial_correos Historial_correos { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime? DateDelete { get; set; }
        public bool ActivoRows { get; set; }
    }
}
