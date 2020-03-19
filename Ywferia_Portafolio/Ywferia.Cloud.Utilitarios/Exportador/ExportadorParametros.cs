using System;
using System.Collections.Generic;
using System.Text;

namespace Ywferia.Cloud.Utilitarios.Exportador
{
  
        public class ExportadorParametros
        {
            public IEnumerable<string> columnas { get; set; }
            public IEnumerable<string> columnasDisplay { get; set; }
            public string fileName { get; set; }
            public string titulo { get; set; }
            public string usuario { get; set; }
            public string periodo { get; set; }
            public string tipoTrabajador { get; set; }
            public string compania { get; set; }
            public string codigoCompania { get; set; }
            public Exportador.TipoArchivo tipoArchivo { get; set; }
            public string filtros { get; set; }
            public bool horizontal { get; set; }
            public List<int> indicesStyle { get; set; }
            public bool EsConsultaPlanilla { get; set; }
            public bool EsSinFiltros { get; set; }
            public static string parseFiltros(string labelFiltros, params object[] objetos)
            {
                string info = string.Empty;
                string[] arrLabelFiltros = labelFiltros.Split('|');
                //string flagMuestraFiltrosTodos = ConfigurationManager.AppSettings["RptGenericosMuestraFiltrosTodos"];
                string flagMuestraFiltrosTodos = "1";

                //Por default los muestra
                if (flagMuestraFiltrosTodos == null)
                {
                    flagMuestraFiltrosTodos = "1";
                }

                if (objetos.Length != arrLabelFiltros.Length)
                {
                    throw new Exception("ExportadorParametros.parseFiltros: La cantidad de valores en el parametro filtros debe ser igual al número de etiquetas concatenadas con '|' ");
                }

                for (int i = 0; i < arrLabelFiltros.Length; i++)
                {
                    object _nombreFiltro = arrLabelFiltros[i];
                    object _info = objetos[i];

                    if (_nombreFiltro != null)
                    {

                        if (flagMuestraFiltrosTodos == "1")
                        {
                            string nombreFiltro = _nombreFiltro.ToString();
                            string strInfo = _info == null ? " " : _info.ToString();
                            info += nombreFiltro + "|" + strInfo + "@@@";
                        }
                        else
                        {
                            if (_info != null)
                            {
                                string nombreFiltro = _nombreFiltro.ToString();
                                string strInfo = _info.ToString();
                                if (strInfo != string.Empty)
                                {
                                    info += nombreFiltro + "|" + strInfo + "@@@";
                                }
                            }
                        }
                    }
                }
                info = info.Substring(0, info.Length - 3);
                return info;
            }
        }

    }
 
