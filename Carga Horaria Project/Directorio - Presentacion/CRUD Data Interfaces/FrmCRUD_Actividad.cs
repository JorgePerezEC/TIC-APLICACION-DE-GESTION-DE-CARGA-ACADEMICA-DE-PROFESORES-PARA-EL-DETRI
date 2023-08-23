using Directorio___Presentacion.ElementsStyles_Configuration;
using Directorio_Logica;
using System.Data;
using System.Diagnostics;

namespace Directorio___Presentacion
{
    public partial class FrmCRUD_Actividad : Form
    {
        private CN_Actividad objetoCNegocio = new CN_Actividad();
        private ClsStyles clsStyles = new ClsStyles();
        private string? idActividad = null;
        private string? idDepartamento = null;
        private DataTable dtData;
        private DataTable dtProyectos;
        private bool Editar = false;
        private bool openPanelCreate = false;
        private string urlAval = string.Empty;
        private int idProyecto = 0;
        private int horasSemanales = 0;
        private int horasTotales = 0;

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
            dtData = objetoCNegocio.MostrarActividadesNeg();
            dgLstRegistros.DataSource = dtData;

            dgLstRegistros.Columns[0].Visible = false;
            dgLstRegistros.Columns[6].Visible = false;
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
        private void ListarProyectos()
        {
            CN_Proyecto objetoProyectoCNegocio = new CN_Proyecto();
            dtProyectos = objetoProyectoCNegocio.MostrarRegistros();
            cmbProyectos.DataSource = dtProyectos;
            cmbProyectos.DisplayMember = "PROYECTO";
            cmbProyectos.ValueMember = "idProyecto";
            cmbProyectos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProyectos.SelectedIndex = -1;
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
            if (cbProyecto.Checked && cmbProyectos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un proyecto para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ckboxSemanal.Checked)
            {
                horasSemanales = Convert.ToInt32(txtHorasSemanales.Text);
                horasTotales = 0;
            }
            if (ckboxTotal.Checked)
            {
                horasTotales = Convert.ToInt32(txtHorasSemanales.Text);
                horasSemanales = 0;
            }

            if (Editar == false)
            {
                try
                {
                    int cmbValue = Convert.ToInt32(cmbTpActiv.SelectedValue);
                    
                    objetoCNegocio.CreateActividadNeg(cmbValue.ToString(), idProyecto, txtNameActividad.Text, horasSemanales.ToString(), horasTotales.ToString());
                    MessageBox.Show("Actividad insertadada correctamente", "ACTIVIDAD REGISTRADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarActividades();
                    clearInfoFrm();
                }
                catch (FormatException)
                {
                    MessageBox.Show("El valor seleccionado en el tipo de actividad no es válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    objetoCNegocio.UpdateActividadNeg(idActividad, idProyecto, cmbValue.ToString(), txtNameActividad.Text, horasSemanales.ToString(), horasTotales.ToString());
                    MessageBox.Show("Actividad actualizada correctamente", "ACTIVIDAD ACTUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarActividades();
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
            panelCreate.Visible = true;
            ckboxSemanal.Checked = true;
            btnGuardar.Text = "Guardar";
            openPanelCreate = !openPanelCreate;
            panelCreate.Visible = openPanelCreate;
            clearInfoFrm();
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
                    txtNameActividad.Text = dgLstRegistros.CurrentRow.Cells[3].Value.ToString()!;
                    cmbTpActiv.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    idProyecto = Convert.ToInt32(dgLstRegistros.CurrentRow.Cells[6].Value);

                    int numHSemanal = Convert.ToInt32(dgLstRegistros.CurrentRow.Cells[4].Value.ToString());
                    int numHTotal = Convert.ToInt32(dgLstRegistros.CurrentRow.Cells[5].Value.ToString());

                    if (numHSemanal != 0)
                    {
                        ckboxSemanal.Checked = true;
                        txtHorasSemanales.Text = dgLstRegistros.CurrentRow.Cells[4].Value.ToString();
                    }
                    if (numHTotal != 0)
                    {
                        ckboxTotal.Checked = true;
                        txtHorasTotales.Text = dgLstRegistros.CurrentRow.Cells[5].Value.ToString();
                    }

                    if (idProyecto != 0)
                    {
                        cbProyecto.Checked = true;
                        cmbProyectos.SelectedIndex = idProyecto;
                    }
                    btnGuardar.Text = "Actualizar";
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
                    clearInfoFrm();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelCreate.Visible = false;
            openPanelCreate = false;
            clearInfoFrm();
        }

        private void clearInfoFrm()
        {
            cmbTpActiv.SelectedIndex = -1;
            txtHorasSemanales.Text= string.Empty;
            txtHorasTotales.Text= string.Empty;
            txtNameActividad.Text= string.Empty;
            txtPresupuesto.Text= string.Empty;
            cbProyecto.Checked = false;
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
            else
            {
                horasSemanales = 0;
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
            else
            {
                horasTotales = 0;
            }
        }

        private void txtHorasSemanales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter ingresado si no es un número ni una tecla de control
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

        private void cbProyecto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProyecto.Checked)
            {
                cmbProyectos.Enabled = true;
                panelProyectos.Visible = true;
            }
            else {
                cmbProyectos.Enabled = false;
                panelProyectos.Visible = false;
                cmbProyectos.SelectedIndex = -1;
                dtFechaInicio.Text = string.Empty;
                dtFechaFin.Text = string.Empty;
                txtPresupuesto.Text = string.Empty;
                pictBoxAval.Visible= false;
                idProyecto = 0;
            }
        }

        private void cbProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProyectos.SelectedIndex != -1 && cmbProyectos.SelectedValue.ToString() != null)
            {
                if (cmbProyectos.SelectedIndex != -1 && int.TryParse(cmbProyectos.SelectedValue.ToString(), out int selectedValue))
                {
                    DataRow selectedRow = ((DataRowView)cmbProyectos.SelectedItem).Row;

                    // Obtener valores de la fila seleccionada
                    idProyecto = Convert.ToInt32(selectedRow["idProyecto"]);
                    string codigo = selectedRow["CÓDIGO"].ToString();
                    string nombreProyecto = selectedRow["PROYECTO"].ToString();
                    string fechaInicio = selectedRow["FECHA INICIO"].ToString();
                    string fechaFin = selectedRow["FECHA FIN"].ToString();
                    string presupuesto = selectedRow["PRESUPUESTO"].ToString();
                    string tipo = selectedRow["TIPO"].ToString();
                    string urlAvalGet = selectedRow["AVAL"].ToString();

                    // Asignar valores a los campos de texto
                    //txt.Text = codigo;
                    dtFechaInicio.Value = DateTime.Parse(fechaInicio);
                    dtFechaFin.Value = DateTime.Parse(fechaFin);
                    txtPresupuesto.Text = presupuesto;
                    txtCodeProyecto.Text = codigo;
                    //txtT.Text = tipo;
                    urlAval = urlAvalGet;
                    pictBoxAval.Enabled= true;
                    pictBoxAval.Visible = true;

                }
                else
                {
                    panelCheckProyecto.Visible = false;
                    panelProyectos.Visible = false;
                    cmbProyectos.SelectedIndex = -1;
                }
            }
        }

        private void cmbTpActiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTpActiv.SelectedIndex != -1 && cmbTpActiv.SelectedValue.ToString() != null)
            {
                if (cmbTpActiv.SelectedIndex != -1 && int.TryParse(cmbTpActiv.SelectedValue.ToString(), out int selectedValue) && selectedValue == 3)
                {
                    ListarProyectos();
                    panelCheckProyecto.Visible = true;
                    //pictBoxAval.Image = Image.FromFile(@"Images\EPNLogo.png");
                    pictBoxAval.Image = new Bitmap(Properties.Resources.archivo_pdf, new Size(40, 40));

                }
                else
                {
                    panelCheckProyecto.Visible = false;
                    panelProyectos.Visible = false;
                    cmbProyectos.SelectedIndex = -1;
                    pictBoxAval.Enabled = false;
                    pictBoxAval.Visible = false;
                }
            }
        }

        private void pictBoxAval_Click(object sender, EventArgs e)
        {
            if (urlAval != string.Empty)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = urlAval,
                    UseShellExecute = true
                });
            }
        }
    }
}
