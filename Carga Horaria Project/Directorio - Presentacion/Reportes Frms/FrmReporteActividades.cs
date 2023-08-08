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
    public partial class FrmReporteActividades : Form
    {
        #region Define Variables
        CN_Semestre objSemestre_N = new CN_Semestre();
        private CN_Semestre objSemestre_Neg;
        CN_Docente objDocente_N = new CN_Docente();
        CN_TipoDocente objTpDocente = new CN_TipoDocente();
        private ClsStyles clsStyles = new ClsStyles();

        private bool Editar = false;
        private DataTable dtActividades;
        private DataTable dtData;

        private ClsPdfFormat clsPdf = new ClsPdfFormat();
        private string filtroText = "Sin filtro";
        private DataTable dtDataPDF;
        #endregion
        public FrmReporteActividades()
        {
            InitializeComponent();
        }
        private void FrmReporteActividades_Load(object sender, EventArgs e)
        {
            panelDataShow.Visible = false;
            ListarSemestres();
        }

        private void cmbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarActividades();
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
        private void MostrarActividades()
        {
            if (cmbSemestre.SelectedValue != null)
            {
                //panelInfo.Visible = true;
                string idSemestre = cmbSemestre.SelectedValue.ToString();
                CN_CargaHoraria objCargaH = new CN_CargaHoraria();
                LimpiarTabla();

                // Cargar el contenido de la tabla
                panelDataShow.Visible = true;
                dtData = objCargaH.MostrarReporteActividadesD11D_ByIdSemestre_Negocio(idSemestre);
                //lblNumSiDocente.Text = dtData.Rows.Count.ToString();
                //lblNumNoDocente.Text = dataNoAsignado.Rows.Count.ToString();
                dgvReporte.DataSource = dtData;
                dtDataPDF = dtData;
                panelFilters.Visible = true;

                dgvReporte.Columns[0].Visible = false;
                clsStyles.tableStyle(dgvReporte);
                dgvReporte.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
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
        private void LimpiarTabla()
        {
            dgvReporte.DataSource = null;
            dgvReporte.Rows.Clear();
            dgvReporte.Columns.Clear();
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tecla = char.ToUpper(e.KeyChar);

            e.KeyChar = tecla;
            e.Handled = false;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
            DataTable dataTableFiltrado = FiltrarDataTable(dtData, filtro);

            dgvReporte.DataSource = dataTableFiltrado;
            dtDataPDF = dataTableFiltrado;
        }

        private void rbD11_CheckedChanged(object sender, EventArgs e)
        {
            if (rbD11.Checked)
            {
                FiltrarYActualizarDataGrid("D11");
                filtroText = "Actividades de Docencia D11";
            }
        }

        private void rbF11_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF11.Checked)
            {
                FiltrarYActualizarDataGrid("D");
                panelLecturaDiv.Visible = true;
                filtroText = "Actividades de Docencia Fuera del 11";
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
            
            if (rbF11.Checked)
            {
                // Verificar que el TextBox tenga un valor numérico válido antes de realizar la división.
                if (double.TryParse(txtB.Text, out double divisor) && divisor != 0)
                {
                    // Agregar una nueva columna "ResultadoDivisión" al DataTable y calcular los valores.
                    dataTableFiltrado.Columns.Add("Horas de Lectura", typeof(int));

                    foreach (DataRow row in dataTableFiltrado.Rows)
                    {
                        // Realizar la división y almacenar el resultado redondeado al entero superior.
                        double valorUltimaColumna = Convert.ToDouble(row[dataTableFiltrado.Columns.Count - 2]); // Suponiendo que la última columna es la penúltima en la colección.
                        int resultadoDivision = (int)Math.Ceiling(valorUltimaColumna / divisor);
                        row["Horas de Lectura"] = resultadoDivision;
                    }
                }
                else
                {
                    // El valor del divisor no es válido o es cero, establecer "NA" en la nueva columna.
                    dataTableFiltrado.Columns.Add("Horas de Lectura", typeof(string));
                    foreach (DataRow row in dataTableFiltrado.Rows)
                    {
                        row["Horas de Lectura"] = "NA";
                    }
                }
            }
            dgvReporte.DataSource = dataTableFiltrado;
            dtDataPDF = dataTableFiltrado;
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            FiltrarYActualizarDataGrid("D");
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("yyyyMMdd_HHmmss");

            // Establecer opciones de diálogo
            saveFileDialog1.Filter = "Archivos PDF|*.pdf";
            saveFileDialog1.Title = "Guardar documento PDF";
            saveFileDialog1.FileName = "Reporte_Actividades_" + cmbSemestre.Text + "_" + filtroText.Replace(" ", "_") + "_" + formattedDateTime + ".pdf";
            // Mostrar el diálogo y guardar la ubicación seleccionada
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string folderPath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                string pdfTitle = "REPORTE DE ACTIVIDADES";

                clsPdf.GenerarDocumentoOneTablePDF(filePath, pdfTitle, filePath, cmbSemestre.Text, filtroText, dtDataPDF);
            }
        }
    }
}
