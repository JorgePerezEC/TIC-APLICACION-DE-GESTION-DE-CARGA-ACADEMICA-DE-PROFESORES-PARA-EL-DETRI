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
            clsStyles.tableStyle(dgLstRegistros);
        }
        private void MostrarAsignaturas()
        {
            CN_Asignatura objetoCNegocio = new CN_Asignatura();
            dgLstRegistros.DataSource = objetoCNegocio.MostrarAsignaturas();
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
            if (Editar == false)
            {
                try
                {
                    objetoCNegocio.CreateAsignaturaNeg(txtNombreAsignatura.Text, txtTipoAsignatura.Text, txtCodigo.Text, txtHTotales.Text, txtHSemanales.Text, txtNivel.Text, ckboxEstado.Checked.ToString());
                    MessageBox.Show("Carrera insertadada correctamente" + ckboxEstado.Checked.ToString());
                    MostrarAsignaturas();
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: No se pudo registrar la Carrera. Motivo: " + ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    objetoCNegocio.UpdateAsignaturaNeg(idAsignatura, txtNombreAsignatura.Text, txtTipoAsignatura.Text, txtCodigo.Text, txtHTotales.Text, txtHSemanales.Text, txtNivel.Text, ckboxEstado.Checked.ToString());
                    MessageBox.Show("Carrera actualizada correctamente");
                    MostrarAsignaturas();
                    Editar = false;
                    //ClearTxtBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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
                    idAsignatura = dgLstRegistros.CurrentRow.Cells[0].Value.ToString()!;
                    txtNombreAsignatura.Text = dgLstRegistros.CurrentRow.Cells[1].Value.ToString()!;
                    txtTipoAsignatura.Text = dgLstRegistros.CurrentRow.Cells[2].Value.ToString();
                    txtCodigo.Text = dgLstRegistros.CurrentRow.Cells[3].Value.ToString();
                    txtHTotales.Text = dgLstRegistros.CurrentRow.Cells[4].Value.ToString();
                    txtHSemanales.Text = dgLstRegistros.CurrentRow.Cells[5].Value.ToString();
                    txtNivel.Text = dgLstRegistros.CurrentRow.Cells[6].Value.ToString();
                    ckboxEstado.Text = dgLstRegistros.CurrentRow.Cells[7].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee editar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo actualizar el Tipo de Actividad seleccionado. Motivo: " + ex.Message);
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
                    MessageBox.Show("Carrera eliminada correctamente");
                    MostrarAsignaturas();
                    //ClearTxtBox();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione el registro que desee eliminar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: No se pudo eliminar la Carrera seleccionada. Motivo: " + ex.Message);
            }
        }
        #endregion

        private void ntmNew_Click(object sender, EventArgs e)
        {
            panelCreate.Visible = true;
        }
    }
}
