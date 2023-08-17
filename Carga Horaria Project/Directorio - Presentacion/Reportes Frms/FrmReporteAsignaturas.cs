
using Directorio_Logica;
using Directorio___Presentacion.ElementsStyles_Configuration;
using System.Windows.Documents;
using System.Data;

namespace Directorio___Presentacion.Reportes_Frms
{
    public partial class FrmReporteAsignaturas : Form
    {
        #region Define Variables
        CN_Semestre objSemestre_N = new CN_Semestre();
        private CN_Semestre objSemestre_Neg;
        CN_Docente objDocente_N = new CN_Docente();
        CN_TipoDocente objTpDocente = new CN_TipoDocente();
        private ClsStyles clsStyles = new ClsStyles();

        private bool Editar = false;
        private DataTable dtData;

        private ClsPdfFormat clsPdf = new ClsPdfFormat();
        private string filtroText = "Asignaturas con Docente asignado";
        private DataTable dtDataPDF;
        #endregion

        public FrmReporteAsignaturas()
        {
            InitializeComponent();
        }

        private void FrmReporteAsignaturas_Load(object sender, EventArgs e)
        {
            panelDataShow.Visible = false;
            ListarSemestres();
        }

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarAsignaturas();
            if (rbGRNoAsignados.Checked)
            {
                rbGRAsignados.Checked = true;
            }
        }
        private void ListarSemestres()
        {
            cmbSemestre.SelectedIndexChanged -= cmbSemestre_SelectedIndexChanged;
            cmbSemestre.DisplayMember = "Código";
            cmbSemestre.ValueMember = "ID";
            cmbSemestre.DataSource = objSemestre_N.MostrarSemestres();
            cmbSemestre.SelectedIndex = -1;
            cmbSemestre.SelectedIndexChanged += cmbSemestre_SelectedIndexChanged;
        }

        private void MostrarAsignaturas()
        {
            if (cmbSemestre.SelectedValue != null)
            {
                panelInfo.Visible = true;
                CN_Asignatura objAsignatura = new CN_Asignatura();
                CN_Asignatura objAsignatura2 = new CN_Asignatura();
                string idSemestre = cmbSemestre.SelectedValue.ToString();
                LimpiarTabla();

                // Cargar el contenido de la tabla
                panelDataShow.Visible = true;
                dtData = objAsignatura.MostrarRegistrosAsignaturaWithDocenteByIdSemestre_Negocio(idSemestre);
                dtDataPDF = dtData;
                lblNumSiDocente.Text = dtData.Rows.Count.ToString();
                DataTable dataNoAsignado = objAsignatura2.MostrarRegistrosAsignaturaWithOutDocenteByIdSemestre_Negocio(idSemestre);
                lblNumNoDocente.Text = dataNoAsignado.Rows.Count.ToString();
                dgvReporte.DataSource = dtData;
                panelFilters.Visible = true;

                dgvReporte.Columns[0].Visible = false;
                clsStyles.tableActivateDocentesStyle(dgvReporte);
                dgvReporte.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
        }
        private void LimpiarTabla()
        {            dgvReporte.DataSource = null;
            dgvReporte.Rows.Clear();
            dgvReporte.Columns.Clear();
        }

        private void rbGRAsignados_CheckedChanged(object sender, EventArgs e)
        {
            MostrarAsignaturas();
            txtFiltro.Text = "";
            filtroText = "Asignaturas con Docente asignado";
        }

        private void rbGRNoAsignados_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            filtroText = "Asignaturas no asignadas";
            CN_Docente objDocente_N = new CN_Docente();
            CN_Asignatura objAsignatura = new CN_Asignatura();
            string idSemestre = cmbSemestre.SelectedValue.ToString();
            LimpiarTabla();

            // Cargar el contenido de la tabla
            panelDataShow.Visible = true;
            dtData = objAsignatura.MostrarRegistrosAsignaturaWithOutDocenteByIdSemestre_Negocio(idSemestre);
            dtDataPDF = dtData;
            dgvReporte.DataSource = dtData;

            dgvReporte.Columns[0].Visible = false;
            clsStyles.tableActivateDocentesStyle(dgvReporte);
            dgvReporte.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim(); 
            DataTable dataTableFiltrado = FiltrarDataTable(dtData, filtro);
            dtDataPDF = dataTableFiltrado;
            dgvReporte.DataSource = dataTableFiltrado;
        }

        private DataTable FiltrarDataTable(DataTable dataTable, string filtro)
        {
            DataTable dataTableFiltrado = dataTable.Clone();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.ItemArray.Any(field => field.ToString().IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    dataTableFiltrado.ImportRow(row);
                }
            }

            return dataTableFiltrado;
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tecla = char.ToUpper(e.KeyChar);

            e.KeyChar = tecla;
            e.Handled = false;
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("yyyyMMdd_HHmmss");

            // Establecer opciones de diálogo
            saveFileDialog1.Filter = "Archivos PDF|*.pdf";
            saveFileDialog1.Title = "Guardar documento PDF";
            saveFileDialog1.FileName = "Reporte_Asignaturas_" + cmbSemestre.Text + "_" + filtroText.Replace(" ", "_") + "_" + formattedDateTime + ".pdf";
            // Mostrar el diálogo y guardar la ubicación seleccionada
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string folderPath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                //string fileName = "Reporte_Comisiones_" + cmbSemestre.Text + "_" + formattedDateTime + ".pdf";
                //string filePath = System.IO.Path.Combine(folderPath, fileName);
                string pdfTitle = "REPORTE DE ASIGNATURAS";

                clsPdf.GenerarDocumentoOneTablePDF(filePath, pdfTitle, filePath, cmbSemestre.Text, filtroText, dtDataPDF);
            }
        }
    }
}
