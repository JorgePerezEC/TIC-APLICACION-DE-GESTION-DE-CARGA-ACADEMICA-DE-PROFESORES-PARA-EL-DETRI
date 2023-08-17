﻿using Directorio___Presentacion.ElementsStyles_Configuration;
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
    public partial class FrmCRUD_Docente : Form
    {
        private CN_Docente objetoCNegocio = new CN_Docente();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idDocente = null;
        private string? idDepartamento = null;
        private bool Editar = false;
        private string nameCarrera;
        private string codigoCarrera;
        private string pensum;
        private string estado;
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
            dgLstRegistros.DataSource = objetoCNegocio.MostrarDocentes();
            clsStyles.tableStyle(dgLstRegistros);
            dgLstRegistros.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    if (cmbDepartamentos.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar un Departamento para completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txtSApellido.Text == string.Empty || txtTitulo.Text == string.Empty || txtPNombre.Text == string.Empty || txtPApellido.Text == string.Empty || txtSApellido.Text == string.Empty)
                    {
                        MessageBox.Show("Debe completar todos los campos de texto para completar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int cmbValue = Convert.ToInt32(cmbDepartamentos.SelectedValue);
                    objetoCNegocio.CreateDocenteNeg(cmbValue.ToString(), txtPNombre.Text, txtSNombre.Text, txtPApellido.Text, txtSApellido.Text, txtTitulo.Text);
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
                    objetoCNegocio.UpdateDocenteNeg(idDocente, cmbValue.ToString(), txtPNombre.Text, txtSNombre.Text, txtPApellido.Text, txtSApellido.Text, txtTitulo.Text);
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
    }
}
