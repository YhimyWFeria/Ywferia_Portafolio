using System; 
namespace Ywferia.Cloud.Modelo.Genericos
{
    public class C_Modulos
    {
        public int ModulosId { get; set; }
        public string NombreModulo { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime? DateDelete { get; set; }
        public bool ActivoRows { get; set; }
    }
}
