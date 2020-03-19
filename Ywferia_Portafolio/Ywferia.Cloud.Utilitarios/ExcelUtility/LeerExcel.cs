using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ywferia.Cloud.Utilitarios.ExcelUtility
{
    public static class LeerExcel
    {
        private static string GetColumnName(string cellReference)
        {
            var regex = new Regex("[A-Za-z]+");
            var match = regex.Match(cellReference);

            return match.Value;
        }

        private static int ConvertColumnNameToNumber(string columnName)
        {
            var alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName)) throw new ArgumentException();

            var colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);

            return colLetters.Select((letter, i) => i == 0 ? letter - 65 : letter - 64).Select((current, i) => current * (int)Math.Pow(26, i)).Sum();
        }

        private static IEnumerator<Cell> GetExcelCellEnumerator(Row row)
        {
            var currentCount = 0;
            foreach (var cell in row.Descendants<Cell>())
            {
                var columnName = GetColumnName(cell.CellReference);

                var currentColumnIndex = ConvertColumnNameToNumber(columnName);

                for (; currentCount < currentColumnIndex; currentCount++)
                {
                    var emptycell = new Cell { DataType = null, CellValue = new CellValue(string.Empty) };
                    yield return emptycell;
                }

                yield return cell;
                currentCount++;
            }
        }

        private static string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            var cellValue = cell.CellValue;
            var text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(
                        Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }

            return (text ?? string.Empty).Trim();
        }

        public static ExcelData Cargar(Stream file)
        {
            var data = new ExcelData();

            // Open the excel document
            WorkbookPart workbookPart; List<Row> rows;
            try
            {
                var document = SpreadsheetDocument.Open(file, false);
                workbookPart = document.WorkbookPart;

                var sheets = workbookPart.Workbook.Descendants<Sheet>();
                var sheet = sheets.First();
                data.NombreHoja = sheet.Name;

                var workSheet = ((WorksheetPart)workbookPart.GetPartById(sheet.Id)).Worksheet;
                var columns = workSheet.Descendants<Columns>().FirstOrDefault();
                data.ColumnConfigurations = columns;

                var sheetData = workSheet.Elements<SheetData>().First();
                rows = sheetData.Elements<Row>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Read the header
            if (rows.Count > 0)
            {
                var row = rows[0];
                var cellEnumerator = GetExcelCellEnumerator(row);
                while (cellEnumerator.MoveNext())
                {
                    var cell = cellEnumerator.Current;
                    var text = ReadExcelCell(cell, workbookPart).Trim();
                    data.Headers.Add(text);
                }
            }

            // Read the sheet data
            if (rows.Count <= 1) return data;
            for (var i = 1; i < rows.Count; i++)
            {
                var dataRow = new List<string>();
                data.DataRows.Add(dataRow);
                var row = rows[i];
                var cellEnumerator = GetExcelCellEnumerator(row);
                while (cellEnumerator.MoveNext())
                {
                    var cell = cellEnumerator.Current;
                    var text = ReadExcelCell(cell, workbookPart).Trim();
                    dataRow.Add(text);
                }
            }

            return data;
        }
    }
}
