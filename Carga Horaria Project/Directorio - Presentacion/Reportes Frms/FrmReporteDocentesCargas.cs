using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Rectangle = iText.Kernel.Geom.Rectangle;
using iText.IO.Image;
using Image = iText.Layout.Element.Image;
using ScottPlot.Drawing.Colormaps;
using iText.Layout.Borders;

namespace Directorio___Presentacion.Reportes_Frms
{
    public partial class FrmReporteDocentesCargas : Form
    {
        private int count;
        private int cmbValueSemestre;
        private DataTable dtReporteData;
        private bool rbSiCumpleChecked;
        private bool rbNoCumpleChecked;
        private int horasExigibles;
        private List<int> idsCargaHorariaList = new List<int>();

        CN_Semestre objSemestre_N = new CN_Semestre();
        CN_CargaHoraria objCarga_N = new CN_CargaHoraria();
        CN_CargaHoraria objCarga_N2 = new CN_CargaHoraria();

        public FrmReporteDocentesCargas()
        {
            InitializeComponent();
            ClsStyles tableStyle = new ClsStyles();
            tableStyle.tableStyle(dgvReporteCargasDocentes);

            dgvReporteCargasDocentes.CellFormatting += dgvReporteCargasDocentes_CellFormatting;
            dgvReporteCargasDocentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporteCargasDocentes.ReadOnly = true;
        }

        private void FrmReporteDocentesCargas_Load(object sender, EventArgs e)
        {
            ListarSemestres();
            panelFilters.Visible = false;
        }

        #region GET DATA METHODS
        private void ListarSemestres()
        {
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
            cmbSemestre.SelectedValue = -1;
            cmbSemestre.SelectedIndex = -1;
        }
        #endregion

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            count++;
            if (cmbSemestre.SelectedIndex > -1 && count > 2)
            {
                panelFilters.Visible = true;
                btnExportAll.Visible = true;
                CN_CargaHoraria objCarga_N = new CN_CargaHoraria();
                cmbValueSemestre = Convert.ToInt32(cmbSemestre.SelectedValue);
                dgvReporteCargasDocentes.DataSource = null;
                dtReporteData = objCarga_N.MostrarReporteDocentes_ByIdSemestre_Negocio(cmbValueSemestre.ToString());
                //dgvReporteCargasDocentes.DataSource = objCarga_N.MostrarReporteDocentes_ByIdSemestre_Negocio(cmbValueSemestre.ToString());
                dgvReporteCargasDocentes.DataSource = dtReporteData;
                dgvReporteCargasDocentes.Columns[3].Visible = false;
                dgvReporteCargasDocentes.ClearSelection();
            }
        }

