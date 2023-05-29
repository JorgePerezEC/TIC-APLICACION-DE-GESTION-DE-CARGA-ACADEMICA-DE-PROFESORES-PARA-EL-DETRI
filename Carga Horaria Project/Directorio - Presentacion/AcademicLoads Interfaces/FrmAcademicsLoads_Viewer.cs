using System;
using System.Data;
using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using Directorio_LogicaNegocio;
using iText.IO.Font;
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

namespace Directorio___Presentacion.AcademicLoads_Interfaces
{
    public partial class FrmAcademicsLoads_Viewer : Form
    {
        //private CN_Docente objetoCNegocio = new CN_Docente();
        CN_Docente objetoNDocente = new CN_Docente();
        CN_Semestre objSemestre_N = new CN_Semestre();
        CN_Departamento objetoNDepartamento = new CN_Departamento();
        CN_CargaHoraria objetoCarga_N = new CN_CargaHoraria();
        CN_CargaHoraria objetoCarga_N_2 = new CN_CargaHoraria();

        private int cmbValueSemestre;
        private int idDocente;
        private int idCH;
        private int count;

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

        private static int horasExigibles;
        private static int horasExigiblesFaltantes;

        private static string docenteName;

        ClsStyles tableStyle = new ClsStyles();

        #region Constructor
        public FrmAcademicsLoads_Viewer()
        {
            InitializeComponent();


        }
        #endregion

        private void FrmAcademicsLoads_Manager_Load(object sender, EventArgs e)
        {
            //FillTreeView();
            ListarSemestres();
            cmbSemestre.SelectedValue = -1;
            cmbSemestre.SelectedIndex = -1;
        }

        private void ListarSemestres()
        {
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
        }

        #region TreeView Fill Nodes

        private void FillTreeView(int idSemestre)
        {
            // Obtener los datos de los departamentos
            DataTable dtDepartamentos = objetoNDepartamento.MostrarDepartamentosTV();

            // Crear el nodo padre del treeview
            TreeNode parentNode = new TreeNode("Departamentos");
            parentNode.Tag = "0";

            // Recorrer la tabla y crear los nodos hijos
            foreach (DataRow row in dtDepartamentos.Rows)
            {
                // Crear el nodo hijo
                TreeNode childNode = new TreeNode(row["Departamento"].ToString());
                childNode.Tag = row["ID"].ToString();

                // Agregar el nodo hijo al nodo padre
                parentNode.Nodes.Add(childNode);

                // Obtener los datos de los docentes y crear los nodos nietos
                DataTable dtDocentes = objetoNDocente.MostrarDocentesByDepId(Convert.ToString(row["ID"]), idSemestre.ToString());

                foreach (DataRow childRow in dtDocentes.Rows)
                {
                    TreeNode grandChildNode = new TreeNode(childRow["Docente"].ToString());
                    grandChildNode.Tag = childRow["ID"].ToString();

                    // Agregar el nodo nieto al nodo hijo
                    childNode.Nodes.Add(grandChildNode);
                }
            }

            // Agregar el nodo padre al treeview
            tvDocentesLst.Nodes.Add(parentNode);
        }

        #endregion

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private TreeNode ultimoNodoSeleccionado;


        private void tvDocentesLst_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CN_CargaHoraria objetoCarga_N = new CN_CargaHoraria();
            CN_CargaHoraria objetoCarga_N_2 = new CN_CargaHoraria();

            if (e.Node == ultimoNodoSeleccionado)
            {
                return;
            }

            dgvActividades.DataSource = null;
            dgvAsignaturas.DataSource = null;

            dgvAsignaturas.Refresh();
            dgvActividades.Refresh();

            int id;
            cmbValueSemestre = Convert.ToInt32(cmbSemestre.SelectedValue);
            if (int.TryParse(e.Node.Tag.ToString(), out id))
            {
                if (e.Node.Text != "Departamentos" || e.Node.Text != "DETRI")
                {
                    panelDocenteInfo.Visible = true;
                    panelMain.Visible = true;

                    lblDocenteName.Text = string.Empty;
                    lblSemestre.Text = string.Empty;
                    lblHorasExigibles.Text = string.Empty;


                    idCH = objetoCarga_N.GetIDCargaHorariaNegocio(cmbValueSemestre.ToString(), id.ToString());
                    docenteName = objetoCarga_N.GetDocenteNameByCrgHoraria_Negocio(idCH.ToString());
                    horasExigibles = objetoCarga_N.CheckHorasExigiblesDocenteByIdCarga_Negocio(idCH.ToString());

                    dgvAsignaturas.Refresh();
                    dgvActividades.Refresh();

                    dgvActividades.DataSource = null; // Eliminar el origen de datos actual
                    dgvActividades.DataSource = objetoCarga_N.LoadAllActividades_Negocio(idCH.ToString());
                    dgvActividades.Columns[0].Visible = false;

                    dgvAsignaturas.DataSource = null; // Eliminar el origen de datos actual
                    dgvAsignaturas.DataSource = objetoCarga_N_2.LoadAsignaturas_Negocio(idCH.ToString());
                    dgvAsignaturas.Columns[0].Visible = false;

                    tableStyle.tableStyle(dgvActividades);
                    tableStyle.tableStyle(dgvAsignaturas);

                    lblDocenteName.Text = docenteName;
                    lblSemestre.Text = cmbSemestre.Text;
                    lblHorasExigibles.Text = horasExigibles.ToString();

                    CalcularHoras(idCH);
                }
            }

