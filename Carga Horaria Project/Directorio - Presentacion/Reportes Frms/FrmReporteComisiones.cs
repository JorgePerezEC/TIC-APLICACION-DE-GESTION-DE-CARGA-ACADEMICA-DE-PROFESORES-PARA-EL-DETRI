using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.Reportes_Frms
{
    public partial class FrmReporteComisiones : Form
    {
        #region Define Variables
        CN_Semestre objSemestre_N = new CN_Semestre();
        private CN_Semestre objSemestre_Neg;
        CN_Docente objDocente_N = new CN_Docente();
        CN_TipoDocente objTpDocente = new CN_TipoDocente();
        private ClsStyles clsStyles = new ClsStyles();

        private ClsPdfFormat clsPdf = new ClsPdfFormat();
        private string filtroText = "Sin filtro";
        private DataTable dtDataPDF;

        private DataTable dtData;

        #endregion
        public FrmReporteComisiones()
        {
            InitializeComponent();
        }

        private void FrmReporteComisiones_Load(object sender, EventArgs e)
        {
            panelDataShow.Visible = false;
            ListarSemestres();
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

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarActividades();
            rbNoFilter.Checked = true;
        }
        private void MostrarActividades()
        {
            if (cmbSemestre.SelectedValue != null)
            {
                //panelInfo.Visible = true;
                panelFilters.Visible = true;
                string idSemestre = cmbSemestre.SelectedValue.ToString();
                CN_CargaHoraria objCargaH = new CN_CargaHoraria();
                LimpiarTabla();

                // Cargar el contenido de la tabla
                panelDataShow.Visible = true;
                dtData = objCargaH.MostrarReporteActividadesComisiones_ByIdSemestre_Negocio(idSemestre);
                dtDataPDF = dtData;
                //lblNumSiDocente.Text = dtData.Rows.Count.ToString();
                //lblNumNoDocente.Text = dataNoAsignado.Rows.Count.ToString();
                dgvReporte.DataSource = dtData;
                panelFilters.Visible = true;

                dgvReporte.Columns[0].Visible = false;
                clsStyles.tableStyle(dgvReporte);
                dgvReporte.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
        }
        private void LimpiarTabla()
        {
            dgvReporte.DataSource = null;
            dgvReporte.Rows.Clear();
            dgvReporte.Columns.Clear();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
            DataTable dataTableFiltrado = FiltrarDataTable(dtData, filtro);
            dtDataPDF = FiltrarDataTable(dtData, filtro);
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

        #region RadioButtons Section
        private void rbGestion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGestion.Checked)
            {
                FiltrarYActualizarDataGrid("G");
                filtroText = "Actividades de Gestión";
            }
        }

        private void rbInvestigacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInvestigacion.Checked)
            {
                FiltrarYActualizarDataGrid("I");
                filtroText = "Actividades de Investigación";
            }
        }

        private void rbNoFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoFilter.Checked)
            {
                MostrarActividades();
                txtFiltro.Text = "";
                filtroText = "Sin Filtro";
            }
        }
        #endregion

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tecla = char.ToUpper(e.KeyChar);

            e.KeyChar = tecla;
            e.Handled = false;
        }
        private DataTable FiltrarDataTableRb(DataTable dataTable, string filtro)
        {
            DataTable dataTableFiltrado = dataTable.Clone();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["TIPO"].ToString().Equals(filtro, StringComparison.OrdinalIgnoreCase))
                {
                    dataTableFiltrado.ImportRow(row);
                }
            }

            return dataTableFiltrado;
        }
        private void FiltrarYActualizarDataGrid(string filtro)
        {
            DataTable dataTableFiltrado = FiltrarDataTableRb(dtData, filtro);
            dtDataPDF = FiltrarDataTableRb(dtData, filtro);
            dgvReporte.DataSource = dataTableFiltrado;
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("yyyyMMdd_HHmmss");

            // Establecer opciones de diálogo
            saveFileDialog1.Filter = "Archivos PDF|*.pdf";
            saveFileDialog1.Title = "Guardar documento PDF";
            saveFileDialog1.FileName = "Reporte_Comisiones_" + cmbSemestre.Text + "_" + filtroText.Replace(" ","_") + "_" + formattedDateTime + ".pdf";
            // Mostrar el diálogo y guardar la ubicación seleccionada
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string folderPath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                //string fileName = "Reporte_Comisiones_" + cmbSemestre.Text + "_" + formattedDateTime + ".pdf";
                //string filePath = System.IO.Path.Combine(folderPath, fileName);
                string pdfTitle = "REPORTE DE COMISIONES";

                clsPdf.GenerarDocumentoOneTablePDF(filePath, pdfTitle, filePath, cmbSemestre.Text, filtroText, dtDataPDF);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
