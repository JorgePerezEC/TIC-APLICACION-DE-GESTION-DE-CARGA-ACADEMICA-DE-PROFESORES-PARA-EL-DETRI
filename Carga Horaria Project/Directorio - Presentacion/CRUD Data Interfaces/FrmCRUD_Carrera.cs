using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Entidades;
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

namespace Directorio___Presentacion.CRUD_Interfaces
{
    public partial class FrmCRUD_Carrera : Form
    {
        private CN_Carrera objetoCNegocio = new CN_Carrera();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idCarrera = null;
        private string? idDepartamento = null;
        private bool Editar = false;
        private string nameCarrera;
        private string codigoCarrera;
        private string pensum;
        private string estado;
        private DataTable dtData;
        private bool openPanelCreate = false;
        public FrmCRUD_Carrera()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FrmCRUD_Carrera_Load(object sender, EventArgs e)
        {
            MostrarCarreras();
            ListarDepartamentos();
            clsStyles.tableStyle(dgLstRegistros);
        }
        private void MostrarCarreras()
        {
            CN_Carrera objetoCNegocio = new CN_Carrera();
            dtData = objetoCNegocio.MostrarCarreras();
            dgLstRegistros.DataSource = dtData;
            dgLstRegistros.Columns[0].Visible = false;

        }
        private void ListarDepartamentos()
        {
            CN_Carrera objetoCNegocio = new CN_Carrera();
            cmbDepartamentos.DataSource = objetoCNegocio.MostrarDepartamentosNeg();
            cmbDepartamentos.DisplayMember = "Name";
            cmbDepartamentos.ValueMember= "ID";
        }
        
        #region Clicks Events
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbDepartamentos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Departamento para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCodigo.Text == string.Empty || txtPensum.Text == string.Empty || txtNameCarreer.Text == string.Empty)
            {
                MessageBox.Show("Debe completar todos los campos de texto para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Editar == false)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbDepartamentos.SelectedValue);
                    objetoCNegocio.CreateCarreraNeg(cmbValue.ToString(), txtNameCarreer.Text, txtCodigo.Text, txtPensum.Text);
                    MessageBox.Show("Carrera insertadada correctamente", "CARRERA REGISTRADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarCarreras();
                    panelCreate.Visible = false;
                    clearInfoFrm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar la Carrera. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (Editar == true)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbDepartamentos.SelectedValue);
                    objetoCNegocio.UpdateCarreraNeg(idCarrera, cmbValue.ToString(), txtNameCarreer.Text, txtCodigo.Text, txtPensum.Text);
                    MessageBox.Show("Carrera actualizada correctamente", "CARRERA ACTULIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarCarreras();
                    Editar = false;
                    clearInfoFrm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            panelCreate.Visible = false;
            openPanelCreate = false;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Editar = false;
            btnGuardar.Text = "Guardar";
            openPanelCreate = !openPanelCreate;
            panelCreate.Visible = openPanelCreate;
            clearInfoFrm();
        }

        private void clearInfoFrm()
        {
            cmbDepartamentos.SelectedIndex = -1;
            txtCodigo.Text = string.Empty;
            txtPensum.Text = string.Empty;
            txtNameCarreer.Text = string.Empty;
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    btnGuardar.Text = "Actualizar";
                    panelCreate.Visible = true;
                    Editar = true;
                    idCarrera = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    cmbDepartamentos.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    txtNameCarreer.Text = dgLstRegistros.CurrentRow.Cells[2].Value.ToString();
                    txtCodigo.Text = dgLstRegistros.CurrentRow.Cells[3].Value.ToString();
                    txtPensum.Text = dgLstRegistros.CurrentRow.Cells[4].Value.ToString();
                    
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar la Carrera seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    idCarrera = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteCarreraNeg(idCarrera);
                    MessageBox.Show("Carrera eliminada correctamente");
                    MostrarCarreras();
                    //ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar la Carrera seleccionada. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void FrmCRUD_Carrera_KeyDown(object sender, KeyEventArgs e)
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
            dgLstRegistros.DataSource = dataTableFiltrado;
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

        private void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
