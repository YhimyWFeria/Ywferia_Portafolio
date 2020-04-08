namespace Ywferia.Cloud.Modelo.Proyecto
{
    public class C_Proj_Proyectos
    {
        public int Proj_ProyectosId { get; set; }
        public string NombreProyect { get; set; }
        public string UrlAddress { get; set; }
        public string Descripcion { get; set; }
        public C_Proj_Perfil Proj_Perfil { get; set; }
    }
}
