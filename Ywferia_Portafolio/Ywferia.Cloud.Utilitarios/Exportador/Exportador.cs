using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
namespace Ywferia.Cloud.Utilitarios.Exportador
{
    public class Exportador
    {
        private const string creadorPdf = "Ywferias.Cloud";
        public enum TipoArchivo
        {
            Excel,
            Pdf,
            Texto,
            Word
        };

        public static byte[] Exportar(DataTable dt, ExportadorParametros parametros, string rutabase)
        {
            byte[] returnValue = null;

            try
            {
                if (dt == null)
                {
                    throw new Exception("Exportar: datatable es null");
                }
                //if (dt.Rows.Count < 1)
                //{
                //    throw new Exception("Exportar: No hay filas en DataTable");
                //}
                if (parametros.fileName == null)
                {
                    throw new Exception("Exportar: fileName es null");
                }
                if (parametros.titulo == null)
                {
                    throw new Exception("Exportar: titulo es null");
                }
                if (parametros.usuario == null)
                {
                    throw new Exception("Exportar: usuario es null");
                }
                if (parametros.columnas.Count() < 1)
                {
                    throw new Exception("Exportar: columnas no tiene datos");
                }
                if (parametros.columnasDisplay.Count() < 1)
                {
                    throw new Exception("Exportar: columnasDisplay no tiene datos");
                }
                if (parametros.columnas.Count() != parametros.columnasDisplay.Count())
                {
                    throw new Exception("Exportar: el tamaño de columnas debe ser igual al de columnasDisplay");
                }
                if (parametros.codigoCompania == null)
                {
                    throw new Exception("Exportar: no se envió el codigo de compañía (codigoCompania es null)");
                }
                if (parametros.codigoCompania == string.Empty)
                {
                    throw new Exception("Exportar: no se envió el codigo de compañía (codigoCompania está vacío)");
                }
                if (!parametros.EsSinFiltros)
                {
                    if (parametros.filtros == null)
                    {
                        throw new Exception("Exportar: no se enviaron los filtros del reporte (filtros es null)");
                    }
                    if (parametros.filtros.Count() < 1)
                    {
                        throw new Exception("Exportar: no se enviaron los filtros del reporte (filtros está vacío)");
                    }
                }

                parametros.fileName = String.Format(parametros.fileName, DateTime.Now.ToString("yyyyMMddHHmmss"));

                switch (parametros.tipoArchivo)
                {
                    case TipoArchivo.Excel:
                        returnValue = ExportarExcel(dt, parametros, rutabase);
                        break;
                    case TipoArchivo.Pdf:
                        //  returnValue = ExportarPdf(dt, parametros,);
                        break;
                }

            }
            catch (Exception ex)
            {
                //Varias.EscribeLog(ex);
                throw ex;
            }

            if (returnValue == null)
            {
                throw new Exception("Exportar: No se pudo obtener data para el archivo (valor de retorno null)");
            }

            return returnValue;
        }

