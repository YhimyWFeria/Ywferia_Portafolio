using System;
namespace Ywferia.Cloud.AppWebCore.Models.Genericos
{
    public class C_TipoCorreoVM
    { 
        public int TipoCorreoId { get; set; }
        public string NombreTipo { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime? DateDelete { get; set; }
        public bool ActivoRows { get; set; }
    }
}
