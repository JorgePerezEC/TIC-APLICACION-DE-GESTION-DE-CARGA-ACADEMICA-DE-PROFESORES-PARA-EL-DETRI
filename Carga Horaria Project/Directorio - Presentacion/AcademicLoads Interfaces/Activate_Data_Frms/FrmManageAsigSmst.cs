using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.AcademicLoads_Interfaces.Activate_Data_Frms
{
    public partial class FrmManageAsigSmst : Form
    {
        #region Define Variables
        CN_Semestre objSemestre_N = new CN_Semestre();
        private CN_Semestre objSemestre_Neg;
        private ClsStyles clsStyles = new ClsStyles();

        private DataTable dtAsignaturas;
        #endregion

        public FrmManageAsigSmst()
        {
            InitializeComponent();
        }

        private void FrmManageAsigSmst_Load(object sender, EventArgs e)
        {
            panelContent.Visible = false;
            ListarSemestres();
        }

        private void LimpiarTabla()
        {
            dgvAsignaturasSemestre.DataSource = null;
            dgvAsignaturasSemestre.Rows.Clear();
            dgvAsignaturasSemestre.Columns.Clear();
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
            MostrarAsignaturas();
        }

        private void MostrarAsignaturas()
        {
            if (cmbSemestre.SelectedValue != null)
            {
                CN_Docente objDocente_N = new CN_Docente();
                CN_Asignatura objAsignatura = new CN_Asignatura();
                string idSemestre = cmbSemestre.SelectedValue.ToString();
                LimpiarTabla();

                // Cargar el contenido de la tabla
                panelContent.Visible = true;
                dtAsignaturas = objAsignatura.MostrarRegistrosByIdSemestre_Negocio(idSemestre);
                dgvAsignaturasSemestre.DataSource = dtAsignaturas;
                dgvAsignaturasSemestre.Columns[2].HeaderText = "Código";
                dgvAsignaturasSemestre.Columns[3].HeaderText = "Asignatura";
                dgvAsignaturasSemestre.Columns[6].HeaderText = "Activa?";

                // Asignar los valores correspondientes a los ComboBox
                //for (int i = 0; i < dgvAsignaturasSemestre.Rows.Count - 1; i++)
                //{
                //    int valorColumna = Convert.ToInt32(dtAsignaturas.Rows[i][3]);

                //    for (int j = 4; j < dgvAsignaturasSemestre.Columns.Count; j++)
                //    {
                //        dgvAsignaturasSemestre.Rows[i].Cells[j].Value = false;
                //    }

                //    int columnaIndex = valorColumna + 3;
                //    if (columnaIndex >= 4 && columnaIndex < dgvAsignaturasSemestre.Columns.Count)
                //    {
                //        dgvAsignaturasSemestre.Rows[i].Cells[columnaIndex].Value = true;
                //    }
                //}
                dgvAsignaturasSemestre.Columns[0].Visible = false;
                dgvAsignaturasSemestre.Columns[1].Visible = false;
                clsStyles.tableActivateDocentesStyle(dgvAsignaturasSemestre);
                dgvAsignaturasSemestre.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
        }

        private void dgvAsignaturasSemestre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAsignaturasSemestre.Columns[6].Index && e.RowIndex >= 0 && dgvAsignaturasSemestre.Rows[e.RowIndex].Cells[6] is DataGridViewCheckBoxCell checkBoxCell)
            {
                if (checkBoxCell != null)
                {

                    bool habilitado = (bool)checkBoxCell.EditedFormattedValue;
                    checkBoxCell.Value = !habilitado;

                    objSemestre_Neg = new CN_Semestre();

                    if ((bool)checkBoxCell.EditedFormattedValue)
                    {
                        objSemestre_Neg.CreateOrUpdateSemestreAsignatura_Negocio(cmbSemestre.SelectedValue.ToString(), dgvAsignaturasSemestre.Rows[e.RowIndex].Cells[1].Value.ToString(), (!habilitado).ToString());
                        MostrarAsignaturas();
                    }
                    else
                    {
                        objSemestre_Neg.CreateOrUpdateSemestreAsignatura_Negocio(cmbSemestre.SelectedValue.ToString(), dgvAsignaturasSemestre.Rows[e.RowIndex].Cells[1].Value.ToString(), (!habilitado).ToString());
                        MostrarAsignaturas();
                    }
                }
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim(); // Obtener el texto ingresado en el TextBox y eliminar los espacios en blanco

            // Realizar el filtrado del DataTable en función del texto ingresado
            DataTable dataTableFiltrado = FiltrarDataTable(dtAsignaturas, filtro);

            // Asignar el DataTable filtrado al DataSource del DataGridView
            dgvAsignaturasSemestre.DataSource = dataTableFiltrado;
        }
        private DataTable FiltrarDataTable(DataTable dataTable, string filtro)
        {
            DataTable dataTableFiltrado = dataTable.Clone();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.ItemArray.Any(field => field.ToString().IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    // Copiar la fila filtrada al nuevo DataTable
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
