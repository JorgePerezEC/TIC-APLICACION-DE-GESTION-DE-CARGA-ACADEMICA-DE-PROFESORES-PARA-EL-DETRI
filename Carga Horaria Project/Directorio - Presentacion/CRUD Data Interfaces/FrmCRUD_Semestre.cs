using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Datos;
using Directorio_Logica;
using Directorio_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.CRUD_Interfaces
{
    public partial class FrmCRUD_Semestre : Form
    {
        private CN_Semestre objetoCNegocio = new CN_Semestre();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idSemestre = null;
        private bool Editar = false;
        private int selectedYearCmb;
        private DataTable dtData;
        //private string? nameDepartamento = null;
        //private string? emailDepartamento = null;
        public FrmCRUD_Semestre()
        {
            InitializeComponent();
            clsStyles.tableStyle(dgLstSemestres);
            this.KeyPreview = true;
        }
        private void FrmCRUD_Semestre_Load(object sender, EventArgs e)
        {
            MostrarSemestres();
            GetDataCmbs();
        }
        private void MostrarSemestres()
        {
            DAL_Semestre objetoCNegocio = new DAL_Semestre();
            dtData = objetoCNegocio.MostrarRegistros();
            dgLstSemestres.DataSource = dtData;
            dgLstSemestres.Columns[0].Visible = false;
        }
        private void GetDataCmbs()
        {
            int currentYear = DateTime.Now.Year;

            for (int year = 2020; year <= currentYear+20; year++)
            {
                cmbYear.Items.Add(year);
            }
            for (int weeks = 10; weeks <= 40; weeks++)
            {
                cboxSemanasTotales.Items.Add(weeks);
                cboxSemanasClase.Items.Add(weeks);
            }
            cmbYear.SelectedIndex = -1;
            cboxSemanasClase.SelectedIndex = -1;
            cboxSemanasTotales.SelectedIndex = -1;
        }

        #region Clicks Events
        private void btnNewSemestre_Click_1(object sender, EventArgs e)
        {
            Editar = false;
            if (panelNewSemestre.Visible)
            {
                panelNewSemestre.Visible = false;
            }
            else
            {
                panelNewSemestre.Visible = true;
            }
        }

        private void btnCloseWin_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (cmbYear.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un año para completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboxSemanasClase.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un número de semanas de clase para completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboxSemanasTotales.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un número de semanas totales del semestre para completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCodigo.Text.Contains(selectedYearCmb.ToString()))
            {
                MessageBox.Show("El código del semestre debe contener el año del semestre en su contenido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((int)cboxSemanasClase.SelectedItem >= (int)cboxSemanasTotales.SelectedItem)
            {
                MessageBox.Show("Debe seleccionar un número de semanas totales del semestre mayor a las semanas de clase para completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtFechaInicio.Value > dtFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de fin.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Editar == false)
            {
                try
                {

                    objetoCNegocio.CreateSemestreNegocio(txtCodigo.Text, selectedYearCmb.ToString(), dtFechaInicio.Value.ToString("yyyy-MM-dd"),
                    dtFechaFin.Value.ToString("yyyy-MM-dd"), cboxSemanasClase.Text, cboxSemanasTotales.Text);
                    MessageBox.Show("Semestre insertado correctamente");
                    MostrarSemestres();
                    ClearTxtBox();
                    panelNewSemestre.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Departamento. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    objetoCNegocio.UpdateSemestreNegocio(idSemestre, txtCodigo.Text,selectedYearCmb.ToString(), dtFechaInicio.Value.ToString("yyyy-MM-dd"),
                    dtFechaFin.Value.ToString("yyyy-MM-dd"), cboxSemanasClase.Text, cboxSemanasTotales.Text);
                    MessageBox.Show("Semestre actualizado correctamente");
                    panelNewSemestre.Visible = false;
                    MostrarSemestres();
                    Editar = false;
                    ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstSemestres.Rows.Count > 0)
                {
                    panelNewSemestre.Visible = true;
                    Editar = true;
                    idSemestre = dgLstSemestres.CurrentRow.Cells[0].Value.ToString()!;
                    txtCodigo.Text = dgLstSemestres.CurrentRow.Cells[1].Value.ToString()!;
                    cmbYear.Text = dgLstSemestres.CurrentRow.Cells[2].Value.ToString()!;
                    dtFechaInicio.Text = dgLstSemestres.CurrentRow.Cells[3].Value.ToString()!;
                    dtFechaFin.Text = dgLstSemestres.CurrentRow.Cells[4].Value.ToString()!;
                    cboxSemanasClase.Text = dgLstSemestres.CurrentRow.Cells[5].Value.ToString()!;
                    cboxSemanasTotales.Text = dgLstSemestres.CurrentRow.Cells[6].Value.ToString()!;
                }
                else 
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Departamento seleccionado. Motivo: " + ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstSemestres.Rows.Count > 0)
                {
                    idSemestre = dgLstSemestres.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteSemestreNegocio(idSemestre);
                    MessageBox.Show("Semestre eliminado correctamente");
                    MostrarSemestres();
                    ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el Departamento seleccionado. Motivo: " + ex.Message);
            }
        }

        #endregion

        #region Validation Methods
        private void ClearTxtBox()
        {
            txtCodigo.Text = string.Empty;
            cboxSemanasClase.Text = string.Empty;
            cboxSemanasTotales.Text = string.Empty;
            dtFechaFin.Text = string.Empty;
            dtFechaInicio.Text = string.Empty;
        }
        #endregion

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedYearCmb = (int)cmbYear.SelectedItem;
            txtCodigo.Text = selectedYearCmb.ToString();
        }

        private void FrmCRUD_Semestre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnGuardar.PerformClick();
                e.Handled = true;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
            DataTable dataTableFiltrado = FiltrarDataTable(dtData, filtro);
            dgLstSemestres.DataSource = dataTableFiltrado;
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
