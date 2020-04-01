using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;


namespace Ywferia.Cloud.Utilitarios.ExcelUtility
{
    class CustomStylesheet : Stylesheet
    {
        public CustomStylesheet()
        {
            var fts = new Fonts();
            var ft = new Font();
            var ftn = new FontName { Val = StringValue.FromString("Calibri") };
            var ftsz = new FontSize { Val = DoubleValue.FromDouble(11) };
            ft.FontName = ftn;
            ft.FontSize = ftsz;
            fts.Append(ft);

            ft = new Font { Bold = new Bold() };
            ftn = new FontName { Val = StringValue.FromString("Calibri") };
            ftsz = new FontSize { Val = DoubleValue.FromDouble(11) };
            ft.FontName = ftn;
            ft.FontSize = ftsz;
            fts.Append(ft);

            fts.Count = UInt32Value.FromUInt32((uint)fts.ChildElements.Count);

            var fills = new Fills();
            var fill = new Fill();
            var patternFill = new PatternFill { PatternType = PatternValues.None };
            fill.PatternFill = patternFill;
            fills.Append(fill);

            fill = new Fill();
            patternFill = new PatternFill { PatternType = PatternValues.Gray125 };
            fill.PatternFill = patternFill;
            fills.Append(fill);

            fill = new Fill();
            patternFill = new PatternFill
            {
                PatternType = PatternValues.Solid,
                ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("99E0FF") }
            };
            patternFill.BackgroundColor = new BackgroundColor { Rgb = patternFill.ForegroundColor.Rgb };
            fill.PatternFill = patternFill;
            fills.Append(fill);

            fills.Count = UInt32Value.FromUInt32((uint)fills.ChildElements.Count);

            var borders = new Borders();
            var border = new Border
            {
                LeftBorder = new LeftBorder(),
                RightBorder = new RightBorder(),
                TopBorder = new TopBorder(),
                BottomBorder = new BottomBorder(),
                DiagonalBorder = new DiagonalBorder()
            };
            borders.Append(border);

            //Boarder Index 1
            border = new Border
            {
                LeftBorder = new LeftBorder { Style = BorderStyleValues.Thin },
                RightBorder = new RightBorder { Style = BorderStyleValues.Thin },
                TopBorder = new TopBorder { Style = BorderStyleValues.Thin },
                BottomBorder = new BottomBorder { Style = BorderStyleValues.Thin },
                DiagonalBorder = new DiagonalBorder()
            };
            borders.Append(border);


            //Boarder Index 2
            border = new Border
            {
                LeftBorder = new LeftBorder(),
                RightBorder = new RightBorder(),
                TopBorder = new TopBorder { Style = BorderStyleValues.Thin },
                BottomBorder = new BottomBorder { Style = BorderStyleValues.Thin },
                DiagonalBorder = new DiagonalBorder()
            };
            borders.Append(border);


            borders.Count = UInt32Value.FromUInt32((uint)borders.ChildElements.Count);

            var csfs = new CellStyleFormats();
            var cf = new CellFormat { NumberFormatId = 0, FontId = 0, FillId = 0, BorderId = 0 };
            csfs.Append(cf);
            csfs.Count = UInt32Value.FromUInt32((uint)csfs.ChildElements.Count);

            uint iExcelIndex = 164;
            var nfs = new NumberingFormats();
            var cfs = new CellFormats();

            cf = new CellFormat { NumberFormatId = 0, FontId = 0, FillId = 0, BorderId = 0, FormatId = 0 };
            cfs.Append(cf);

            var nfDateTime = new NumberingFormat
            {
                NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++),
                FormatCode = StringValue.FromString("dd/mm/yyyy hh:mm:ss")
            };
            nfs.Append(nfDateTime);

            var nf4decimal = new NumberingFormat
            {
                NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++),
                FormatCode = StringValue.FromString("#,##0.0000")
            };
            nfs.Append(nf4decimal);

            // #,##0.00 is also Excel style index 4
            var nf2decimal = new NumberingFormat
            {
                NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++),
                FormatCode = StringValue.FromString("#,##0.00")
            };
            nfs.Append(nf2decimal);

            // @ is also Excel style index 49
            var nfForcedText = new NumberingFormat
            {
                NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++),
                FormatCode = StringValue.FromString("@")
            };
            nfs.Append(nfForcedText);

            // index 1            
            cf = new CellFormat
            {
                NumberFormatId = nf2decimal.NumberFormatId,
                FontId = 1,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                Alignment = new Alignment { Horizontal = HorizontalAlignmentValues.Center },
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cfs.Append(cf);

            // index 2
            // Format #,##0.00
            cf = new CellFormat
            {
                NumberFormatId = 0,
                FontId = 1,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cfs.Append(cf);

            // index 3
            cf = new CellFormat
            {
                NumberFormatId = nfDateTime.NumberFormatId,
                FontId = 1,
                FillId = 2,
                BorderId = 1,
                FormatId = 0,
                Alignment = new Alignment { Horizontal = HorizontalAlignmentValues.Center },
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cfs.Append(cf);

            // index 4
            cf = new CellFormat
            {
                NumberFormatId = nf4decimal.NumberFormatId,
                FontId = 0,
                FillId = 0,
                BorderId = 1,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cfs.Append(cf);

            // index 5       
            cf = new CellFormat
            {
                NumberFormatId = nf2decimal.NumberFormatId,
                FontId = 1,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cfs.Append(cf);

            nfs.Count = UInt32Value.FromUInt32((uint)nfs.ChildElements.Count);
            cfs.Count = UInt32Value.FromUInt32((uint)cfs.ChildElements.Count);

            Append(nfs);
            Append(fts);
            Append(fills);
            Append(borders);
            Append(csfs);
            Append(cfs);

            var css = new CellStyles();
            var cs = new CellStyle { Name = StringValue.FromString("Normal"), FormatId = 0, BuiltinId = 0 };
            css.Append(cs);
            css.Count = UInt32Value.FromUInt32((uint)css.ChildElements.Count);
            Append(css);

            var dfs = new DifferentialFormats { Count = 0 };
            Append(dfs);

            var tss = new TableStyles
            {
                Count = 0,
                DefaultTableStyle = StringValue.FromString("TableStyleMedium9"),
                DefaultPivotStyle = StringValue.FromString("PivotStyleLight16")
            };
            Append(tss);
        }
    }
}
