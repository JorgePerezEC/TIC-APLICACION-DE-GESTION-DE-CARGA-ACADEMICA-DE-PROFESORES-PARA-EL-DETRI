using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Directorio_Logica;
using Directorio_LogicaNegocio;
using Directorio_Entidades;
using Directorio___Presentacion.ElementsStyles_Configuration;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Font = iTextSharp.text.Font;
using System.Windows.Forms;

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

        #region Constructor
        public FrmAcademicsLoads_Viewer()
        {
            InitializeComponent();
            ClsStyles tableStyle = new ClsStyles();
            tableStyle.tableStyle(dgvActividades);
            tableStyle.tableStyle(dgvAsignaturas);
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
                if (e.Node.Text != "Departamentos")
                {
                    panelDocenteInfo.Visible = true;

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
            saveFileDialog1.FileName = docenteName +"_CargaAcademica_" + cmbSemestre.Text;

            // Mostrar el diálogo y guardar el archivo si el usuario hace clic en Guardar
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                // Generar el documento y guardarlo en filePath
                // Crea un objeto Document
                Document doc = new Document(new iTextSharp.text.Rectangle(297, 210), 10, 10, 10, 10);
                doc.AddTitle("The document title - PDF creation using iTextSharp");
                // Establecer la orientación horizontal
                doc.SetPageSize(PageSize.A4);
                doc.SetMargins(50, 50, 50, 50);

                // Carga los datos de la tabla desde la base de datos en un objeto DataTable
                DataTable dt = objetoCarga_N.LoadAllActividades_Negocio(idCH.ToString());

                DataTable dtAsignaturas = objetoCarga_N_2.LoadAsignaturas_Negocio(idCH.ToString());
                // Crea un objeto PdfWriter para escribir en el archivo PDF
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                
                // Abre el documento para escribir
                doc.Open();
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"Images/EPNLogo.png");
                // Agrega un encabezado al documento

                // Crea un objeto Font con estilo "negrita"
                Font fontNegritaTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                Font fontNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);

                Paragraph header = new Paragraph("Carga Académica", fontNegritaTitle);
                header.Alignment = Element.ALIGN_CENTER;
                header.SpacingAfter= 10;
                doc.Add(header);

                Paragraph docenteData = new Paragraph("Docente: "+ docenteName, fontNegrita);
                docenteData.Alignment = Element.ALIGN_LEFT;
                docenteData.SpacingAfter = 3;
                doc.Add(docenteData);

                Paragraph semestreData = new Paragraph("Semestre: " + cmbSemestre.Text, fontNegrita);
                semestreData.Alignment = Element.ALIGN_LEFT;
                semestreData.SpacingAfter = 10;
                doc.Add(semestreData);

                #region Gestion Asignaturas TABLE
                Paragraph AsignaturasTitle = new Paragraph("Gestión de Asignaturas", fontNegrita);
                AsignaturasTitle.Alignment = Element.ALIGN_LEFT;
                AsignaturasTitle.SpacingAfter = 10;
                doc.Add(AsignaturasTitle);

                // Crea una tabla con 4 columnas
                PdfPTable tableAsignaturas = new PdfPTable(4);

                foreach (DataColumn column in dtAsignaturas.Columns)
                {
                    if (column.Ordinal != 0)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        tableAsignaturas.AddCell(new Phrase(column.ColumnName));
                    }
                }

                // Agrega filas a la tabla
                foreach (DataRow row in dtAsignaturas.Rows)
                {
                    for (int i = 1; i < dtAsignaturas.Columns.Count; i++)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(row[i].ToString()));
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        tableAsignaturas.AddCell(cell);
                    }
                }
                // Agrega espacio antes de la tabla
                tableAsignaturas.SpacingBefore = 10f; // 10 puntos de espacio antes de la tabla

                // Agrega la tabla al documento
                doc.Add(tableAsignaturas);
                // Agrega espacio después de la tabla
                tableAsignaturas.SpacingAfter = 10f; // 10 puntos de espacio después de la tabla
                #endregion


                Paragraph AcividadesTitle = new Paragraph("Gestión de Actividades", fontNegrita);
                AcividadesTitle.Alignment = Element.ALIGN_LEFT;
                AcividadesTitle.SpacingAfter = 10;
                doc.Add(AcividadesTitle);

                // Crea una tabla con 4 columnas
                PdfPTable table = new PdfPTable(4);

                foreach (DataColumn column in dt.Columns)
                {
                    if (column.Ordinal != 0)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        table.AddCell(new Phrase(column.ColumnName));
                    }
                }

                // Agrega filas a la tabla
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(row[i].ToString()));
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        table.AddCell(cell);
                    }
                }
                // Agrega espacio antes de la tabla
                table.SpacingBefore = 10f; // 10 puntos de espacio antes de la tabla

                // Agrega la tabla al documento
                doc.Add(table);
                // Agrega espacio después de la tabla
                table.SpacingAfter = 10f; // 10 puntos de espacio después de la tabla

                Paragraph HorasTotalesTitle = new Paragraph("HORAS TOTALES", fontNegrita);
                HorasTotalesTitle.Alignment = Element.ALIGN_LEFT;
                HorasTotalesTitle.SpacingAfter = 10;
                doc.Add(HorasTotalesTitle);

                // Crear una tabla con 2 columnas y 4 filas
                PdfPTable tableTotalHours = new PdfPTable(2);

                // Agregar la primera fila a la tabla
                tableTotalHours.AddCell("TOTAL DOCENCIA");
                tableTotalHours.AddCell(horasTotalesDocenciaT.ToString());

                // Agregar la segunda fila a la tabla
                tableTotalHours.AddCell("TOTAL INVESTIGACION");
                tableTotalHours.AddCell(horasTotalesInvestigacion.ToString());

                // Agregar la tercera fila a la tabla
                tableTotalHours.AddCell("TOTAL GESTION");
                tableTotalHours.AddCell(horasTotalesGestion.ToString());

                // Agregar la cuarta fila a la tabla
                PdfPCell totalCell = new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont(FontFactory.HELVETICA_BOLD)));
                tableTotalHours.AddCell(totalCell);
                tableTotalHours.AddCell(horasTotalesCargaHoraria.ToString());

                // Agregar la tabla al documento
                doc.Add(tableTotalHours);

                // Cierra el documento
                doc.Close();
            }

            
        }
    }
}
