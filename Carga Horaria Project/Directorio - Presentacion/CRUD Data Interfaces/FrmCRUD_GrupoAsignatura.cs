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
    public partial class FrmCRUD_GrupoAsignatura : Form
    {
        private ClsStyles clsStyles = new ClsStyles();

        private string? idAsignatura = null;
        private string? idGrupo = null;
        private string? NombreGR = null;
        private bool Editar = false;
        private DataTable dtData;
        CN_GrAsignatura objetoCNegocio = new CN_GrAsignatura();
        public FrmCRUD_GrupoAsignatura()
        {
            InitializeComponent();
        }

        private void FrmCRUD_GrupoAsignatura_Load(object sender, EventArgs e)
        {
            ListarAsignaturas();
            MostrarAllGrs();
            clsStyles.tableStyle(dgLstRegistros);
        }
        #region Load Data
        private void ListarAsignaturas()
        {
            CN_Asignatura objetoCNegocio = new CN_Asignatura();
            cmbAsignaturas.DataSource = objetoCNegocio.MostrarAsignaturas();
            cmbAsignaturas.DisplayMember = "Nombre de la Asignatura";
            cmbAsignaturas.ValueMember = "ID";
        }
        private void MostrarAllGrs()
        {
            CN_GrAsignatura objetoCNegocio = new CN_GrAsignatura();
            dtData = objetoCNegocio.MostrarGrAsignatura();
            dgLstRegistros.DataSource = dtData;
            dgLstRegistros.Columns[0].Visible = false;
        }
        #endregion

        #region Clic Events

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panelCreate.Visible = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    panelCreate.Visible = true;
                    Editar = true;
                    idGrupo = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    cmbAsignaturas.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    cmbGR.Text = dgLstRegistros.CurrentRow.Cells[2].Value.ToString()!;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el registro seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    idGrupo = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteGruposNeg(idGrupo);
                    MessageBox.Show("Grupo de asignatura eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarAllGrs();
                    ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el registro seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                if (cmbAsignaturas.SelectedIndex == -1 || cmbGR.Text == string.Empty)
                {
                    MessageBox.Show("Debe llenar todos los campos para completar el registro del Grupo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    int cmbValue = Convert.ToInt32(cmbAsignaturas.SelectedValue);
                    objetoCNegocio.CreateGruposNeg(cmbValue.ToString(), cmbGR.Text);
                    MessageBox.Show("GR insertadado correctamente", "GRUPO REGISTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarAllGrs();
                    ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: No se pudo registrar el Docente. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (Editar == true)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbAsignaturas.SelectedValue);
                    objetoCNegocio.UpdateGruposNeg(idGrupo, cmbValue.ToString(), cmbGR.Text);
                    MessageBox.Show("GR actualizado correctamente", "GRUPO ACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarAllGrs();
                    Editar = false;
                    ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            panelCreate.Visible = false;
        }

        private void ClearTxtBox()
        {
            panelCreate.Visible = false;
            cmbAsignaturas.SelectedIndex= -1;
            cmbGR.SelectedIndex= -1;
        }

        #endregion

        private void cmbAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAsignaturas.SelectedIndex >= 0)
            {
                CN_GrAsignatura objetoGrNegocio = new CN_GrAsignatura();

                // Comprobar si el SelectedValue no es nulo
                if (cmbAsignaturas.SelectedValue != null)
                {
                    if (int.TryParse(cmbAsignaturas.SelectedValue.ToString(), out int selectedValueAsInt))
                    {
                        txtNivel.Text = objetoGrNegocio.GetLvlAsignatura_Negocio(selectedValueAsInt.ToString());
                        txtType.Text = objetoGrNegocio.GetTypeAsigByAsig_Negocio(selectedValueAsInt.ToString());
                        txtCode.Text = objetoGrNegocio.GetCodeAsigByAsig_Negocio(selectedValueAsInt.ToString());
                    }
                }
            }
            
        }

        private void dgLstRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
