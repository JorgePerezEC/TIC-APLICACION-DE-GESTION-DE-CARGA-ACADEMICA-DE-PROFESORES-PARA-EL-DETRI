using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using Directorio_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio___Presentacion.CRUD_Interfaces
{
    public partial class FrmCRUD_Docente : Form
    {
        private CN_Docente objetoCNegocio = new CN_Docente();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idDocente = null;
        private bool Editar = false;
        private DataTable dtData;
        public FrmCRUD_Docente()
        {
            InitializeComponent();
        }

        private void FrmCRUD_Docente_Load(object sender, EventArgs e)
        {
            MostrarDocentes();
            ListarDepartamentos();
            
        }
        private void MostrarDocentes()
        {
            CN_Docente objetoCNegocio = new CN_Docente();
            dtData = objetoCNegocio.MostrarDocentes();
            dgLstRegistros.DataSource = dtData;

            clsStyles.tableStyle(dgLstRegistros);
            dgLstRegistros.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgLstRegistros.Columns[0].Visible = false;
        }
        private void ListarDepartamentos()
        {
            CN_Departamento objetoCNegDepa = new CN_Departamento();
            cmbDepartamentos.DataSource = objetoCNegDepa.MostrarDepartamentos();
            cmbDepartamentos.DisplayMember = "Nombre del Departamento";
            cmbDepartamentos.ValueMember = "ID";
        }
        #region Clicks events
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (panelCreate.Visible)
            {
                panelCreate.Visible = false;
                ClearTxtBox();
            }
            else
            {
                panelCreate.Visible = true;
            }
        }

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbDepartamentos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Departamento para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSApellido.Text == string.Empty || txtTitulo.Text == string.Empty || txtPNombre.Text == string.Empty || txtPApellido.Text == string.Empty || txtSApellido.Text == string.Empty || txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Debe completar todos los campos de texto para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ComprobarFormatoEmail(txtEmail.Text))
            {
                MessageBox.Show("El Email ** " + txtEmail.Text + " ** ingresado es inválido.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Editar == false)
            {
                try
                {
                    
                    int cmbValue = Convert.ToInt32(cmbDepartamentos.SelectedValue);
                    objetoCNegocio.CreateDocenteNeg(cmbValue.ToString(), txtPNombre.Text, txtSNombre.Text, txtPApellido.Text, txtSApellido.Text, txtTitulo.Text, txtEmail.Text);
                    MessageBox.Show("Docente agregado correctamente", "DOCENTE REGISTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDocentes();
                    ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Docente. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (Editar == true)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbDepartamentos.SelectedValue);
                    objetoCNegocio.UpdateDocenteNeg(idDocente, cmbValue.ToString(), txtPNombre.Text, txtSNombre.Text, txtPApellido.Text, txtSApellido.Text, txtTitulo.Text, txtEmail.Text);
                    MessageBox.Show("Docente actualizado correctamente", "DOCENTE ACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDocentes();
                    Editar = false;
                    ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            panelCreate.Visible = false;
        }

        private void ClearTxtBox()
        {
            txtTitulo.Text = string.Empty;
            txtPApellido.Text = string.Empty;
            txtPNombre.Text = string.Empty;
            txtSApellido.Text = string.Empty;
            txtSNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbDepartamentos.SelectedIndex = -1;
            panelCreate.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    panelCreate.Visible = true;
                    Editar = true;
                    string[] names = dgLstRegistros.CurrentRow.Cells[2].Value.ToString().Split(' ');
                    string[] lastnames = dgLstRegistros.CurrentRow.Cells[3].Value.ToString().Split(' ');
                    idDocente = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    cmbDepartamentos.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    txtPNombre.Text = names[0] ;
                    txtSNombre.Text = names[1];
                    txtPApellido.Text = lastnames[0];
                    txtSApellido.Text = lastnames[1];
                    txtTitulo.Text = dgLstRegistros.CurrentRow.Cells[4].Value.ToString();
                    txtEmail.Text = dgLstRegistros.CurrentRow.Cells[5].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Docente seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    idDocente = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteDocenteNeg(idDocente);
                    MessageBox.Show("Docente eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDocentes();
                    ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el Docente seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void dgLstRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
