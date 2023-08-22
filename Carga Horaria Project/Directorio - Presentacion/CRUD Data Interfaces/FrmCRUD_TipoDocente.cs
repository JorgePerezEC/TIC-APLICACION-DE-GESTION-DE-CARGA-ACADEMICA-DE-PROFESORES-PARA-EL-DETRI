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
    public partial class FrmCRUD_TipoDocente : Form
    {
        private CN_TipoDocente objetoCNegocio = new CN_TipoDocente();
        private ClsStyles clsStyles = new ClsStyles();

        private string? idTpDocente = null;
        private bool Editar = false;
        private string nameTpDocente;
        private string estadoTpDocente;
        public FrmCRUD_TipoDocente()
        {
            InitializeComponent();
            clsStyles.tableLargeRowStyle(dgLstTpDocentes);
        }

        private void FrmTipoDocente_Load(object sender, EventArgs e)
        {
            MostrarTiposDocentes();

        }
        private void MostrarTiposDocentes()
        {
            CN_TipoDocente objetoCNegocio = new CN_TipoDocente();
            dgLstTpDocentes.DataSource = objetoCNegocio.MostrarTiposDocentesLn();
            dgLstTpDocentes.Columns[0].Visible = false;
            dgLstTpDocentes.Columns[1].HeaderText = "TIPO DE DOCENTE";
            dgLstTpDocentes.Columns[2].HeaderText = "HORAS SEMESTRALES";
        }
        #region Clicks Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            panelNewTpActividad.Visible = true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtHorasExigibles.Text == string.Empty || txtNameTpDoc.Text == string.Empty )
            {
                MessageBox.Show("Debe completar todos los campos de texto para completar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Editar == false)
            {
                try
                {
                    objetoCNegocio.CreateTiposDocentesNeg(txtNameTpDoc.Text, txtHorasExigibles.Text);
                    MessageBox.Show("Tipo de docente insertado correctamente", "TIPO DE DOCENTE REGISTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarTiposDocentes();
                    panelNewTpActividad.Visible = false;
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar el Tipo de docente. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (Editar == true)
            {
                try
                {
                    objetoCNegocio.UpdateTiposDocentesNeg(idTpDocente, txtNameTpDoc.Text, txtHorasExigibles.Text);
                    MessageBox.Show("Tipo de docente actualizado correctamente", "TIPO DE DOCENTE ACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarTiposDocentes();
                    Editar = false;
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            panelNewTpActividad.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstTpDocentes.Rows.Count > 0)
                {
                    panelNewTpActividad.Visible = true;
                    Editar = true;
                    txtNameTpDoc.Text = dgLstTpDocentes.CurrentRow.Cells[1].Value.ToString();
                    idTpDocente = dgLstTpDocentes.CurrentRow.Cells[0].Value.ToString()!;
                    txtHorasExigibles.Text = dgLstTpDocentes.CurrentRow.Cells[2].Value.ToString()!;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Tipo de Docente seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgLstTpDocentes.Rows.Count > 0)
                {
                    idTpDocente = dgLstTpDocentes.CurrentRow.Cells[0].Value.ToString()!;
                    objetoCNegocio.DeleteTiposDocentesNeg(idTpDocente);
                    MessageBox.Show("Tipo de Docente eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarTiposDocentes();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar el Tipo de Docente seleccionado. Motivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void txtHorasExigibles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter ingresado si no es un número ni una tecla de control
            }
        }
    }
}