        public static byte[] Exportar<T>(IList<T> data, ExportadorParametros parametros, string rutabase)
        {

            byte[] returnValue = null;

            try
            {
                if (data == null)
                {
                    throw new Exception("Exportar: data es null");
                }
                //if(data.Count < 1) {

                //    //throw new Exception("Exportar: no hay datos en la lista (data.Count < 1)");
                //}
                if (parametros.fileName == null)
                {
                    throw new Exception("Exportar: fileName es null");
                }
                if (parametros.titulo == null)
                {
                    throw new Exception("Exportar: titulo es null");
                }
                if (parametros.usuario == null)
                {
                    throw new Exception("Exportar: usuario es null");
                }
                if (parametros.columnas.Count() < 1)
                {
                    throw new Exception("Exportar: columnas no tiene datos");
                }
                if (parametros.columnasDisplay.Count() < 1)
                {
                    throw new Exception("Exportar: columnasDisplay no tiene datos");
                }
                if (parametros.columnas.Count() != parametros.columnasDisplay.Count())
                {
                    throw new Exception("Exportar: el tamaño de columnas debe ser igual al de columnasDisplay");
                }
                if (parametros.codigoCompania == null)
                {
                    throw new Exception("Exportar: no se envió el codigo de compañía (codigoCompania es null)");
                }
                if (parametros.codigoCompania == string.Empty)
                {
                    throw new Exception("Exportar: no se envió el codigo de compañía (codigoCompania está vacío)");
                }
                if (parametros.filtros == null)
                {
                    throw new Exception("Exportar: no se enviaron los filtros del reporte (filtros es null)");
                }
                if (parametros.filtros.Count() < 1)
                {
                    throw new Exception("Exportar: no se enviaron los filtros del reporte (filtros está vacío)");
                }


                parametros.fileName = String.Format(parametros.fileName, DateTime.Now.ToString("yyyyMMddHHmmss"));

                DataTable dt = Helper.ConvertToDataTable(data);

                if (typeof(T) != typeof(object[]) && typeof(T) != typeof(List<string>))
                {
                    dt = Helper.WithColumns(dt, parametros.columnas, parametros.columnasDisplay);
                }

                switch (parametros.tipoArchivo)
                {
                    case TipoArchivo.Excel:
                        returnValue = ExportarExcel(dt, parametros, rutabase);
                        break;
                        //case TipoArchivo.Pdf:
                        //    returnValue = ExportarPdf(dt, parametros);
                        //    break;
                        //case TipoArchivo.Texto:
                        //    returnValue = ExportarTxt(dt, parametros);

                }

            }
            catch (Exception ex)
            {
                //Varias.EscribeLog(ex);
                throw ex;
            }

            if (returnValue == null)
            {
                throw new Exception("Exportar: No se pudo obtener data para el archivo (valor de retorno null)");
            }

            return returnValue;
        }

