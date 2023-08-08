using Directorio_Logica;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using System.Data;

using iText.IO.Font.Constants;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Properties;
using Rectangle = iText.Kernel.Geom.Rectangle;
using Image = iText.Layout.Element.Image;
using ScottPlot.Drawing.Colormaps;
using iText.Layout.Borders;

namespace Directorio___Presentacion.ElementsStyles_Configuration
{
    public class ClsPdfFormat
    {
        public void GenerarDocumentoOneTablePDF(string filePath,string reportTitle, string titleDocument, string semestre, string filtro,DataTable dtInfo)
        {
            // Generar el documento y guardarlo en filePath
            //GET DATA FOR DOCUMENT SECTION -----
            //-----------------------------------
            // Crea un objeto PdfDocument con el PdfWriter
            PdfDocument pdf = new PdfDocument(new PdfWriter(filePath));

            // Crea un objeto Document asociado al PdfDocument
            Document doc = new Document(pdf, PageSize.A4);

            // Establecer márgenes
            doc.SetMargins(50, 50, 50, 50);

            // Definimos fuentes del documento
            PdfFont timesNewRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            PdfFont fontNegritaTitle = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
            PdfFont fontNegrita = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

            Style defaultStyle = new Style().SetFont(timesNewRoman);


            Paragraph header = new Paragraph(reportTitle).SetFont(fontNegritaTitle).SetFontSize(20).SetTextAlignment(TextAlignment.CENTER);
            header.SetMarginBottom(10);
            doc.Add(header);

            //Paragraph docenteData = new Paragraph("Docente: " + docenteName).SetFont(timesNewRoman).SetFontSize(12);
            //docenteData.SetMarginBottom(-5);
            //doc.Add(docenteData);

            Paragraph semestreData = new Paragraph("Semestre: " + semestre).SetFont(timesNewRoman).SetFontSize(12);
            semestreData.SetMarginBottom(-5);
            doc.Add(semestreData);

            Paragraph docenteDepartamento = new Paragraph("Departamento: DETRI").SetFont(timesNewRoman).SetFontSize(12);
            docenteDepartamento.SetMarginBottom(-5);
            doc.Add(docenteDepartamento);

            //Paragraph horasExigiblesData = new Paragraph("Horas exigibles: " + horasExigibles.ToString()).SetFont(timesNewRoman).SetFontSize(12);
            //horasExigiblesData.SetMarginBottom(0);
            //doc.Add(horasExigiblesData);

            Paragraph line = new Paragraph("__________________________________________________________________________________").SetFont(fontNegrita).SetFontSize(12);
            line.SetMarginBottom(5).SetMarginTop(-5);
            doc.Add(line);

            #region TABLE INFO
            Paragraph Title = new Paragraph("FILTRO: " + filtro.Replace("_", " ")).SetFont(fontNegrita).SetFontSize(14);
            Title.SetMarginBottom(2);
            doc.Add(Title);

            Table tableAsignaturas = new Table(dtInfo.Columns.Count - 1);

            foreach (DataColumn column in dtInfo.Columns)
            {
                if (column.Ordinal != 0)
                {
                    Cell cell = new Cell().Add(new Paragraph(column.ColumnName));
                    cell.SetTextAlignment(TextAlignment.CENTER);
                    cell.SetFont(fontNegrita).SetFontSize(10).SetBackgroundColor(new DeviceRgb(230, 230, 230)); ;
                    tableAsignaturas.AddHeaderCell(cell);
                }
            }

            // Agrega filas a la tabla
            foreach (DataRow row in dtInfo.Rows)
            {
                for (int i = 1; i < dtInfo.Columns.Count; i++)
                {
                    Cell cell = new Cell().Add(new Paragraph(row[i].ToString()));
                    cell.SetTextAlignment(TextAlignment.LEFT);
                    cell.SetFont(timesNewRoman).SetFontSize(10);
                    cell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    tableAsignaturas.AddCell(cell);
                }
            }

            // Agrega espacio antes y después de la tabla
            tableAsignaturas.SetMarginTop(10f);
            tableAsignaturas.SetMarginBottom(10f);

            // Agrega la tabla al documento
            doc.Add(tableAsignaturas);
            #endregion


            // Agregar el evento del pie de página y el encabezado al documento
            CustomPageEventHandler handler = new CustomPageEventHandler();
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, handler);

            // Cierra el documento
            doc.Close();
        }

        class CustomPageEventHandler : IEventHandler
        {
            public void HandleEvent(Event @event)
            {
                Image logoImage = new Image(ImageDataFactory.Create(@"Images\EPNLogo.png"));


                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                int pageNumber = pdfDoc.GetPageNumber(page);
                Rectangle pageSize = page.GetPageSize();

                PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
                Canvas canvas = new Canvas(pdfCanvas, pageSize);

                float pageWidth = pageSize.GetWidth();
                float pageHeight = pageSize.GetHeight();

                // Insertar línea horizontal
                LineSeparator line = new LineSeparator(new SolidLine());
                line.SetWidth(500); // Establecer el ancho de la línea
                //line.SetMarginTop(1); // Establecer el margen superior de la línea
                //line.SetMarginBottom(1); // Establecer el margen inferior de la línea
                line.SetFontColor(ColorConstants.BLACK); // Establecer el color de la línea
                //doc.Add(line);

                // Agregar el encabezado "ESCUELA POLITÉCNICA NACIONAL"
                canvas.SetFontColor(ColorConstants.DARK_GRAY)
                    .SetFontSize(14)
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD))
                    .ShowTextAligned("ESCUELA POLITÉCNICA NACIONAL", pageWidth / 2, pageHeight - 30, TextAlignment.CENTER);

                // Agregar el nombre de la facultad "Ingeniería Eléctrica y Electrónica"
                canvas.SetFontColor(ColorConstants.DARK_GRAY)
                    .SetFontSize(14)
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD))
                    .ShowTextAligned("Facultad de Ingeniería Eléctrica y Electrónica", pageWidth / 2, pageHeight - 50, TextAlignment.CENTER);

                canvas.Add(line)
                    .ShowTextAligned("________________________________________________________________", pageWidth / 2, pageHeight - 55, TextAlignment.CENTER); ;

                // Logo de la universidad
                float logoWidth = 80f; // Ancho de la imagen del logo
                float logoHeight = 40f; // Alto de la imagen del logo
                float logoX = pageWidth - logoWidth + 10; // Posición X de la imagen del logo (ajusta según sea necesario)
                float logoY = pageHeight - 50; // Posición Y de la imagen del logo (ajusta según sea necesario)

                // Agregar la imagen del logo al lienzo
                canvas.Add(logoImage.SetFixedPosition(logoX, logoY).ScaleToFit(logoWidth, logoHeight));

                // Agregar el número de página en la parte inferior derecha
                canvas.SetFontColor(ColorConstants.DARK_GRAY)
                    .SetFontSize(10)
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD))
                    .ShowTextAligned("_______________       ", pageWidth - 80, 41, TextAlignment.CENTER);

                canvas.SetFontColor(ColorConstants.DARK_GRAY)
                    .SetFontSize(10)
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD))
                    .ShowTextAligned("Página " + pageNumber.ToString(), pageWidth - 50, 30, TextAlignment.RIGHT);

                canvas.Close();
            }
        }
    }
}