            ultimoNodoSeleccionado = e.Node;
        }



        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            count++;
            if (cmbSemestre.SelectedIndex > -1 && count > 2)
            {
                tvDocentesLst.Visible = true;
                cmbValueSemestre = Convert.ToInt32(cmbSemestre.SelectedValue);
                numSemanasClase = objetoCarga_N.GetSemanasClase_Negocio(cmbValueSemestre.ToString());
                numSemanasSemestre = objetoCarga_N.GetSemanasSemestre_Negocio(cmbValueSemestre.ToString());
                FillTreeView(cmbValueSemestre);
            }
        }

        public void CalcularHoras(int idCarga)
        {
            //Cargamos valores de horas Totales en casillas

            //Obtencion de horas semanales
            txtHorasT_Semana.Text = objetoCarga_N.GetSemanalHoursClasesNegocio(idCarga.ToString()).ToString();
            horasSemanalesClases = numSemanasClase * objetoCarga_N.GetSemanalHoursClasesNegocio(idCarga.ToString());
            txtHorasT_Semestre.Text = horasSemanalesClases.ToString();
            horasSemanalesDocenciaD11 = numSemanasClase * objetoCarga_N.GetSemanalHoursDocenciaD11Negocio(idCarga.ToString());
            horasSemanalesDocenciaF11 = numSemanasClase * objetoCarga_N.GetSemanalHoursDocenciaF11Negocio(idCarga.ToString());
            horasSemanalesGestion = numSemanasClase * objetoCarga_N.GetSemanalHoursGestionNegocio(idCarga.ToString());
            horasSemanalesInvestigacion = numSemanasClase * objetoCarga_N.GetSemanalHoursInvestigacionNegocio(idCarga.ToString());
            //Obtencion de horas totales de actividades
            horasTotalesGestion = objetoCarga_N.GetTotalHoursGestionNegocio(idCarga.ToString());
            horasTotalesDocenciaD11 = objetoCarga_N.GetTotalHoursDocenciaD11Negocio(idCarga.ToString());
            horasTotalesDocenciaF11 = objetoCarga_N.GetTotalHoursDocenciaF11Negocio(idCarga.ToString());
            horasTotalesInvestigacion = objetoCarga_N.GetTotalHoursInvestigacionNegocio(idCarga.ToString());
            int horasTotalesByActTotalHour = horasTotalesInvestigacion + horasTotalesGestion + horasTotalesDocenciaD11 + horasTotalesDocenciaF11;
            horasTotalesDocenciaT = horasSemanalesDocenciaD11 + horasSemanalesClases + horasSemanalesDocenciaF11;
            horasTotalesCargaHoraria = horasTotalesDocenciaT + horasSemanalesGestion +
                horasSemanalesInvestigacion + horasTotalesByActTotalHour;

            lblTotalDocencia.Text = horasTotalesDocenciaT.ToString();
            lblTotalGestion.Text = (horasSemanalesGestion + horasTotalesGestion).ToString();
            lblTotalInv.Text = (horasSemanalesInvestigacion + horasTotalesInvestigacion).ToString();
            lblHorasTotales.Text = horasTotalesCargaHoraria.ToString();

        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Crear un objeto SaveFileDialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Establecer opciones de diálogo
            saveFileDialog1.Filter = "Archivos PDF|*.pdf";
            saveFileDialog1.Title = "Guardar documento PDF";
            saveFileDialog1.FileName = docenteName + "_CargaAcademica_" + cmbSemestre.Text;

            // Mostrar el diálogo y guardar el archivo si el usuario hace clic en Guardar
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                // Generar el documento y guardarlo en filePath

                // Crea un objeto PdfDocument con el PdfWriter
                PdfDocument pdf = new PdfDocument(new PdfWriter(filePath));

                // Crea un objeto Document asociado al PdfDocument
                Document doc = new Document(pdf, PageSize.A4);

                // Establecer márgenes
                doc.SetMargins(50, 50, 50, 50);

                // Agrega un encabezado al documento
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

                Paragraph horasExigiblesData = new Paragraph("Horas exigibles: " + horasExigibles.ToString ()).SetFont(timesNewRoman).SetFontSize(12);
                horasExigiblesData.SetMarginBottom(0);
                doc.Add(horasExigiblesData);

                Paragraph line = new Paragraph("__________________________________________________________________________________").SetFont(fontNegrita).SetFontSize(12);
                line.SetMarginBottom(5).SetMarginTop (-5);
                doc.Add(line);

                #region Gestion Asignaturas TABLE
                Paragraph AsignaturasTitle = new Paragraph("Gestión de Asignaturas").SetFont(fontNegrita).SetFontSize(14);
                AsignaturasTitle.SetMarginBottom(2);
                doc.Add(AsignaturasTitle);

                // Carga los datos de la tabla desde la base de datos en un objeto DataTable
                DataTable dt = objetoCarga_N.LoadAllActividades_Negocio(idCH.ToString());

                DataTable dtAsignaturas = objetoCarga_N_2.LoadAsignaturas_Negocio(idCH.ToString());
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
                tableTotalHours.SetMarginBottom(10f);

                // Agregar la tabla al documento
                doc.Add(tableTotalHours);

                

                // Agregar el evento del pie de página y el encabezado al documento
                CustomPageEventHandler handler = new CustomPageEventHandler();
                pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, handler);

                // Cierra el documento
                doc.Close();
            }
        }

        class CustomPageEventHandler : IEventHandler
        {
            private string logoImagePath = "C:\\Users\\jorge\\OneDrive - Escuela Politécnica Nacional\\TESIS LAPTOP SYNC\\resp\\Carga Horaria Project\\Directorio - Presentacion\\Images\\EPNLogo.png";
            public void HandleEvent(Event @event)
            {
                Image logoImage = new Image(ImageDataFactory.Create(logoImagePath));

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