        public static byte[] ExportarExcel(DataTable dt, ExportadorParametros parametros, string rutabase)
        {

            string flagEmpre = "1";
            string rutaLogo = "";// ConfigurationManager.AppSettings["RptGenericosLogoEmpreRuta"];
            string nombreLogo = "";// ConfigurationManager.AppSettings["RptGenericosNombreLogoRuta"];
            string tamanio = "";//ConfigurationManager.AppSettings["RptGenericosLogoTamanio_Excel"];
            string ruta = string.Empty;

            if (flagEmpre == null)
            {
                flagEmpre = "0";
            }
            else if (flagEmpre == "1")
            {
                if (rutaLogo == null)
                {
                    throw new Exception("Exportar: No se configuró la ruta del logo. Ver la llave RptGenericosLogoEmpreRuta en web.config (la ruta debe tener '/' al final)");
                }
                if (nombreLogo == null)
                {
                    throw new Exception("Exportar: No se configuró el nombre del logo. Ver la llave RptGenericosNombreLogoRuta en web.config");
                }

                ruta = rutabase + rutaLogo + parametros.codigoCompania + "/" + nombreLogo;

            }

            byte[] value = null;
            //url = string.Format(parametros.fileName, DateTime.Now.ToString("yyyyMMddHHmmss"));

            try
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Hoja1");


                    ws.Cells[3, 1, 3, dt.Columns.Count].Merge = true;
                    ws.Cells[3, 1, 3, dt.Columns.Count].Style.Font.Bold = true;
                    ws.Cells[3, 1, 3, dt.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, 1, 3, dt.Columns.Count].Style.Font.Size = 20;
                    ws.Cells[3, 1, 3, dt.Columns.Count].Style.Font.Name = "Calibri";
                    ws.Cells[3, 1, 3, dt.Columns.Count].Value = parametros.titulo;

                    if (parametros.EsConsultaPlanilla)
                    {
                        ws.Row(3).Height = 100;
                        ws.Cells[3, 1, 3, dt.Columns.Count].Style.Font.Size = 11;
                        ws.Cells[3, 1, 3, dt.Columns.Count].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    ws.Cells[1, dt.Columns.Count, 1, dt.Columns.Count].Style.Font.Size = 10;
                    ws.Cells[1, dt.Columns.Count, 1, dt.Columns.Count].Style.Font.Name = "Calibri";
                    ws.Cells[1, dt.Columns.Count, 1, dt.Columns.Count].Style.Font.Bold = true;
                    ws.Cells[1, dt.Columns.Count, 1, dt.Columns.Count].Value = "Fecha y hora: " + DateTime.Now.ToString("dd/MM/yyyy - HH:mm");

                    ws.Cells[2, dt.Columns.Count, 2, dt.Columns.Count].Style.Font.Size = 10;
                    ws.Cells[2, dt.Columns.Count, 2, dt.Columns.Count].Style.Font.Name = "Calibri";
                    ws.Cells[2, dt.Columns.Count, 2, dt.Columns.Count].Style.Font.Bold = true;
                    ws.Cells[2, dt.Columns.Count, 2, dt.Columns.Count].Value = "Usuario: " + parametros.usuario;

                    //if(parametros.periodo != null && parametros.tipoTrabajador != null) {
                    //    ws.Cells[4, 1, 4, 1].Style.Font.Size = 10;
                    //    ws.Cells[4, 1, 4, 1].Style.Font.Name = "Calibri";
                    //    ws.Cells[4, 1, 4, 1].Style.Font.Bold = true;
                    //    ws.Cells[4, 1, 4, 1].Value = "Periodo: " + parametros.periodo;

                    //    ws.Cells[5, 1, 5, 1].Style.Font.Size = 10;
                    //    ws.Cells[5, 1, 5, 1].Style.Font.Name = "Calibri";
                    //    ws.Cells[5, 1, 5, 1].Style.Font.Bold = true;
                    //    ws.Cells[5, 1, 5, 1].Value = "Tipo Trabajador: " + parametros.tipoTrabajador;
                    //} else if(parametros.periodo == null && parametros.tipoTrabajador != null) {
                    //    ws.Cells[4, 1, 4, 1].Style.Font.Size = 10;
                    //    ws.Cells[4, 1, 4, 1].Style.Font.Name = "Calibri";
                    //    ws.Cells[4, 1, 4, 1].Style.Font.Bold = true;
                    //    ws.Cells[4, 1, 4, 1].Value = "Tipo Trabajador: " + parametros.tipoTrabajador;
                    //} else if (parametros.periodo != null && parametros.tipoTrabajador == null) {
                    //    ws.Cells[4, 1, 4, 1].Style.Font.Size = 10;
                    //    ws.Cells[4, 1, 4, 1].Style.Font.Name = "Calibri";
                    //    ws.Cells[4, 1, 4, 1].Style.Font.Bold = true;
                    //    ws.Cells[4, 1, 4, 1].Value = "Periodo: " + parametros.periodo;
                    //}



                    if (flagEmpre == "1")
                    {
                        FileInfo image = new FileInfo(ruta);
                        var picture = ws.Drawings.AddPicture("0", image);

                        int w = 150;
                        int h = 50;

                        if (tamanio != null)
                        {
                            string[] _data = tamanio.Split('|');
                            w = Int32.Parse(_data[0]);
                            h = Int32.Parse(_data[1]);
                        }

                        picture.SetSize(w, h);
                        picture.SetPosition(0, 0, 0, 0);
                    }
                    else
                    {
                        if (parametros.compania == null)
                        {
                            throw new Exception("Exportar: compania es null");
                        }

                        ws.Cells[1, 1, 1, 1].Style.Font.Size = 10;
                        ws.Cells[1, 1, 1, 1].Style.Font.Name = "Calibri";
                        ws.Cells[1, 1, 1, 1].Style.Font.Bold = true;
                        ws.Cells[1, 1, 1, 1].Value = "Empresa: " + parametros.compania;
                    }

                    /* Filtros */
                    int begin_row = 5;

                    string[] dataFiltros = parametros.filtros.Split(new string[] { "@@@" }, StringSplitOptions.None);
                    int ncol = dt.Columns.Count % 2 == 0 ? dt.Columns.Count : dt.Columns.Count - 1;
                    for (int i = 0, j = 1, k = 2; i < dataFiltros.Length; i++, j += 2, k += 2)
                    {
                        if (dataFiltros[i] != null && dataFiltros[i] != string.Empty)
                        {
                            string[] item = dataFiltros[i].Split('|');
                            string label = item[0];
                            string __val = item[1];
                            ws.Cells[begin_row, j].Value = label;
                            ws.Cells[begin_row, k].Value = __val;

                            setEstiloParametroCelda(ws.Cells[begin_row, j]);
                            setEstiloParametroCelda(ws.Cells[begin_row, k]);

                            if (k != 0 && k % ncol == 0)
                            {
                                begin_row++;
                                j = -1;
                                k = 0;
                            }
                        }

                    }
                    begin_row += 2;




                    ws.Cells[begin_row, 1].LoadFromDataTable(dt, true);

                    System.Drawing.Color black = ColorTranslator.FromHtml("#000000");
                    Color white = ColorTranslator.FromHtml("#FFFFFF");
                    Color fondoAzul = ColorTranslator.FromHtml("#00008b");
                    Color fondoOscuro1 = ColorTranslator.FromHtml("#595959");
                    Color fondoOscuro2 = ColorTranslator.FromHtml("#3a3a3a");
                    Color fondoOscuro3 = ColorTranslator.FromHtml("#aaaaaa");
                    if (dt.Rows.Count == 0)
                    {
                        ws.Cells[begin_row + 1, 1].Value = "No se encontró data en la tabla";
                        ws.Cells[begin_row + 1, 1, begin_row + 1, dt.Columns.Count].Merge = true;
                        ws.Cells[begin_row + 1, 1, begin_row + 1, dt.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }


                    ws.Cells[begin_row, 1, begin_row, dt.Columns.Count].Style.Font.Bold = true;
                    ws.Cells[begin_row, 1, begin_row, dt.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[begin_row, 1, begin_row, dt.Columns.Count].Style.Font.Color.SetColor(white);
                    ws.Cells[begin_row, 1, begin_row, dt.Columns.Count].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[begin_row, 1, begin_row, dt.Columns.Count].Style.Fill.BackgroundColor.SetColor(fondoAzul);

                    if (parametros.indicesStyle != null && parametros.indicesStyle.Count > 0)
                    {

                        for (int i = 0; i < parametros.indicesStyle.Count; i++)
                        {
                            int x = parametros.indicesStyle[i] + begin_row + 1;// +1 por la fila del titulo, +1 por la fila de los titulos de cabecera y +1 por que los indices en excel empiezan en 1 y no en 0
                            int xnext = (i + 1) >= parametros.indicesStyle.Count ? x + 1 : parametros.indicesStyle[i + 1] + 3;
                            int xprev = (i - 1) > -1 ? parametros.indicesStyle[i - 1] + 3 : x;

                            ws.Cells[x, 1, x, dt.Columns.Count].Style.Fill.PatternType = ExcelFillStyle.Solid;

                            if (ws.Cells[x, 1, x, 1].Value != null && ws.Cells[x, 1, x, 1].Value.ToString().Trim().Contains("TOTAL"))
                            {//Los totales siempre estan juntos, por eso es q la distancia entre esos es igual a 1
                             //Total
                                ws.Cells[x, 1, x, dt.Columns.Count].Style.Fill.BackgroundColor.SetColor(fondoOscuro3);
                                ws.Cells[x, 1, x, dt.Columns.Count].Style.Font.Size = 11;
                            }
                            else
                            {
                                ws.Cells[x, 1, x, dt.Columns.Count].Style.Fill.BackgroundColor.SetColor(fondoOscuro2);
                                ws.Cells[x, 1, x, dt.Columns.Count].Style.Font.Size = 12;
                            }


                            ws.Cells[x, 1, x, dt.Columns.Count].Style.Font.Color.SetColor(white);
                            ws.Cells[x, 1, x, dt.Columns.Count].Style.Font.Bold = true;




                        }
                    }
                    else if (parametros.EsConsultaPlanilla)
                    {
                        for (int i = begin_row; i <= ws.Dimension.Rows; i++)
                        {
                            int c = ws.Dimension.Columns;
                            string cell_val_1 = ws.Cells[i, 1].Value == null ? string.Empty : ws.Cells[i, 1].Value.ToString();
                            string cell_val_2 = ws.Cells[i, 2].Value == null ? string.Empty : ws.Cells[i, 2].Value.ToString();
                            string cell_val_3 = ws.Cells[i, c - 1].Value == null ? string.Empty : ws.Cells[i, c - 1].Value.ToString();
                            string cell_val_4 = ws.Cells[i, c].Value == null ? string.Empty : ws.Cells[i, c].Value.ToString();


                            double valcol = -1;
                            if (Double.TryParse(cell_val_4, out valcol))
                            {
                                ws.Cells[i, 4].Value = valcol;
                                ws.Cells[i, 4].Style.Numberformat.Format = "0.00";
                            }

                            for (int j = 1; j <= ws.Dimension.Columns; j++)
                            {
                                ws.Cells[i, j].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            }

                            if (cell_val_3.Contains("TOTAL"))
                            {
                                ws.Cells[i, 3, i, 3].Style.Font.Bold = true;
                                ws.Cells[i, 3, i, 3].Style.Border.Top.Style = ExcelBorderStyle.Thick;
                                ws.Cells[i, 3, i, 3].Style.Border.Left.Style = ExcelBorderStyle.Thick;
                                ws.Cells[i, 3, i, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;

                                ws.Cells[i, 4, i, 4].Style.Font.Bold = true;
                                ws.Cells[i, 4, i, 4].Style.Border.Top.Style = ExcelBorderStyle.Thick;
                                ws.Cells[i, 4, i, 4].Style.Border.Right.Style = ExcelBorderStyle.Thick;
                                ws.Cells[i, 4, i, 4].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                            }
                            else if (cell_val_1.Contains(". ") && cell_val_2 == string.Empty)
                            {
                                ws.Cells[i, 1, i, 1].Style.Font.Bold = true;
                                ws.Cells[i, 1, i, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                                for (int j = 1; j <= ws.Dimension.Columns; j++)
                                {
                                    ws.Cells[i, j, i, j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    ws.Cells[i, j, i, j].Style.Fill.BackgroundColor.SetColor(fondoOscuro3);
                                    ws.Cells[i, j, i, j].Style.Font.Color.SetColor(white);
                                }
                            }
                            else if (cell_val_1.Contains("Total General"))
                            {
                                ws.Cells[i, 1].Style.Font.Bold = true;
                                ws.Cells[i, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                ws.Cells[i, 1].Style.Font.Color.SetColor(white);
                                for (int j = 1; j <= ws.Dimension.Columns; j++)
                                {
                                    ws.Cells[i, j].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                                    ws.Cells[i, j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    ws.Cells[i, j].Style.Fill.BackgroundColor.SetColor(fondoOscuro2);
                                }

                            }
                            else if (cell_val_4.Contains("Total"))
                            {
                                for (int j = 2; j <= ws.Dimension.Columns; j++)
                                {
                                    ws.Cells[i, j].Style.Font.Bold = true;
                                    ws.Cells[i, j].Style.Border.Top.Style = ExcelBorderStyle.Thick;
                                    ws.Cells[i, j].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                                    ws.Cells[i, j].Style.Border.Right.Style = ExcelBorderStyle.Thick;
                                    ws.Cells[i, j].Style.Border.Left.Style = ExcelBorderStyle.Thick;
                                }


                            }
                        }
                    }




                    ws.Cells[ws.Dimension.Address].AutoFitColumns();

                    value = pck.GetAsByteArray();
                    //Byte[] bin = pck.GetAsByteArray();
                    //url = string.Format("{0}{1}", ruta, url);
                    //File.WriteAllBytes(url, bin); 

                }
            }
            catch (Exception)
            {
                //Varias.EscribeLog(ex);
                value = null;
            }

            return value;
        }

        private static void setEstiloParametroCelda(ExcelRange cell)
        {
            cell.Style.Font.Size = 10;
            cell.Style.Font.Name = "Calibri";
            cell.Style.Font.Bold = true;
        }

        //public static byte[] ExportarPdf(DataTable dt, ExportadorParametros parametros)
        //{

        //    string flagEmpre = ConfigurationManager.AppSettings["RptGenericosLogoEmpre"];
        //    string rutaLogo = ConfigurationManager.AppSettings["RptGenericosLogoEmpreRuta"];
        //    string nombreLogo = ConfigurationManager.AppSettings["RptGenericosNombreLogoRuta"];
        //    string ruta = string.Empty;

        //    if (flagEmpre == null)
        //    {
        //        flagEmpre = "0";
        //    }
        //    else if (flagEmpre == "1")
        //    {
        //        if (rutaLogo == null)
        //        {
        //            throw new Exception("Exportar: No se configuró la ruta del logo. Ver la llave RptGenericosLogoEmpreRuta en web.config (la ruta debe tener '/' al final)");
        //        }
        //        if (nombreLogo == null)
        //        {
        //            throw new Exception("Exportar: No se configuró el nombre del logo. Ver la llave RptGenericosNombreLogoRuta en web.config");
        //        }

        //        ruta = HttpContext.Current.Server.MapPath("~") + rutaLogo + parametros.codigoCompania + "/" + nombreLogo;

        //    }

        //    byte[] resultado = null;

        //    try
        //    {
        //        bool horizontal = parametros.horizontal;

        //        StringBuilder strHtml = new StringBuilder("");
        //        string fontSizeDatos = dt.Columns.Count < 20 ? "9px" : "8px";

        //        strHtml.Append("<br>");
        //        strHtml.Append("<table style='width:100%;margin:0 auto;border-collapse:collapse;font-size:" + fontSizeDatos + ";'>");
        //        strHtml.Append("<tbody>");
        //        strHtml.Append("<tr>");

        //        if (flagEmpre == "0")
        //        {
        //            if (parametros.compania == null)
        //            {
        //                throw new Exception("Exportar: compania es null");
        //            }
        //            strHtml.Append("<td style='width:25%;'>Compañía: " + parametros.compania + "</td>");
        //        }
        //        else
        //        {
        //            strHtml.Append("<td style='width:25%;'></td>");
        //        }

        //        strHtml.Append("<td style='width:50%;font-size:20px;font-weight:bold;'></td>");
        //        strHtml.Append("<td style='width:25%;'>Fecha y hora: " + DateTime.Now.ToString("dd/MM/yyyy - HH:mm") + "</td>");
        //        strHtml.Append("</tr>");
        //        strHtml.Append("<tr>");
        //        strHtml.Append("<td style='width:25%;'></td>");
        //        strHtml.Append("<td style='width:50%;font-size:20px;font-weight:bold;'></td>");
        //        strHtml.Append("<td style='width:25%;'>Usuario: " + parametros.usuario + "</td>");
        //        strHtml.Append("</tr>");
        //        strHtml.Append("<tr>");
        //        strHtml.Append("<td style='width:25%;'></td>");
        //        strHtml.Append("<td style='width:50%;font-size:16px;font-weight:bold;text-align:center;'>" + parametros.titulo + "</td>");
        //        strHtml.Append("<td style='width:25%;'></td>");
        //        strHtml.Append("</tr>");

        //        //if (parametros.periodo != null && parametros.tipoTrabajador != null) {
        //        //    strHtml.Append("<tr>");
        //        //    strHtml.Append("<td style='width:25%;'>Periodo: " + parametros.periodo + "</td>");
        //        //    strHtml.Append("<td style='width:50%;'><br/><br/></td>");
        //        //    strHtml.Append("<td style='width:25%;'></td>");
        //        //    strHtml.Append("</tr>");
        //        //    strHtml.Append("<tr>");
        //        //    strHtml.Append("<td style='width:25%;'>Tipo Trabajador: " + parametros.tipoTrabajador + "</td>");
        //        //    strHtml.Append("<td style='width:50%;'><br/><br/></td>");
        //        //    strHtml.Append("<td style='width:25%;'></td>");
        //        //    strHtml.Append("</tr>");
        //        //} else if (parametros.periodo == null && parametros.tipoTrabajador != null) {
        //        //    strHtml.Append("<tr>");
        //        //    strHtml.Append("<td style='width:25%;'>Tipo Trabajador: " + parametros.tipoTrabajador + "</td>");
        //        //    strHtml.Append("<td style='width:50%;'><br/><br/></td>");
        //        //    strHtml.Append("<td style='width:25%;'></td>");
        //        //    strHtml.Append("</tr>");
        //        //} else if (parametros.periodo != null && parametros.tipoTrabajador == null) {
        //        //    strHtml.Append("<tr>");
        //        //    strHtml.Append("<td style='width:25%;'>Periodo: " + parametros.periodo + "</td>");
        //        //    strHtml.Append("<td style='width:50%;'><br/><br/></td>");
        //        //    strHtml.Append("<td style='width:25%;'></td>");
        //        //    strHtml.Append("</tr>");
        //        //}

        //        //Espacio
        //        for (int i = 0; i < 4; i++)
        //        {
        //            strHtml.Append("<tr>");
        //            strHtml.Append("<td style='width:25%;color:white;'>.</td>");
        //            strHtml.Append("<td style='width:50%;color:white;'>.</td>");
        //            strHtml.Append("<td style='width:25%;color:white;'>.</td>");
        //            strHtml.Append("</tr>");
        //        }


        //        strHtml.Append("<tr><td colspan='3'><table style='width:100%;font-size:" + fontSizeDatos + ";'>");
        //        strHtml.Append("<tr>");
        //        string[] dataFiltros = parametros.filtros.Split(new string[] { "@@@" }, StringSplitOptions.None);
        //        int ncol = 8;// dt.Columns.Count % 2 == 0 ? dt.Columns.Count : dt.Columns.Count + 1;
        //        for (int i = 0, j = 1, k = 2; i < dataFiltros.Length; i++, j += 2, k += 2)
        //        {
        //            if (dataFiltros[i] != null && dataFiltros[i] != string.Empty)
        //            {
        //                string[] item = dataFiltros[i].Split('|');
        //                string label = item[0];
        //                string __val = item[1];

        //                strHtml.Append("<td style='text-align:left;'>" + label + "</td>");
        //                strHtml.Append("<td style='text-align:left;'>" + __val + "</td>");


        //                if (k != 0 && k % ncol == 0)
        //                {
        //                    strHtml.Append("</tr><tr>");
        //                }
        //            }

        //        }
        //        strHtml.Append("</tr></table></td></tr>");


        //        //Un poco de espacio entre la cabecera y la grilla de datos
        //        for (int i = 0; i < 2; i++)
        //        {
        //            strHtml.Append("<tr>");
        //            strHtml.Append("<td style='width:25%;color:white;'>.</td>");
        //            strHtml.Append("<td style='width:50%;color:white;'>.</td>");
        //            strHtml.Append("<td style='width:25%;color:white;'>.</td>");
        //            strHtml.Append("</tr>");
        //        }


        //        strHtml.Append("</tbody>");
        //        strHtml.Append("</table>");

        //        strHtml.Append("<table style='width:100%;margin:0 auto;border-collapse:collapse;font-size:" + fontSizeDatos + ";'>");
        //        strHtml.Append("<thead style='background-color:#00008b; color: #ffffff;'>");
        //        strHtml.Append("<tr>");
        //        /*                strHtml.Replace("<", "&#60;");
        //        strHtml.Replace(">", "&#62;");*/

        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            string colname = dt.Columns[i].ColumnName.Replace("<", "&#60;").Replace(">", "&#62;");
        //            strHtml.Append("<th style='border:1px solid black;'>");
        //            strHtml.Append(colname);
        //            strHtml.Append("</th>");
        //        }
        //        strHtml.Append("</tr>");
        //        strHtml.Append("</thead>");
        //        strHtml.Append("<tbody>");
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {

        //            bool esFilaTotal = false;
        //            if (parametros.indicesStyle != null && parametros.indicesStyle.Count > 1)
        //            {
        //                foreach (int ind in parametros.indicesStyle)
        //                {
        //                    if (i == ind)
        //                    {
        //                        esFilaTotal = true;
        //                    }
        //                }
        //            }


        //            if (esFilaTotal)
        //            {
        //                string color = "#3a3a3a";
        //                string val = dt.Rows[i].ItemArray[0].ToString().Trim().ToLower();
        //                if (val.Contains("total"))
        //                {
        //                    color = "#aaaaaa";
        //                }
        //                strHtml.Append("<tr style='background-color:" + color + ";color:white;'>");
        //            }
        //            else
        //            {
        //                strHtml.Append("<tr>");
        //            }

        //            for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
        //            {
        //                string colval = dt.Rows[i].ItemArray[j].ToString().Trim().Replace("<", "&#60;").Replace(">", "&#62;");

        //                if (esFilaTotal)
        //                {
        //                    if (j == 0 && i == 0)
        //                    {
        //                        strHtml.Append("<td style='border-left:1px solid black;padding:5px;'>");
        //                    }
        //                    else if ((j - 1) == dt.Rows[i].ItemArray.Length)
        //                    {
        //                        strHtml.Append("<td style='border-right:1px solid black;padding:5px;'>");
        //                    }
        //                    else
        //                    {
        //                        strHtml.Append("<td style='padding:5px;'>");
        //                    }
        //                    strHtml.Append(colval);
        //                    strHtml.Append("</td>");


        //                }
        //                else
        //                {
        //                    strHtml.Append("<td style='border:1px solid black;'>");
        //                    strHtml.Append(colval);
        //                    strHtml.Append("</td>");
        //                }


        //            }
        //            strHtml.Append("</tr>");
        //        }

        //        if (dt.Rows.Count == 0)
        //        {

        //            strHtml.Append("<tr style=\"text-align: center;\">  <td colspan=\"" + dt.Columns.Count.ToString() + "\">No se encontró data en la tabla</td>  </tr>");
        //        }
        //        strHtml.Append("</tbody>");
        //        strHtml.Append("</table>");

        //        //Este caracter forma html valido, se le está reemplazando por su código ascii equivalente
        //        strHtml.Replace("&", "&amp;");


        //        string html = strHtml.ToString();

        //        using (var ms = new MemoryStream())
        //        {
        //            // Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF

        //            using (var doc = new Document(PageSize.A4))
        //            {

        //                if (dt.Columns.Count > 20)
        //                {
        //                    if (horizontal)
        //                    {
        //                        doc.SetPageSize(PageSize.ARCH_D.Rotate());
        //                    }
        //                    else
        //                    {
        //                        doc.SetPageSize(PageSize.ARCH_D);
        //                    }

        //                }
        //                else
        //                {
        //                    if (horizontal) doc.SetPageSize(PageSize.A4.Rotate());
        //                }





        //                // Create a writer that's bound to our PDF abstraction and our stream
        //                using (var writer = PdfWriter.GetInstance(doc, ms))
        //                {
        //                    // Open the document for writing
        //                    doc.OpenXmlElementContext();

        //                    // Read your html by database or file here and store it into finalHtml e.g. a string
        //                    // XMLWorker also reads from a TextReader and not directly from a string
        //                    using (var srHtml = new StringReader(html))
        //                    {
        //                        // Parse the HTML
        //                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
        //                    }



        //                    doc.AddCreator(creadorPdf);
        //                    doc.Close();
        //                    resultado = ms.ToArray();

        //                    //inserta imagenes
        //                    var msImagenes = new MemoryStream();
        //                    if (flagEmpre == "1")
        //                    {


        //                        var pdfReader1 = new PdfReader(ms.ToArray());

        //                        byte[] dataImage = null;
        //                        if (File.Exists(ruta)) dataImage = ManejoArchivos.Leer(ruta);
        //                        if (dataImage == null)
        //                        {
        //                            throw new Exception("Exportar: No se pudo encontrar la imagen del logo de la compañía dataImage es null");
        //                        }

        //                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(dataImage);
        //                        image.ScaleAbsolute(40.0f, 40.0f);
        //                        int y = horizontal ? 530 : 785;
        //                        image.SetAbsolutePosition(35, y);
        //                        var pdfStamper = new PdfStamper(pdfReader1, msImagenes, '\0', true);
        //                        var waterMark = pdfStamper.GetOverContent(1);//Primera pagina
        //                        waterMark.AddImage(image);


        //                        pdfStamper.Writer.CloseStream = false;
        //                        pdfStamper.Close();
        //                        resultado = msImagenes.GetBuffer();
        //                    }

        //                    return resultado;


        //                    //encripta pdf
        //                    //if (string.IsNullOrEmpty(clave)) return resultado;
        //                    //var msClave = new MemoryStream();
        //                    //var pdfReader = new PdfReader(msImagenes.GetBuffer());
        //                    //PdfEncryptor.Encrypt(pdfReader, msClave, true, clave, clave, PdfWriter.ALLOW_PRINTING);
        //                    //resultado = msClave.GetBuffer();
        //                }
        //            }

        //            // After all of the PDF "stuff" above is done and closed but **before** we
        //            // close the MemoryStream, grab all of the active bytes from the stream                                                
        //            //return resultado;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Varias.EscribeLog(ex);
        //        resultado = null;
        //    }


        //    return resultado;
        //}

        //public static byte[] ExportarTxt(DataTable dt, ExportadorParametros parametros)
        //{
        //    byte[] resultado = null;

        //    try
        //    {
        //        MemoryStream fs = new MemoryStream();
        //        TextWriter swExtLogFile = new StreamWriter(fs);

        //        int i;
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            object[] array = row.ItemArray;
        //            for (i = 0; i < array.Length - 1; i++)
        //            {
        //                swExtLogFile.Write(array[i].ToString() + "|");
        //            }
        //            swExtLogFile.WriteLine(array[i].ToString());
        //        }

        //        swExtLogFile.Flush();
        //        fs.Flush();

        //        byte[] bytes = fs.ToArray();
        //        fs.Read(bytes, 0, Int32.Parse(fs.Length.ToString()));

        //        swExtLogFile.Close();
        //        fs.Close();

        //        return bytes;

        //    }
        //    catch (Exception ex)
        //    {
        //        Varias.EscribeLog(ex);
        //        resultado = null;
        //    }

        //    return resultado;
        //}
    }
}
