using  Ywferia.Cloud.Utilitarios.Enumerados;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.IO;
using System.Linq;
 
namespace Ywferia.Cloud.Utilitarios.ExcelUtility
{
    public class EscribirExcel
    {
        private static string ColumnLetter(int intCol)
        {
            var intFirstLetter = ((intCol) / 676) + 64;
            var intSecondLetter = ((intCol % 676) / 26) + 64;
            var intThirdLetter = (intCol % 26) + 65;

            var firstLetter = (intFirstLetter > 64) ? (char)intFirstLetter : ' ';
            var secondLetter = (intSecondLetter > 64) ? (char)intSecondLetter : ' ';
            var thirdLetter = (char)intThirdLetter;

            return string.Concat(firstLetter, secondLetter, thirdLetter).Trim();
        }

        public Cell CreateTextCell(string header, UInt32 index, string text, UInt32Value styleIndex)
        {


            if (text.Contains("|N"))
            {

                var cell = new Cell
                {
                    CellReference = header + index,
                };

                cell.CellValue = new CellValue(text.Split('|')[0].Replace(",", ""));

                //if (text.Contains("|ND")) //NUMERO DECIMAL
                //{
                //    cell.CellValue = new CellValue(text.Split('|')[0].Replace(",", ""));
                //}
                //else
                //{
                //    cell.CellValue = new CellValue(text.Split('|')[0].Replace(",", "").Substring(0, text.Split('|')[0].Replace(",", "").IndexOf(".")-1));
                //}

                cell.DataType = new EnumValue<CellValues>(CellValues.Number);


                //var istring = new NumberItem();
                //istring.FormatIndex = 0;

                //var t = new Text { Text = cell.CellValue.ToString() };

                NumberingFormat nf = new NumberingFormat();
                if (text.Contains("|ND")) //NUMERO DECIMAL
                {
                    nf.NumberFormatId = 4; //UInt32Value.FromUInt32(UInt32.Parse(cell.CellValue.ToString()));  //166; // UInt32Value.FromUInt32(UInt32.Parse(t.ToString()));
                    nf.FormatCode = StringValue.FromString("#,##0.00"); //StringValue.FromString("#0.00");
                }
                else
                {
                    nf.NumberFormatId = 1;
                    nf.FormatCode = StringValue.FromString("0"); //StringValue.FromString("#0.00");
                }

                cell.Append(nf);
                cell.StyleIndex = styleIndex;

                return cell;
            }
            else
            {
                var cell = new Cell
                {
                    DataType = CellValues.InlineString,
                    CellReference = header + index
                };

                var istring = new InlineString();
                var t = new Text { Text = text };
                istring.AppendChild(t);
                cell.AppendChild(istring);
                cell.StyleIndex = styleIndex;

                return cell;
            }

            /*
            var cell = new Cell
            {
                DataType = CellValues.InlineString,
                CellReference = header + index
            };

            var istring = new InlineString();
            var t = new Text { Text = text };

            istring.AppendChild(t);
            cell.AppendChild(istring);
            cell.StyleIndex = styleIndex;

            return cell;
            */
        }

        public byte[] GenerateExcel(ExcelData data)
        {
            var stream = new MemoryStream();
            var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);

            var workbookpart = document.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            var stylesPart = workbookpart.AddNewPart<WorkbookStylesPart>();
            var styles = new CustomStylesheet();
            styles.Save(stylesPart);

            var sheetData = new SheetData();

            worksheetPart.Worksheet = new Worksheet(sheetData);

            var sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());

            var sheet = new Sheet
            {
                Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = data.NombreHoja ?? "Reporte 1"
            };
            sheets.AppendChild(sheet);

            // Add header
            UInt32 rowIdex = 0;
            var row = new Row { RowIndex = ++rowIdex };
            sheetData.AppendChild(row);
            var cellIdex = 0;
            var columnas = 0;

            foreach (var header in data.Headers)
            {
                row.AppendChild(CreateTextCell(ColumnLetter(cellIdex++), rowIdex, header ?? string.Empty, 0));
            }
            if (data.Headers.Any())
            {
                // Add the column configuration if available
                if (data.ColumnConfigurations != null)
                {
                    var columns = (Columns)data.ColumnConfigurations.Clone();
                    worksheetPart.Worksheet
                        .InsertAfter(columns, worksheetPart.Worksheet.SheetFormatProperties);
                }
            }

            // Add sheet data
            foreach (var rowData in data.DataRows)
            {
                cellIdex = 0;
                row = new Row { RowIndex = ++rowIdex };
                sheetData.AppendChild(row);

                var primero = rowData.FirstOrDefault();
                UInt32Value formato;
                switch ((FormatosExcel)Convert.ToInt32(primero))
                {
                    case FormatosExcel.Titulo:
                        formato = 1;
                        break;
                    case FormatosExcel.Fecha:
                        formato = 5;
                        break;
                    case FormatosExcel.Parametro:
                        formato = 2;
                        break;
                    case FormatosExcel.Cabecera:
                        formato = 3;
                        break;
                    case FormatosExcel.Detalle:
                        formato = 4;
                        break;
                    case FormatosExcel.SinFormato:
                        formato = 0;
                        break;
                    default:
                        formato = 0;
                        break;
                }

                columnas = 0;
                if (rowData.Count > 0) rowData.RemoveAt(0);

                foreach (var cell in rowData.Select(callData => CreateTextCell(ColumnLetter(cellIdex++), rowIdex, callData ?? string.Empty,
                    formato == FormatosExcel.Parametro.GetHashCode() ? columnas == 0 ? formato : 0 : formato)))
                {
                    row.AppendChild(cell);
                    columnas++;
                }
            }

            MergeCells mergeCells;

            if (sheet.Elements<MergeCells>().Any())
                mergeCells = worksheetPart.Worksheet.Elements<MergeCells>().First();
            else
            {
                mergeCells = new MergeCells();

                // Insert a MergeCells object into the specified position.
                if (worksheetPart.Worksheet.Elements<CustomSheetView>().Any())
                    worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<CustomSheetView>().First());
                else
                    worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());
            }

            // Create the merged cell and append it to the MergeCells collection.
            var mergeCell = new MergeCell
            {
                Reference =
                    new StringValue(string.Format("A2:{0}2", Convert.ToChar(64 + columnas)))
            };
            mergeCells.Append(mergeCell);
            document.Close();

            return stream.ToArray();
        }
    }
}
