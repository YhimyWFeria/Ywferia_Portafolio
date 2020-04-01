using Ywferia.Cloud.Utilitarios.Recursos;
namespace Ywferia.Cloud.Utilitarios.Exportador
{
    public class ExportadorParametrosWeb
    {
        public string columnas { get; set; }
        public string columnasDisplay { get; set; }
        public Exportador.TipoArchivo tipoArchivo { get; set; }
        public string periodo { get; set; }
        public string tipoTrabajador { get; set; }
        public string GetStrTipoArchivo()
        {

            switch (this.tipoArchivo)
            {
                case Exportador.TipoArchivo.Excel:
                    return TiposArchivo.Excel;
                case Exportador.TipoArchivo.Pdf:
                    return TiposArchivo.Pdf;
                case Exportador.TipoArchivo.Texto:
                    return TiposArchivo.Texto;
                case Exportador.TipoArchivo.Word:
                    return TiposArchivo.Word;
            }

            return string.Empty;
        }

        public bool pdfHorizontal { get; set; }
    }
}
