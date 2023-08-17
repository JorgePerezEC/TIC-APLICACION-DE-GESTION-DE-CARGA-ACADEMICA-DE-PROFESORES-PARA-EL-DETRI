using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;


namespace Directorio___Presentacion
{
    public partial class FrmCRUD_Actividad : Form
    {
        private CN_Actividad objetoCNegocio = new CN_Actividad();
        private ClsStyles clsStyles = new ClsStyles();
        private string? idActividad = null;
        private string? idDepartamento = null;
        private bool Editar = false;

        public FrmCRUD_Actividad()
        {
            InitializeComponent();
        }

        private void FrmCRUD_Actividad_Load(object sender, EventArgs e)
        {
            MostrarActividades();
            ListarTiposActividades();
            clsStyles.tableStyle(dgLstRegistros);
            txtHorasSemanales.Enabled= false;
            txtHorasTotales.Enabled= false;
            ckboxSemanal.Checked= false;
            ckboxTotal.Checked= false;
        }
        private void MostrarActividades()
        {
            CN_Actividad objetoCNegocio = new CN_Actividad();
            dgLstRegistros.DataSource = objetoCNegocio.MostrarActividadesNeg();
        }
        private void ListarTiposActividades()
        {
            CN_Actividad objetoCNegocio = new CN_Actividad();
            cmbTpActiv.DataSource = objetoCNegocio.MostrarTpActividadesNeg();
            cmbTpActiv.DisplayMember = "Tipo de Actividad";
            cmbTpActiv.ValueMember = "ID";
            cmbTpActiv.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTpActiv.SelectedIndex = -1;
        }
        #region Clicks Events
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbTpActiv.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de actividad para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNameActividad.Text == string.Empty)
            {
                MessageBox.Show("Debe completar el nombre de la actividad para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((ckboxTotal.Checked && txtHorasTotales.Text == string.Empty) ||(ckboxSemanal.Checked && txtHorasSemanales.Text == string.Empty))
            {
                MessageBox.Show("Debe ingresar las horas de la actividad para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Editar == false)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbTpActiv.SelectedValue);
                    
                    objetoCNegocio.CreateActividadNeg(cmbValue.ToString(), txtNameActividad.Text, txtHorasSemanales.Text,txtHorasTotales.Text);
                    MessageBox.Show("Actividad insertadada correctamente", "ACTIVIDAD REGISTRADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarActividades();
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar la Actividad. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (Editar == true)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbTpActiv.SelectedValue);
                    objetoCNegocio.UpdateActividadNeg(idActividad, cmbValue.ToString(), txtNameActividad.Text, txtHorasSemanales.Text, txtHorasTotales.Text);
                    MessageBox.Show("Actividad actualizada correctamente", "ACTIVIDAD ACTUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarActividades();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            panelCreate.Visible = true;
            ckboxSemanal.Checked = true;
        }

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    panelCreate.Visible = true;
                    Editar = true;
                    idActividad = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    cmbTpActiv.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    txtNameActividad.Text = dgLstRegistros.CurrentRow.Cells[2].Value.ToString();
                    txtHorasSemanales.Text = dgLstRegistros.CurrentRow.Cells[3].Value.ToString();

                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar la Actividad seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstRegistros.Rows.Count > 0)
                {
                    idActividad = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteActividadNeg(idActividad);
                    MessageBox.Show("Actividad eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarActividades();
                    //ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar la Actividad seleccionada. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void ckboxSemanal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckboxSemanal.Checked)
            {
                ckboxTotal.Checked = false;
                txtHorasTotales.Text = "0";
                txtHorasSemanales.Text = "";
                txtHorasTotales.Enabled = false;
                txtHorasSemanales.Enabled = true;
            }
        }

        private void ckboxTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckboxTotal.Checked)
            {
                txtHorasTotales.Text = "";
                ckboxSemanal.Checked = false;
                txtHorasSemanales.Text = "0";
                txtHorasSemanales.Enabled = false;
                txtHorasTotales.Enabled = true;
            }
        }

        private void txtHorasSemanales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter ingresado si no es un número ni una tecla de control
            }
        }
    }
}