        private void dgvReporteCargasDocentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (e.Value != null && e.Value.ToString() == "SI CUMPLE")
                {
                    // Pintar de rojo si es = "SI CUMPLE"
                    e.CellStyle.BackColor = System.Drawing.Color.PaleGreen;
                    e.CellStyle.ForeColor = System.Drawing.Color.Black;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, System.Drawing.FontStyle.Bold);

                }
                else if (e.Value != null && e.Value.ToString() == "CARGA ACADÉMICA INEXISTENTE")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightSlateGray;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                    //e.CellStyle.Font = new Font(e.CellStyle.Font, System.Drawing.FontStyle.Bold);
                }
                else if (e.Value != null && e.Value.ToString() == "HORAS SOBRANTES")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.OrangeRed;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.BackColor = System.Drawing.Color.IndianRed;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, System.Drawing.FontStyle.Bold);
                }
            }
        }

        

        private void rbSiCumple_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSiCumple.Checked)
            {
                rbNoCumpleChecked = rbNoCumple.Checked;
                rbNoCumple.Checked = false;
                AplicarFiltro("[Cumple Horas Exigibles?] = 'SI CUMPLE'");
                RemoverFiltro(rbNoCumple);
                dgvReporteCargasDocentes.ClearSelection();
            }
        }

        private void rbNoCumple_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoCumple.Checked)
            {
                rbSiCumpleChecked = rbSiCumple.Checked;
                rbSiCumple.Checked = false;
                AplicarFiltro("[Cumple Horas Exigibles?] = 'NO CUMPLE'");
                RemoverFiltro(rbSiCumple);
                dgvReporteCargasDocentes.ClearSelection();
            }
        }

        private void rbNoFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoFilter.Checked)
            {
                rbSiCumple.Checked = rbSiCumpleChecked;
                rbNoCumple.Checked = rbNoCumpleChecked;
                AplicarFiltro("");
                RemoverFiltro(rbSiCumple);
                RemoverFiltro(rbNoCumple);
                dgvReporteCargasDocentes.ClearSelection();
            }
        }

        private void AplicarFiltro(string filtro)
        {
            // Aplicar el filtro al DataTable
            dtReporteData.DefaultView.RowFilter = filtro;

            // Actualizar la vista del DataGridView para reflejar el filtro
            dgvReporteCargasDocentes.DataSource = dtReporteData.DefaultView.ToTable();
            dgvReporteCargasDocentes.Refresh();
        }
        private void RemoverFiltro(RadioButton radioButton)
        {
            if (radioButton == rbSiCumple)
            {
                dtReporteData.DefaultView.RowFilter = "";
            }
            else if (radioButton == rbNoCumple)
            {
                dtReporteData.DefaultView.RowFilter = "";
            }
            else if (radioButton == rbNoFilter)
            {
                dtReporteData.DefaultView.RowFilter = "";
            }
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            //DataTable dataTable = ObtenerDatosDesdeBaseDeDatos(); // Obtener el DataTable lleno desde la base de datos
            idsCargaHorariaList = objCarga_N.GetIdsCargaHorariaLst_ByIdSemestre_Negocio(cmbSemestre.SelectedValue.ToString());
            // Crear un objeto SaveFileDialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Se obtiene la fecha para hacer nombre único al documento
            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("yyyyMMdd_HHmmss");

            // Establecer opciones de diálogo
            saveFileDialog1.Filter = "Archivos PDF|*.pdf";
            saveFileDialog1.Title = "Guardar documento PDF";
            // Mostrar el diálogo y guardar la ubicación seleccionada
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderPath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);

                // Generar y guardar un archivo PDF para cada elemento de la lista idsCargaHorariaList
                foreach (int idCargaHoraria in idsCargaHorariaList)
                {
                    // Obtener el nombre del docente (si es necesario) desde la base de datos o donde sea que esté almacenado
                    string docenteName = objCarga_N.GetDocenteNameByCrgHoraria_Negocio(idCargaHoraria.ToString());

                    // Establecer el nombre de archivo con el nombre del docente y la información adicional
                    string fileName = docenteName + "_CA_" + cmbSemestre.Text + "_" + formattedDateTime + ".pdf";
                    string filePath = System.IO.Path.Combine(folderPath, fileName);

                    // Generar el documento y guardarlo en filePath
                    GenerarDocumentoPDF(filePath, idCargaHoraria, docenteName);
                }
            }

        }

        private void GenerarDocumentoPDF(string filePath, int idCH, string docenteName)
        {
            // Generar el documento y guardarlo en filePath
            //GET DATA FOR DOCUMENT SECTION -----
            horasExigibles = objCarga_N.CheckHorasExigiblesDocenteByIdCarga_Negocio(idCH.ToString());
            CalcularHoras(idCH);
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


            Paragraph header = new Paragraph("Detalle de Carga Académica").SetFont(fontNegritaTitle).SetFontSize(20).SetTextAlignment(TextAlignment.CENTER);
            header.SetMarginBottom(10);
            doc.Add(header);

            Paragraph docenteData = new Paragraph("Docente: " + docenteName).SetFont(timesNewRoman).SetFontSize(12);
            docenteData.SetMarginBottom(-5);
            doc.Add(docenteData);

            Paragraph semestreData = new Paragraph("Semestre: " + cmbSemestre.Text).SetFont(timesNewRoman).SetFontSize(12);
            semestreData.SetMarginBottom(-5);
            doc.Add(semestreData);

            Paragraph docenteDepartamento = new Paragraph("Departamento: DETRI").SetFont(timesNewRoman).SetFontSize(12);
            docenteDepartamento.SetMarginBottom(-5);
            doc.Add(docenteDepartamento);

            Paragraph horasExigiblesData = new Paragraph("Horas exigibles: " + horasExigibles.ToString()).SetFont(timesNewRoman).SetFontSize(12);
            horasExigiblesData.SetMarginBottom(0);
            doc.Add(horasExigiblesData);

            Paragraph line = new Paragraph("__________________________________________________________________________________").SetFont(fontNegrita).SetFontSize(12);
            line.SetMarginBottom(5).SetMarginTop(-5);
            doc.Add(line);

            #region Gestion Asignaturas TABLE
            Paragraph AsignaturasTitle = new Paragraph("Gestión de Asignaturas").SetFont(fontNegrita).SetFontSize(14);
            AsignaturasTitle.SetMarginBottom(2);
            doc.Add(AsignaturasTitle);

            CN_CargaHoraria objCarga_N_L = new CN_CargaHoraria();
            CN_CargaHoraria objCarga_N2_L = new CN_CargaHoraria();

            // Carga los datos de la tabla desde la base de datos en un objeto DataTable
            DataTable dt = objCarga_N_L.LoadAllActividades_Negocio(idCH.ToString());

            DataTable dtAsignaturas = objCarga_N2_L.LoadAsignaturas_Negocio(idCH.ToString());
            // Crea una tabla con 4 columnas
            Table tableAsignaturas = new Table(4);

            foreach (DataColumn column in dtAsignaturas.Columns)
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
            foreach (DataRow row in dtAsignaturas.Rows)
            {
                for (int i = 1; i < dtAsignaturas.Columns.Count; i++)
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

            Paragraph AcividadesTitle = new Paragraph("Gestión de Actividades").SetFont(fontNegrita).SetFontSize(14);
            AcividadesTitle.SetMarginBottom(2);
            doc.Add(AcividadesTitle);

            // Crea una tabla con 4 columnas
            Table table = new Table(4);

            foreach (DataColumn column in dt.Columns)
            {
                if (column.Ordinal != 0)
                {
                    Cell cell = new Cell().Add(new Paragraph(column.ColumnName));
                    cell.SetTextAlignment(TextAlignment.CENTER);
                    cell.SetFont(fontNegrita).SetFontSize(10);
                    cell.SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(new DeviceRgb(230, 230, 230)); ;
                    table.AddHeaderCell(cell);
                }
            }

            // Agrega filas a la tabla
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    Cell cell = new Cell().Add(new Paragraph(row[i].ToString()));
                    cell.SetTextAlignment(TextAlignment.LEFT);
                    cell.SetFont(timesNewRoman).SetFontSize(10);
                    cell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    table.AddCell(cell);
                }
            }

            // Agrega espacio antes y después de la tabla
            table.SetMarginTop(10f);
            table.SetMarginBottom(10f);

            // Agrega la tabla al documento
            doc.Add(table);

            Paragraph HorasTotalesTitle = new Paragraph("HORAS TOTALES").SetFont(fontNegrita).SetFontSize(14);
            HorasTotalesTitle.SetMarginBottom(2);
            doc.Add(HorasTotalesTitle);

            // Crear una tabla con 2 columnas y 4 filas
            Table tableTotalHours = new Table(2);

            // Agregar la primera fila a la tabla
            tableTotalHours.AddCell("TOTAL DOCENCIA").SetFont(timesNewRoman).SetFontSize(10);
            tableTotalHours.AddCell(horasTotalesDocenciaT.ToString()).SetFont(timesNewRoman).SetFontSize(10);

            // Agregar la segunda fila a la tabla
            tableTotalHours.AddCell("TOTAL INVESTIGACION").SetFont(timesNewRoman).SetFontSize(10);
            tableTotalHours.AddCell((horasSemanalesInvestigacion + horasTotalesInvestigacion).ToString()).SetFont(timesNewRoman).SetFontSize(10);

            // Agregar la tercera fila a la tabla
            tableTotalHours.AddCell("TOTAL GESTION").SetFont(timesNewRoman).SetFontSize(10);
            tableTotalHours.AddCell((horasSemanalesGestion + horasTotalesGestion).ToString()).SetFont(timesNewRoman).SetFontSize(10);

            // Agregar la cuarta fila a la tabla
            tableTotalHours.AddCell("TOTAL").SetFont(timesNewRoman).SetFontSize(10);
            tableTotalHours.AddCell(horasTotalesCargaHoraria.ToString()).SetFont(timesNewRoman).SetFontSize(10);


            // Agrega espacio antes y después de la tabla
            tableTotalHours.SetMarginTop(10f);
            tableTotalHours.SetMarginBottom(20f);

            // Agregar la tabla al documento
            doc.Add(tableTotalHours);

            //  AGREGAR FIRMAS
            Table firmasTable = new Table(2);
            firmasTable.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER).UseAllAvailableWidth().SetMarginTop(70);

            Border border = Border.NO_BORDER;
            Cell lineaCell = new Cell().Add(new Paragraph("______________________________"));
            lineaCell.SetBorder(border);
            lineaCell.SetFontSize(8).SetTextAlignment(TextAlignment.CENTER);
            firmasTable.AddCell(lineaCell);
            Cell linea2Cell = new Cell().Add(new Paragraph("______________________________"));
            linea2Cell.SetBorder(border);
            linea2Cell.SetFontSize(8).SetMarginRight(20).SetTextAlignment(TextAlignment.CENTER);
            firmasTable.AddCell(linea2Cell);

            Cell nombre1Cell = new Cell().Add(new Paragraph(docenteName));
            nombre1Cell.SetBorder(border);
            nombre1Cell.SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
            firmasTable.AddCell(nombre1Cell);
            Cell nombre2Cell = new Cell().Add(new Paragraph("Jefe del DETRI"));
            nombre2Cell.SetBorder(border).SetFontSize(9).SetMarginLeft(20).SetTextAlignment(TextAlignment.CENTER);
            firmasTable.AddCell(nombre2Cell);

            doc.Add(firmasTable);

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
                //Image logoImage = new Image(ImageDataFactory.Create(logoImagePath));
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

        private static int numSemanasClase;
        private static int numSemanasSemestre;
        private static int horasSemanalesClases;
        private static int horasSemanalesDocenciaD11;
        private static int horasSemanalesDocenciaF11;
        private static int horasSemanalesGestion;
        private static int horasSemanalesInvestigacion;
        private static int horasTotalesDocenciaD11;
        private static int horasTotalesDocenciaF11;
        private static int horasTotalesDocenciaT;
        private static int horasTotalesGestion;
        private static int horasTotalesInvestigacion;
        private static int horasTotalesCargaHoraria;
        public void CalcularHoras(int idCarga)
        {
            //Cargamos valores de horas Totales en casillas

            //Obtencion de horas semanales
            horasSemanalesClases = numSemanasClase * objCarga_N.GetSemanalHoursClasesNegocio(idCarga.ToString());
            horasSemanalesDocenciaD11 = numSemanasClase * objCarga_N.GetSemanalHoursDocenciaD11Negocio(idCarga.ToString());
            horasSemanalesDocenciaF11 = numSemanasSemestre * objCarga_N.GetSemanalHoursDocenciaF11Negocio(idCarga.ToString());
            horasSemanalesGestion = numSemanasSemestre * objCarga_N.GetSemanalHoursGestionNegocio(idCarga.ToString());
            horasSemanalesInvestigacion = numSemanasSemestre * objCarga_N.GetSemanalHoursInvestigacionNegocio(idCarga.ToString());
            //Obtencion de horas totales de actividades
            horasTotalesGestion = objCarga_N.GetTotalHoursGestionNegocio(idCarga.ToString());
            horasTotalesDocenciaD11 = objCarga_N.GetTotalHoursDocenciaD11Negocio(idCarga.ToString());
            horasTotalesDocenciaF11 = objCarga_N.GetTotalHoursDocenciaF11Negocio(idCarga.ToString());
            horasTotalesInvestigacion = objCarga_N.GetTotalHoursInvestigacionNegocio(idCarga.ToString());
            int horasTotalesByActTotalHour = horasTotalesInvestigacion + horasTotalesGestion + horasTotalesDocenciaD11 + horasTotalesDocenciaF11;
            horasTotalesDocenciaT = horasSemanalesDocenciaD11 + horasSemanalesClases + horasSemanalesDocenciaF11;
            horasTotalesCargaHoraria = horasTotalesDocenciaT + horasSemanalesGestion +
                horasSemanalesInvestigacion + horasTotalesByActTotalHour;
        }
    }
}
