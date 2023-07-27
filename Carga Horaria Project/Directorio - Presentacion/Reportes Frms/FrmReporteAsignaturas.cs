
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
        private DataTable dtAsignaturas;
        private DataTable dtData;
        private int idTipoDocente = 7;
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
        {
            dgvReporte.DataSource = null;
            dgvReporte.Rows.Clear();
            dgvReporte.Columns.Clear();
        }

        private void rbGRAsignados_CheckedChanged(object sender, EventArgs e)
        {
            MostrarAsignaturas();
            txtFiltro.Text = "";
        }

        private void rbGRNoAsignados_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            CN_Docente objDocente_N = new CN_Docente();
            CN_Asignatura objAsignatura = new CN_Asignatura();
            string idSemestre = cmbSemestre.SelectedValue.ToString();
            LimpiarTabla();

            // Cargar el contenido de la tabla
            panelDataShow.Visible = true;
            dtData = objAsignatura.MostrarRegistrosAsignaturaWithOutDocenteByIdSemestre_Negocio(idSemestre);
            dgvReporte.DataSource = dtData;

            dgvReporte.Columns[0].Visible = false;
            clsStyles.tableActivateDocentesStyle(dgvReporte);
            dgvReporte.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim(); 
            DataTable dataTableFiltrado = FiltrarDataTable(dtData, filtro);

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
    }
}
