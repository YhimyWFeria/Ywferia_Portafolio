using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
namespace Ywferia.Cloud.Utilitarios.ExcelUtility
{

    public class ExcelData
    {
        public Columns ColumnConfigurations { get; set; }
        public List<string> Headers { get; set; }
        public List<List<string>> DataRows { get; set; }
        public string NombreHoja { get; set; }

        public ExcelData()
        {
            Headers = new List<string>();
            DataRows = new List<List<string>>();
        }
    }
}
