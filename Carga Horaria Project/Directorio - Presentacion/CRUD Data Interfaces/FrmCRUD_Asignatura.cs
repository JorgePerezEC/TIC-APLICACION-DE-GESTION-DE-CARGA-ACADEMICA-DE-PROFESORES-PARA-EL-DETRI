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

namespace Directorio___Presentacion.CRUD_Interfaces
{
    public partial class FrmCRUD_Asignatura : Form
    {
        private CN_Asignatura objetoCNegocio = new CN_Asignatura();
        private ClsStyles clsStyles = new ClsStyles();
        private string? idAsignatura = null;
        private bool Editar = false;
        private string nameCarrera;
        private string estado;
        public FrmCRUD_Asignatura()
        {
            InitializeComponent();
        }

        private void FrmCRUD_Asignatura_Load(object sender, EventArgs e)
        {
            MostrarAsignaturas();
            ListarCarreras();
            clsStyles.tableStyle(dgLstRegistros);
        }
        private void ListarCarreras()
        {
            CN_Carrera objetoCNegocio = new CN_Carrera();
            cmbCarrera.DataSource = objetoCNegocio.MostrarCarreras();
            cmbCarrera.DisplayMember = "Carrera";
            cmbCarrera.ValueMember = "ID";
        }
        private void MostrarAsignaturas()
        {
            CN_Asignatura objetoCNegocio = new CN_Asignatura();
            dgLstRegistros.DataSource = objetoCNegocio.MostrarAsignaturas();
            dgLstRegistros.Columns[0].Visible = false;
            dgLstRegistros.Columns[1].Visible = false;
        }
        #region Clicks Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            panelCreate.Visible= true;
        }

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (Editar == false)
            {
                try
                {
                    objetoCNegocio.CreateAsignaturaNeg(cmbCarrera.SelectedValue.ToString(),txtNombreAsignatura.Text, txtTipoAsignatura.Text, txtCodigo.Text, txtHTotales.Text, txtHSemanales.Text, txtNivel.Text);
                    MessageBox.Show("Asignatura insertadada correctamente", "ASIGANTURA REGISTRADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarAsignaturas();
                    panelCreate.Visible= false;
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar la Asignatura. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (Editar == true)
            {
                try
                {
                    objetoCNegocio.UpdateAsignaturaNeg(idAsignatura,cmbCarrera.SelectedValue.ToString(), txtNombreAsignatura.Text, txtTipoAsignatura.Text, txtCodigo.Text, txtHTotales.Text, txtHSemanales.Text, txtNivel.Text);
                    MessageBox.Show("Asignatura actualizada correctamente", "ASIGNATURA ACTUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarAsignaturas();
                    Editar = false;
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            panelCreate.Visible = false;
        }

        private void ValidarCampos()
        {
            if (cmbCarrera.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Carrera para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCodigo.Text == string.Empty || txtTipoAsignatura.Text == string.Empty || txtCodigo.Text == string.Empty || txtHSemanales.Text == string.Empty || txtHTotales.Text == string.Empty || txtNivel.Text == string.Empty)
            {
                MessageBox.Show("Debe completar todos los campos de texto para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    panelCreate.Visible = true;
                    Editar = true;
                    cmbCarrera.SelectedValue = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    idAsignatura = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    txtNombreAsignatura.Text = dgLstRegistros.CurrentRow.Cells[3].Value.ToString()!;
                    txtTipoAsignatura.Text = dgLstRegistros.CurrentRow.Cells[4].Value.ToString();
                    txtCodigo.Text = dgLstRegistros.CurrentRow.Cells[5].Value.ToString();
                    txtHTotales.Text = dgLstRegistros.CurrentRow.Cells[6].Value.ToString();
                    txtHSemanales.Text = dgLstRegistros.CurrentRow.Cells[7].Value.ToString();
                    txtNivel.Text = dgLstRegistros.CurrentRow.Cells[8].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar la asignatura seleccionada. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    idAsignatura = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteAsignaturaNeg(idAsignatura);
                    MessageBox.Show("Asignatura eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarAsignaturas();
                    //ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar la Asignatura seleccionada. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void ntmNew_Click(object sender, EventArgs e)
        {
            panelCreate.Visible = true;
        }

        private void txtHTotales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter ingresado si no es un número ni una tecla de control
            }
        }
    }
}
